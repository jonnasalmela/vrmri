using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This stores scoring state for interactable objects.
// attach this script to all interactable objects


public class ScorableObject : MonoBehaviour
{
    //tracks whether object has already given score
    public bool hasScored = false;
}