using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
   public void nextLevel()
    {
        int curLev = SceneManager.GetActiveScene().buildIndex;
        if (curLev == 4)
        {
            SceneManager.LoadScene(2);
        }
        else 
        {
            SceneManager.LoadScene(curLev + 1); 
        }
    }

    public void retryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
