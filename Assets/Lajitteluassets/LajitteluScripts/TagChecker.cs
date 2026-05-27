using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

// This handles the socket interaction and scoring logic
//
// adds custom game logic:
//  -checks whether object is correct
//  -adds/removes score
//  -notifies the Ui system
//
// In inspector:
// - attach this script to XR socket interactor objects ("Jalkojenpaikka","polvienpaikka", ect)
//  -set required tag
//  -assign ScoreManageri
//  -assign UIManageri


public class TagChecker : MonoBehaviour
{
    //the correct tag for this socket
    //for example: jalka, polvi, ...
    public string requiredTag;

    //how many points this socket gives
    public int scoreValue = 1;

    //reference to the score and UI manager in the scene
    //Assigned in the inspector
    public ScoreManageri scoreManager;
    public UIManageri uiManager;

    private XRSocketInteractor socket;

    //stores the object currently inside the socket
    private GameObject currentObject;

    //prevents duplicate scoring 
    private bool isCurrentlyScored = false;

    private void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    
    private void OnEnable()
    {
        //detects when object is placed/removed from socket
        socket.selectEntered.AddListener(OnPlaced);
        socket.selectExited.AddListener(OnRemoved);
    }

    //removes listeners when object is disabled
    private void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnPlaced);
        socket.selectExited.RemoveListener(OnRemoved);
    }

   //called when object is inserted into socket
    private void OnPlaced(SelectEnterEventArgs args)
    {
        //get inserted object
        GameObject obj = args.interactableObject.transform.gameObject;

        currentObject = obj;

        //ui checks if any object is inside it, doesnt care if object is correct
        uiManager.SocketFilled();

        //checks that object has correct tag and socket has not already given score
        if (obj.CompareTag(requiredTag) && !isCurrentlyScored)
        {
            //add score
            scoreManager.AddScore(scoreValue);
            
            //prevent duplicate scoring 
            isCurrentlyScored = true;
        }
    }

    //called when object is removed from socket
    private void OnRemoved(SelectExitEventArgs args)
    {   
        //gets removed object
        GameObject obj = args.interactableObject.transform.gameObject;

        //removed object empties socket
        uiManager.SocketEmptied();


        //checks that object has correct tag and was currently giving score
        if (obj == currentObject && obj.CompareTag(requiredTag) && isCurrentlyScored)
        {
            //remove score by adding negative value
            scoreManager.AddScore(-scoreValue);

            //allows scoring again when object is put back
            isCurrentlyScored = false;
        }

        currentObject = null;
    }
}
