using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManageri : MonoBehaviour
{
    public GameObject tarkistaButton;
    public TextMeshProUGUI scoreText;

    public ScoreManageri scoreManager;

    public int totalSockets = 0;
    private int filledSockets = 0;

    public ResettableObject[] resettableObjects;

    public void SocketFilled()
    {
        filledSockets++;

        if (filledSockets >= totalSockets)
        {
            tarkistaButton.SetActive(true);
        }
    }

    public void SocketEmptied()
    {
        filledSockets--;

        if (filledSockets < totalSockets)
        {
            tarkistaButton.SetActive(false);
        }
    }

    public void OnTarkistaPressed()
    {
        scoreText.gameObject.SetActive(true);
        scoreText.text = "Sait oikein: " + scoreManager.score + "!";
    }

    public void ResetGame()
    {
        // Reset score
        scoreManager.score = 0;

        // Reset socket count
        filledSockets = 0;

        // Hide UI
        tarkistaButton.SetActive(false);
        scoreText.gameObject.SetActive(false);

        // Reset all objects
        foreach (ResettableObject obj in resettableObjects)
        {
            obj.ResetObject();
        }
    }






}
