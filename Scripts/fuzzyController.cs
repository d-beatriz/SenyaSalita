using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuzzyController : MonoBehaviour
{
    //Function to calculate a Fuzzy Score for the Manager
    public int nextLvlManager(QuestionData qData, int revealHints, int trashHints, int objectCounter, int revealScoremultiplier, int trashScoremultiplier)
    {
        int calScore;
     
            calScore = 100 - ((revealHints * revealScoremultiplier) + (trashHints * trashScoremultiplier) + (objectCounter * 2));

            calScore = Mathf.Clamp(calScore,10,100);

            return calScore;
    }
}
