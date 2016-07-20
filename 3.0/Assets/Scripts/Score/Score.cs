using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class Score
{

    public Score()
    {
        int currScore = 0;
    }

    private int currScore;
    public int CurrScore
    {
        get { return currScore; }
        set { currScore = value; }
    }

    public void AddToScore(int i)
    {
        CurrScore += i;
    }

    private int highScore;
    public int HighScore
    {
        get { return highScore; }
        set { highScore = value; }
    }

}