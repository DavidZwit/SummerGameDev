using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public bool GodMode;

    void Start()
    {
        if (!GodMode) return;
        for (int i = 0; i < PlayerPassLineTool.Instance.players.Count; i++)
        {
            PlayerPassLineTool.Instance.players[i].GetComponent<CapsuleCollider>().enabled = false;
        }

        FindObjectOfType<Ball>().GetComponent<SphereCollider>().enabled = false;
        
    }
}
