using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class playerData
{
    public int currentQuestionIdx;
    public int score;
    public int[] eachScore;

    public playerData (quizManager QuizManager)
    {
        currentQuestionIdx = QuizManager.currentQuestionIdx;
        score = QuizManager.score;
        for (int i = 0; i < 75; i++)
        {
            eachScore[i] = QuizManager.eachScore[i];
        }
    }


}
