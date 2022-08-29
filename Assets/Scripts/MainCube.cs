using System;
using UnityEngine;
using UnityEngine.UI;

public class MainCube : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject youWin;
    public Text youWinScore;
    public Text gameCurrency;
    private int score;
    private int prevScore;

    private void Awake()
    {
        score = PlayerPrefs.GetInt("Score");
        prevScore = PlayerPrefs.GetInt("Score");
        gameCurrency.text = score.ToString();
    }

    public void addScore()
    {
        score++;
        PlayerPrefs.SetInt("Score", score);
        gameCurrency.text = score.ToString();
    }
    public void killHer()
    {
        gameObject.GetComponent<MainCubeMoving>().direction = 0;
        gameOver.SetActive(true);
    }

    public void youWinWithX(int x)
    {
        gameObject.GetComponent<MainCubeMoving>().direction = 0;
        youWinScore.text = "Score : +" + (score - prevScore) * x;
        PlayerPrefs.SetInt("Score", prevScore + (score - prevScore) * x);
        youWin.SetActive(true);
    }
}
