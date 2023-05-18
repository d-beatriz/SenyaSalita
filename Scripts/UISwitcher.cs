using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISwitcher : MonoBehaviour
{
   public GameObject UItoActive;
   public GameObject UItoInactive;

   public GameObject resettoActive;
   public GameObject resettoInactive;

    //Sets UI to Active
    public void setUIactive()
    {
        UItoActive.SetActive(true);
        UItoInactive.SetActive(false);
    }

    //Resets UI for Tutorial
    public void ResetUI ()
    {
        resettoActive.SetActive(true);
        resettoInactive.SetActive(false);
    }

    //Restarts Game
    public void restartScene ()
    {
        SceneManager.LoadScene("Scene");
    }

    //Exits Game
    public void exitGame ()
    {
        Application.Quit();
        Debug.Log("Game Ended!");
    }
}
