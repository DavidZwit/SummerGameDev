using UnityEngine;
using System.Collections;

public class ScoreManager : Singleton<ScoreManager>
{
    [Range(1,5)]
    public int SmallScore = 1;
    [Range(5,25)]
    public int BigScore = 5;

    public Score Scores;

    void Start()
    {
        int i = ScoreManager.Instance.Scores.CurrScore;
        NonDestroyableData.currPlayer = NonDestroyableData.names[NonDestroyableData.nameCounter++];
    }

}
