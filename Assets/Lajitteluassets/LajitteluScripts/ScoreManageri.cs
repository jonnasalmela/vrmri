using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script stores and updates the players score
// attach to empty game object in scene

public class ScoreManageri : MonoBehaviour
{
    //current player score
    public int score = 0;

    // Adds or removes score
    // Positive number = add score
    // Negative number = remove score
    public void AddScore(int amount)
    {
        score += amount;
        
        Debug.Log("Score: " + score);
    }
}