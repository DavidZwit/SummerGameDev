using System.Collections.Generic;
using System;
using System.Linq;

public struct NonDestroyableData
{
    public static float GameSpeed = 1;
    public static IChunck currentChunck;
    public static float playerOneValue = 0f;
    public static float playerTwoValue = 0f;

    public static Dictionary<string, int> players = new Dictionary<string, int>();
    public static string currPlayer;

    public static int nameCounter = 0;
    public static string[] names = new string[] {
        "Messi",
        "Ronaldo",
        "Rondaldinio",
        "Huntelaar",
        "Robben",
        "Sneijder",
        "Wijnaldum",
        "de Jong",
        "Kuyt",
        "Clasie",
        "Bazoer",
        "Bruma",
        "Promes",
        "Kongolo",
        "Klaassen",
        "Blind"
    };

}

public class SortPlayers : Singleton<SortPlayers>
{

    public void Sort()
    {
        Dictionary<string, int> sortedDic = new Dictionary<string, int>();
        foreach (KeyValuePair<string, int> player in NonDestroyableData.players.OrderBy(i => i.Value))
        {
            sortedDic.Add(player.Key, player.Value);
        }
        NonDestroyableData.players = sortedDic;

    }

}

public struct Account
{
    int score;
    string name;

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public string Name
    {
        get { return name; }
        set
        {
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