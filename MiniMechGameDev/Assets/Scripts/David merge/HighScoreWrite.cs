using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class HighScoreWrite : MonoBehaviour {

    void Start()
    {
        Text highscoreText = gameObject.GetComponent<Text>();
        SortPlayers.GuaranteedInstance.Sort();

        foreach (KeyValuePair<string, int> dick in NonDestroyableData.players.Reverse())
        {
            highscoreText.text += dick;
            highscoreText.text += "\n";
        }
    }
}
