using UnityEngine;
using System.Collections;

public class AccountCreator : MonoBehaviour {

    string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    void OnDestroy ()
    {
        Account newAccound = new Account(0, name);
        NonDestroyableData.players.Add(newAccound);
        NonDestroyableData.currPlayer = newAccound;
    }
}
