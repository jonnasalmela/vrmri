using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This controls the gameplay UI, (level progression, and game reset logic.(WIP))
//
// This script handles:
//  - showing/hiding UI
//  - seperates gameplay into sets (images not all spawning at once)
//  - switching between object sets 
//  - checking when game is completed
//  - resetting the game
// 
// In inspector assign:
//  - Set1 and Set2 parent objects
//  - all buttons
//  - Score Text
//  - ScoreManageri
//  - ResettableObjects
//



public class UIManageri : MonoBehaviour
{
    public GameObject set1;
    public GameObject set2;

    public GameObject nextButton;     
    public GameObject backButton;
    public GameObject tarkistaButton;  //button for showing score

    public TextMeshProUGUI scoreText;

    public ScoreManageri scoreManager;

    //for returning objects back to their original location
    public ResettableObject[] resettableObjects;

    // First set socket count
    // unlocks progression to the second set
    public int firstSetFilled = 0;

    // Total sockets currently filled
    public int totalFilled = 0;

    // Total sockets in whole game
    public int totalSockets = 8;


    // Called when ANY socket gets an object
    public void SocketFilled()
    {
        totalFilled++;

        // First 3 sockets filled -> show Next button
        if (firstSetFilled < 3)
        {
            firstSetFilled++;

            if (firstSetFilled >= 3)
            {
                nextButton.SetActive(true); 
            }
        }

        // All sockets filled -> show Tarkista
        if (totalFilled >= totalSockets)
        {
            tarkistaButton.SetActive(true);
        }
    }

    // Called when object removed from socket
    public void SocketEmptied()
    {
        totalFilled--;

        // Hide Tarkista if not all filled anymore
        if (totalFilled < totalSockets)
        {
            tarkistaButton.SetActive(false);
        }
    }

    // shows second set
    public void ShowSet2()
    {
        Debug.Log("Next button pressed");

        set1.SetActive(false);
        set2.SetActive(true);

        Debug.Log("Set1 active: " + set1.activeSelf);
        Debug.Log("Set2 active: " + set2.activeSelf);

        nextButton.SetActive(false);
        backButton.SetActive(true);
    }

    // First set
    public void ShowSet1()
    {
        set1.SetActive(true);
        set2.SetActive(false);

        backButton.SetActive(false);

        // Keep Next visible after unlock
        if (firstSetFilled >= 3)
        {
            nextButton.SetActive(true);
        }
    }

    //show score
    //called by Tarksista button
    public void OnTarkistaPressed()
    {
        scoreText.gameObject.SetActive(true);

        //show final score
        scoreText.text = "Sait oikein: " + scoreManager.score +"!";
    }

    // Resets game for a new play session
    public void ResetGame()
    {
        // Reset score
        scoreManager.score = 0;

        // Reset counters
        totalFilled = 0;
        firstSetFilled = 0;

        // Reset all draggable objects
        foreach (ResettableObject obj in resettableObjects)
        {
            obj.ResetObject();
        }

        // Show first set
        set1.SetActive(true);

        // Hide second set
        set2.SetActive(false);

        //buttons only appear through game progression
        nextButton.SetActive(false);
        backButton.SetActive(false);
        tarkistaButton.SetActive(false);

        //prevents old results from remaining visible during new playthrough
        scoreText.gameObject.SetActive(false);
    }
}







