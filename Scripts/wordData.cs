using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class wordData : MonoBehaviour
{
    [SerializeField]
    public Image charImage; 
    
    [SerializeField]
    private Text charText;

    [HideInInspector]
    public char charValue;

    public GameObject MainUI;
    public bool isRevealed = false;

    //change this to public when button for 'next level' is added
    private Button buttonObj;

    private void Awake()
    {
        buttonObj = GetComponent<Button>();

        if (buttonObj)
        {
            buttonObj.onClick.AddListener(() => CharSelected());
        }
    }

    public void SetChar(char value)
    {
        charText.text = value + " ";
        charValue = value;
    }

    private void CharSelected()
    {
        quizManager.instance.SelectedOption(this);
    }

}
