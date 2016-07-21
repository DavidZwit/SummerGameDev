using System.Collections.Generic;
using System;
using System.Linq;

public struct NonDestroyableData
{
    public static float GameSpeed = 1;
    public static IChunck currentChunck;
	public static float playerOneValue = 0f;
	public static float playerTwoValue = 0f;

    public static Dictionary<string, Account> players = new Dictionary<string, Account>();
    public static Account currPlayer;
    
    void SortPlayers()
    {
        List<string> keyList = players.Keys.ToList();
        Dictionary<string, Account> sortedDictionary = new Dictionary<string, Account>();
        foreach (string key in keyList) {
            sortedDictionary.Add(key, players[key]);
        }

        players = sortedDictionary;

    }
}

public struct Account
{
    int score;
    string name;

    public int Score
    {
        get { return score; }
        set {  score = value; }
    }

    public string Name
    {
        get { return name; }
        set {
            if (value.Length < 10)
                name = value;
            else name = "My name is really long";
        }
    }

    public Account(int _score, string _name)
    {
        score = _score;
        name = _name;
    }
    
}