using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TagChecker : MonoBehaviour
{
    public string requiredTag;
    public int scoreValue = 1;

    public ScoreManageri scoreManager;
    public UIManageri uiManager;

    private XRSocketInteractor socket;

    private GameObject currentObject;
    private bool isCurrentlyScored = false;

    private void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    private void OnEnable()
    {
        socket.selectEntered.AddListener(OnPlaced);
        socket.selectExited.AddListener(OnRemoved);
    }

    private void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnPlaced);
        socket.selectExited.RemoveListener(OnRemoved);
    }

    private void OnPlaced(SelectEnterEventArgs args)
    {
        GameObject obj = args.interactableObject.transform.gameObject;

        currentObject = obj;

        // ALWAYS tell UI that socket is filled
        uiManager.SocketFilled();

        // Handle scoring separately
        if (obj.CompareTag(requiredTag) && !isCurrentlyScored)
        {
            scoreManager.AddScore(scoreValue);
            isCurrentlyScored = true;
        }
    }

    private void OnRemoved(SelectExitEventArgs args)
    {
        GameObject obj = args.interactableObject.transform.gameObject;

        // ALWAYS tell UI that socket is empty
        uiManager.SocketEmptied();

        if (obj == currentObject && obj.CompareTag(requiredTag) && isCurrentlyScored)
        {
            scoreManager.AddScore(-scoreValue);
            isCurrentlyScored = false;
        }

        currentObject = null;
    }
}
