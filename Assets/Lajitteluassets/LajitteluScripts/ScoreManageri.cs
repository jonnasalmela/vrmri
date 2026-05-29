using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManageri : MonoBehaviour
{
    public int score = 0;

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }
}