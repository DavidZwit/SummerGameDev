using System.Collections.Generic;
using System;

public struct NonDestroyableData
{
    public static List<Account> players = new List<Account>();
    public static Account currPlayer;
    
    void SortPlayers()
    {
           
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