using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class quizManager : MonoBehaviour
{
    public static quizManager instance;

    public int score = 0;
    public int[] eachScore = new int[76];
    public int alpanumScore, salitaScore, pariralaScore;
    public int objectCounter = 0;
    public int revealHints = 0;
    public int trashHints = 0;
    public int currentDiff = 0;

    private Renderer rend;

    [SerializeField] private GameObject gameComplete;

    [SerializeField] private quizDataScriptable quiz;
    [SerializeField] private List<QuestionData> easyCopy, mediumCopy, difficultCopy;

    [SerializeField] private Text categ, scoreOverview, scoreOverview1, scoreOverview2;

    [SerializeField]
    private Image questionImage,
                                   questionImage1,
                                   signImage;
    [SerializeField] private VideoPlayer signAnim;
    [SerializeField]
    private Image questionImage2,
                                   questionImage3,
                                   zoomImage,
                                   zoomImage1;
    [SerializeField] private VideoPlayer zoomAnim;
    [SerializeField]
    private Image signZoom,
                                   zoomImage2,
                                   zoomImage3;

    [SerializeField] private wordData[] answerArray, hintArray, hintMed, hintEz;

    private char[] charArray = new char[28],
                   charMedArray = new char[16],
                   charEzArray = new char[8]; //store all the chars ---- set char[] to the number of options

    private int currentAnswerIdx = 0; //so you can populate answer field
    public int currentQuestionIdx = 0;
    private int j = 0;
    private int ezLength = 8, medLength = 16;

    private bool correctAnswer = true;
    private bool match = true;

    private List<int> selectedWordIdx;
    public string answerWord;

    public fuzzyController fController;

    private Gstat gameStatus = Gstat.Playing;

    //Sets game status to awake
    private void Awake()
    {
        if (instance == null) instance = this;
        else
            Destroy(gameObject);

        selectedWordIdx = new List<int>();
    }

    //Starts the game, creates a copy of quiz data
    private void Start()
    {
        easyCopy = new List<QuestionData>(quiz.easy);
        mediumCopy = new List<QuestionData>(quiz.medium);
        difficultCopy = new List<QuestionData>(quiz.difficult);
        setQuestion();
    }

    [SerializeField] public QuestionData.Difficulty currentDifficulty;

    //Setting each level
    private void setQuestion()
    {
        currentAnswerIdx = 0;
        selectedWordIdx.Clear();

        //Setting for Easy Level
        if (currentDifficulty == QuestionData.Difficulty.Easy)
        {
            if (score >= 91 && score <= 100)
            {
                 easyCopy.RemoveAt(currentQuestionIdx);

                if (mediumCopy.Count > 0)
                {
                    currentQuestionIdx = UnityEngine.Random.Range(0, mediumCopy.Count - 1);
                    currentDifficulty = QuestionData.Difficulty.Medium;
                }
                else
                {
                    if (difficultCopy.Count > 0)
                    {
                        currentQuestionIdx = UnityEngine.Random.Range(0, difficultCopy.Count - 1);
                        currentDifficulty = QuestionData.Difficulty.Difficult;
                    }
                    else
                    {
                        if (easyCopy.Count > 0)
                        {
                            currentQuestionIdx = UnityEngine.Random.Range(0, easyCopy.Count - 1);
                            currentDifficulty = QuestionData.Difficulty.Easy;
                        }
                    }

                }
            }
            else if (score >= 76 && score <= 90)
            {
                 easyCopy.RemoveAt(currentQuestionIdx);

                if (mediumCopy.Count > 0)
                {
                    currentQuestionIdx = UnityEngine.Random.Range(0, mediumCopy.Count - 1);
                    currentDifficulty = QuestionData.Difficulty.Medium;
                }
                else
                {
                    if (difficultCopy.Count > 0)
                    {
                        currentQuestionIdx = UnityEngine.Random.Range(0, difficultCopy.Count - 1);
                        currentDifficulty = QuestionData.Difficulty.Difficult;
                    }
                    else
                    {
                        if (easyCopy.Count > 0)
                        {
                            currentQuestionIdx = UnityEngine.Random.Range(0, easyCopy.Count - 1);
                            currentDifficulty = QuestionData.Difficulty.Easy;
                        }
                    }

                }
            }
            else if (score <= 75)
            {
                 easyCopy.RemoveAt(currentQuestionIdx);

                if (easyCopy.Count > 0)
                {
                    currentQuestionIdx = UnityEngine.Random.Range(0, easyCopy.Count - 1);
                    currentDifficulty = QuestionData.Difficulty.Easy;
                }
                else
                {
                    if (mediumCopy.Count > 0)
                    {
                        currentQuestionIdx = UnityEngine.Random.Range(0, mediumCopy.Count - 1);
                        currentDifficulty = QuestionData.Difficulty.Medium;
                    }
                    else
                    {
                        if (difficultCopy.Count > 0)
                        {
                            currentQuestionIdx = UnityEngine.Random.Range(0, difficultCopy.Count - 1);
                            currentDifficulty = QuestionData.Difficulty.Difficult;
                        }
                    }
                }
            }
        }
        
        //Setting for Medium Level
        else if (currentDifficulty == QuestionData.Difficulty.Medium)
        {
            if (score >= 91 && score <= 100)
            {
                mediumCopy.RemoveAt(currentQuestionIdx);

                if (difficultCopy.Count > 0)
                {
                    currentQuestionIdx = UnityEngine.Random.Range(0, difficultCopy.Count - 1);
                    currentDifficulty = QuestionData.Difficulty.Difficult;
                }
                else
                {
                    if (mediumCopy.Count > 0)
                    {
                        currentQuestionIdx = UnityEngine.Random.Range(0, mediumCopy.Count - 1);
                        currentDifficulty = QuestionData.Difficulty.Medium;
                    }
                    else
                    {
                        if (easyCopy.Count > 0)
                        {
                            currentQuestionIdx = UnityEngine.Random.Range(0, easyCopy.Count - 1);
                            currentDifficulty = QuestionData.Difficulty.Easy;
                        }
                    }
                }
            }
            else if (score >= 76 && score <= 90)
            {
                mediumCopy.RemoveAt(currentQuestionIdx);

                if (mediumCopy.Count > 0)
                {
                    currentQuestionIdx = UnityEngine.Random.Range(0, mediumCopy.Count - 1);
                    currentDifficulty = QuestionData.Difficulty.Medium;
                }
                else
                {
                    if (difficultCopy.Count > 0)
                    {
                        currentQuestionIdx = UnityEngine.Random.Range(0, difficultCopy.Count - 1);
                        currentDifficulty = QuestionData.Difficulty.Difficult;
                    }
                    else
                    {
                        if (easyCopy.Count > 0)
                        {
                            currentQuestionIdx = UnityEngine.Random.Range(0, easyCopy.Count - 1);
                            currentDifficulty = QuestionData.Difficulty.Easy;
                        }
                    }

                }
            }
            else if (score <= 75)
            {
                mediumCopy.RemoveAt(currentQuestionIdx);

                if (mediumCopy.Count > 0)
                {
                    currentQuestionIdx = UnityEngine.Random.Range(0, mediumCopy.Count - 1);
                    currentDifficulty = QuestionData.Difficulty.Easy;
                }
                else
                {
                    if (easyCopy.Count > 0)
                    {
                        currentQuestionIdx = UnityEngine.Random.Range(0, easyCopy.Count - 1);
                        currentDifficulty = QuestionData.Difficulty.Easy;
                    }
                    else
                    {
                        if (difficultCopy.Count > 0)
                        {
                            currentQuestionIdx = UnityEngine.Random.Range(0, difficultCopy.Count - 1);
                            currentDifficulty = QuestionData.Difficulty.Difficult;
                        }
                    }
                }
            }
        }
        
        //Setting for Difficult level
        else if (currentDifficulty == QuestionData.Difficulty.Difficult)
        {
            if (score >= 91 && score <= 100)
            {
                difficultCopy.RemoveAt(currentQuestionIdx);

                if (difficultCopy.Count > 0)
                {
                    currentQuestionIdx = UnityEngine.Random.Range(0, difficultCopy.Count - 1);
                    currentDifficulty = QuestionData.Difficulty.Difficult;
                }
                else 
                {
                    if (mediumCopy.Count > 0)
                    {
                        currentQuestionIdx = UnityEngine.Random.Range(0, mediumCopy.Count - 1);
                        currentDifficulty = QuestionData.Difficulty.Medium;
                    }
                    else
                    {
                        if (easyCopy.Count > 0)
                        {
                            currentQuestionIdx = UnityEngine.Random.Range(0, easyCopy.Count - 1);
                            currentDifficulty = QuestionData.Difficulty.Easy;
                        }
                    }

                }
               
            }
            else if (score >= 76 && score <= 90)
            {
                difficultCopy.RemoveAt(currentQuestionIdx);

                if (mediumCopy.Count > 0)
                {
                    currentQuestionIdx = UnityEngine.Random.Range(0, mediumCopy.Count - 1);
                    currentDifficulty = QuestionData.Difficulty.Medium;
                }
                else
                {
                    if (easyCopy.Count > 0)
                    {
                        currentQuestionIdx = UnityEngine.Random.Range(0, easyCopy.Count - 1);
                        currentDifficulty = QuestionData.Difficulty.Easy;
                    }
                    else 
                    {
                        currentQuestionIdx = UnityEngine.Random.Range(0, easyCopy.Count - 1);
                        currentDifficulty = QuestionData.Difficulty.Difficult;
                    }
                }
            }
            else if (score <= 75)
            {
                difficultCopy.RemoveAt(currentQuestionIdx);

                if (difficultCopy.Count > 0)
                {
                    currentQuestionIdx = UnityEngine.Random.Range(0, difficultCopy.Count - 1);
                    currentDifficulty = QuestionData.Difficulty.Easy;
                }
                else
                {
                    if (easyCopy.Count > 0)
                    {
                        currentQuestionIdx = UnityEngine.Random.Range(0, easyCopy.Count - 1);
                        currentDifficulty = QuestionData.Difficulty.Easy;
                    }
                    else
                    {
                        if (mediumCopy.Count > 0)
                        {
                            currentQuestionIdx = UnityEngine.Random.Range(0, mediumCopy.Count - 1);
                            currentDifficulty = QuestionData.Difficulty.Medium;
                        }
                    }
                }
            }
        }

        //Checking if all items are answered
        //Then gets the total score
        if ((easyCopy.Count == 0 && mediumCopy.Count == 0) && difficultCopy.Count == 0)
        {
            //Adds current score to total score for each level and its category
            foreach (QuestionData quizData in quiz.easy)
            {
                alpanumScore = alpanumScore + quizData.score;
            }
            foreach (QuestionData quizData in quiz.medium)
            {
                salitaScore = salitaScore + quizData.score;
            } 
            foreach (QuestionData quizData in quiz.difficult)
            {
                pariralaScore = pariralaScore + quizData.score;
            }  

            //Saves current total score for each level and its category
            scoreOverview.text = alpanumScore.ToString();
            scoreOverview1.text = salitaScore.ToString();
            scoreOverview2.text = pariralaScore.ToString();

            //Sets Game to Completed
            gameComplete.gameObject.SetActive(true);

            //Resets level score for each level and its category
            foreach (QuestionData quizData in quiz.easy)
            {
                alpanumScore = 0;
            }
            foreach (QuestionData quizData in quiz.medium)
            {
                salitaScore = 0;
            } 
            foreach (QuestionData quizData in quiz.difficult)
            {
                pariralaScore = 0;
            }  
            return;
        }

        //Sets all data for Easy
        if (currentDifficulty == QuestionData.Difficulty.Easy)
        {
            categ.text = easyCopy[currentQuestionIdx].categ.text;
            questionImage.sprite = easyCopy[currentQuestionIdx].questionImage;
            questionImage1.sprite = easyCopy[currentQuestionIdx].questionImage1;
            signImage.sprite = easyCopy[currentQuestionIdx].signImage;
            questionImage2.sprite = easyCopy[currentQuestionIdx].questionImage2;
            questionImage3.sprite = easyCopy[currentQuestionIdx].questionImage3;
            zoomImage.sprite = easyCopy[currentQuestionIdx].zoomImage;
            zoomImage1.sprite = easyCopy[currentQuestionIdx].zoomImage1;
            signZoom.sprite = easyCopy[currentQuestionIdx].signZoom;
            zoomImage2.sprite = easyCopy[currentQuestionIdx].zoomImage2;
            zoomImage3.sprite = easyCopy[currentQuestionIdx].zoomImage3;

            answerWord = easyCopy[currentQuestionIdx].answer;

            signImage.gameObject.SetActive(true);
            signZoom.gameObject.SetActive(true);
            signAnim.gameObject.SetActive(false);
            zoomAnim.gameObject.SetActive(false);
        }
        
        //Sets all data for Medium
        else if (currentDifficulty == QuestionData.Difficulty.Medium)
        {
            categ.text = mediumCopy[currentQuestionIdx].categ.text;
            questionImage.sprite = mediumCopy[currentQuestionIdx].questionImage;
            questionImage1.sprite = mediumCopy[currentQuestionIdx].questionImage1;
            signAnim.clip = mediumCopy[currentQuestionIdx].signAnim.clip;
            questionImage2.sprite = mediumCopy[currentQuestionIdx].questionImage2;
            questionImage3.sprite = mediumCopy[currentQuestionIdx].questionImage3;
            zoomImage.sprite = mediumCopy[currentQuestionIdx].zoomImage;
            zoomImage1.sprite = mediumCopy[currentQuestionIdx].zoomImage1;
            zoomAnim.clip = mediumCopy[currentQuestionIdx].signAnim.clip;
            zoomImage2.sprite = mediumCopy[currentQuestionIdx].zoomImage2;
            zoomImage3.sprite = mediumCopy[currentQuestionIdx].zoomImage3;

            answerWord = mediumCopy[currentQuestionIdx].answer;

            signImage.gameObject.SetActive(false);
            signZoom.gameObject.SetActive(false);
            signAnim.gameObject.SetActive(true);
            zoomAnim.gameObject.SetActive(true);
        }
        
        //Sets all data for Difficult
        else if (currentDifficulty == QuestionData.Difficulty.Difficult)
        {
            categ.text = difficultCopy[currentQuestionIdx].categ.text;
            questionImage.sprite = difficultCopy[currentQuestionIdx].questionImage;
            questionImage1.sprite = difficultCopy[currentQuestionIdx].questionImage1;
            signAnim.clip = difficultCopy[currentQuestionIdx].signAnim.clip;
            questionImage2.sprite = difficultCopy[currentQuestionIdx].questionImage2;
            questionImage3.sprite = difficultCopy[currentQuestionIdx].questionImage3;
            zoomImage.sprite = difficultCopy[currentQuestionIdx].zoomImage;
            zoomImage1.sprite = difficultCopy[currentQuestionIdx].zoomImage1;
            zoomAnim.clip = difficultCopy[currentQuestionIdx].signAnim.clip;
            zoomImage2.sprite = difficultCopy[currentQuestionIdx].zoomImage2;
            zoomImage3.sprite = difficultCopy[currentQuestionIdx].zoomImage3;

            answerWord = difficultCopy[currentQuestionIdx].answer;

            signImage.gameObject.SetActive(false);
            signZoom.gameObject.SetActive(false);
            signAnim.gameObject.SetActive(true);
            zoomAnim.gameObject.SetActive(true);
        }

        resetQuestion();

        objectCounter = 0; //Fuzzy Variable for wrong answer
        revealHints = 0;   //Fuzzy Variable for hints used either reveal a letter
        trashHints = 0;    //Fuzzy Variable for hints used either remove a letter

        //Sets letter choices for Easy
        if (currentDifficulty == QuestionData.Difficulty.Easy)
        {
            for (int i = 0; i < answerWord.Length; i++)
            {
                charEzArray[i] = answerWord[i];
            }

            for (int i = answerWord.Length; i < ezLength; i++)
            {
                charEzArray[i] = (char)UnityEngine.Random.Range(65, 91);
            }

            charEzArray = ShuffleList.ShuffleListItems<char>(charEzArray.ToList()).ToArray();


            for (int i = 0; i < ezLength; i++)
            {
                hintArray[i].SetChar(charEzArray[i]);
            }
        }
        
        //Sets letter choices for Medium
        else if (currentDifficulty == QuestionData.Difficulty.Medium)
        {
            for (int i = 0; i < answerWord.Length; i++)
            {
                charMedArray[i] = answerWord[i];
            }

            for (int i = answerWord.Length; i < medLength; i++)
            {
                charMedArray[i] = (char)UnityEngine.Random.Range(65, 91);
            }

            charMedArray = ShuffleList.ShuffleListItems<char>(charMedArray.ToList()).ToArray();


            for (int i = 0; i < medLength; i++)
            {
                hintArray[i].SetChar(charMedArray[i]);
            }
        }
        
        //Sets letter choices for Difficult
        else if (currentDifficulty == QuestionData.Difficulty.Difficult)
        {
            for (int i = 0; i < answerWord.Length; i++)
            {
                charArray[i] = answerWord[i];
            }

            for (int i = answerWord.Length; i < hintArray.Length; i++)
            {
                charArray[i] = (char)UnityEngine.Random.Range(65, 91);
            }

            charArray = ShuffleList.ShuffleListItems<char>(charArray.ToList()).ToArray();


            for (int i = 0; i < hintArray.Length; i++)
            {
                hintArray[i].SetChar(charArray[i]);
            }
        }

        //set status to playing
        gameStatus = Gstat.Playing;
    }

    //populate answer field
    //Checks user answer
    public void SelectedOption(wordData WordData)
    {
        if (gameStatus == Gstat.Next || currentAnswerIdx >= answerWord.Length) return;

        selectedWordIdx.Add(WordData.transform.GetSiblingIndex());
        answerArray[currentAnswerIdx].SetChar(WordData.charValue);
        WordData.gameObject.SetActive(false);
        currentAnswerIdx++;

        if (currentAnswerIdx >= answerWord.Length)
        {
            correctAnswer = true;

            for (int i = 0; i < answerWord.Length; i++)
            {
                if (char.ToUpper(answerWord[i]) != char.ToUpper(answerArray[i].charValue))
                {
                    correctAnswer = false;
                    break;
                }
            }

            if (correctAnswer)
            {
                gameStatus = Gstat.Next;

                Invoke("setQuestion", 0.5f);

                //Sends fuzzy variables to Fuzzy Controller for Easy level score
                if (currentDifficulty == QuestionData.Difficulty.Easy)
                {
                    score = fController.nextLvlManager(easyCopy[currentQuestionIdx], revealHints, trashHints, objectCounter, 25, 5);

                    foreach (QuestionData qData in quiz.easy)
                    {
                        if (qData.answer == easyCopy[currentQuestionIdx].answer)
                        {
                            qData.score = score;
                        }
                    }
                }
                
                //Sends fuzzy variables to Fuzzy Controller for Medium level score
                else if (currentDifficulty == QuestionData.Difficulty.Medium)
                {
                    score = fController.nextLvlManager(mediumCopy[currentQuestionIdx], revealHints, trashHints, objectCounter, 10, 4);

                    foreach (QuestionData qData in quiz.medium)
                    {
                        if (qData.answer == mediumCopy[currentQuestionIdx].answer)
                        {
                            qData.score = score;
                        }
                    }
                }
                
                //Sends fuzzy variables to Fuzzy Controller for Difficult level score
                else if (currentDifficulty == QuestionData.Difficulty.Difficult)
                {
                    score = fController.nextLvlManager(difficultCopy[currentQuestionIdx], revealHints, trashHints, objectCounter, 2, 3);

                   foreach (QuestionData qData in quiz.difficult)
                    {
                        if (qData.answer == difficultCopy[currentQuestionIdx].answer)
                        {
                            qData.score = score;
                        }
                    }
                }

                j = 0; //Resets counter for trash() function
            }
            else if (!correctAnswer)
            {
                objectCounter++; //Fuzzy Variable for wrong input
                
            }
        }

        eachScore[currentQuestionIdx] = score;
    }

    //Resets answer and hint data for next level
    private void resetQuestion()
    {

        for (int i = 0; i < answerArray.Length; i++)
        {
            answerArray[i].gameObject.SetActive(true);
            answerArray[i].SetChar('_');
        }

        for (int i = answerWord.Length; i < answerArray.Length; i++)
        {
            answerArray[i].gameObject.SetActive(false);
        }

        //For Easy
        if (currentDifficulty == QuestionData.Difficulty.Easy)
        {
            for (int i = 0; i < ezLength; i++)
            {
                hintArray[i].gameObject.SetActive(true);
            }
            for (int i = ezLength; i < hintArray.Length; i++)
            {
                hintArray[i].gameObject.SetActive(false);
            }
        }
        
        //For Medium
        else if (currentDifficulty == QuestionData.Difficulty.Medium)
        {
            for (int i = 0; i < medLength; i++)
            {
                hintArray[i].gameObject.SetActive(true);
            }
            for (int i = medLength; i < hintArray.Length; i++)
            {
                hintArray[i].gameObject.SetActive(false);
            }
        }
        
        //For Difficult
        else
        {
            for (int i = 0; i < hintArray.Length; i++)
            {
                hintArray[i].gameObject.SetActive(true);
            }
        }

        //Loop to set gameobjects to white after it is used from hint object
        for (int i = 0; i <= hintArray.Length - 1; i++)
        {
            hintArray[i].charImage.GetComponent<Image>().color = Color.white;
            hintArray[i].isRevealed = false;
        }
    }

    //Removes recently added letter from answer field
    public void backspace()
    {
        if (currentDifficulty == QuestionData.Difficulty.Easy)
        {
            if (selectedWordIdx.Count > 0)
            {
                int idx = selectedWordIdx[selectedWordIdx.Count - 1];
                hintEz[idx].gameObject.SetActive(true);
                selectedWordIdx.RemoveAt(selectedWordIdx.Count - 1);
                currentAnswerIdx--;
                answerArray[currentAnswerIdx].SetChar('_');
            }
        }
        else if (currentDifficulty == QuestionData.Difficulty.Medium)
        {
            if (selectedWordIdx.Count > 0)
            {
                int idx = selectedWordIdx[selectedWordIdx.Count - 1];
                hintMed[idx].gameObject.SetActive(true);
                selectedWordIdx.RemoveAt(selectedWordIdx.Count - 1);
                currentAnswerIdx--;
                answerArray[currentAnswerIdx].SetChar('_');
            }
        }
        else if (currentDifficulty == QuestionData.Difficulty.Difficult)
        {
            if (selectedWordIdx.Count > 0)
            {
                int idx = selectedWordIdx[selectedWordIdx.Count - 1];
                hintArray[idx].gameObject.SetActive(true);
                selectedWordIdx.RemoveAt(selectedWordIdx.Count - 1);
                currentAnswerIdx--;
                answerArray[currentAnswerIdx].SetChar('_');
            }
        }
    }
    
    //Reveals a letter from the answer in the selection field
    public void reveal()
    {
        //change object color
        //get value of answerArray
        //if value of hintArray == value of answerArray
        //display/change the color of the revealed letter

        for (int i = 0; i <= hintArray.Length - 1; i++)
        {
            if (hintArray[i].gameObject.activeSelf == true)
            {
                if (answerWord.Contains(hintArray[i].charValue))
                {
                    if (hintArray[i].isRevealed == false)
                    {
                        hintArray[i].charImage.GetComponent<Image>().color = Color.green;
                        hintArray[i].isRevealed = true;
                        revealHints++;
                        return;
                    }
                }
            }
        }
    }

    //Removes a letter from the choices excluding letters from the answer
    public void trash()
    {
        for (int i = 0; i <= hintArray.Length - 1; i++)
        {
            if (hintArray[i].gameObject.activeSelf == true)
            {
                if (!answerWord.Contains(hintArray[i].charValue))
                {
                    hintArray[i].gameObject.SetActive(false);
                    trashHints++;
                    return;
                }
            }
        }
    }
    
    //Saves game data
    public void saveData()
    {
        saveSystem.Savedata(this);
    }

    //Loads game data
    public void LoadPlayer()
    {
        playerData data = saveSystem.LoadPlayer();

        currentQuestionIdx = data.currentQuestionIdx;
        score = data.score;
        for (int i = 0; i < 76; i++)
        {
            eachScore[i] = data.eachScore[i];
        }
    }
}

//Class for data of one item
[System.Serializable]
public class QuestionData
{
    public enum Difficulty
    {
        Easy,
        Medium,
        Difficult
    }

    public Text categ, scoreAlpaNum, scoreSalita, scoreParirala;
    public Sprite questionImage,
                        questionImage1,
                        signImage;
    public VideoPlayer signAnim;
    public Sprite questionImage2,
                        questionImage3,
                        zoomImage,
                        zoomImage1,
                        signZoom;
    public VideoPlayer zoomAnim;
    public Sprite zoomImage2,
                        zoomImage3;
    public string answer;

    public bool isDone = false;
    public Difficulty difficulty;

    public int score = 0;
}

//Function for game
public enum Gstat
{
    Playing,
    Next
}
