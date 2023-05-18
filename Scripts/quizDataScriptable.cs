using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "questionData", menuName = "questionData", order = 1)]
public class quizDataScriptable : ScriptableObject
{
    public List<QuestionData> easy;
    public List<QuestionData> medium;
    public List<QuestionData> difficult;
}
