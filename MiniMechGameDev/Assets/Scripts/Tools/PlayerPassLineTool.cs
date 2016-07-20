using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class PlayerPassLineTool : Singleton<PlayerPassLineTool>
{
    public bool enabled = true;
    private int playerCount = 2;
    
    public List<GameObject> Players
    {
        get
        {
            return players;
        }
    }
    private List<GameObject> players = new List<GameObject>();
    public LayerMask rayHit;

    public int CurrentPlayer
    {
        get { return currentPlayer; }
        set { currentPlayer = value; }
    }
    private int currentPlayer = -1;

    private LineRenderer line;

    public Vector2 offset = new Vector2(0,0);

    #if UNITY_EDITOR
    public void OnDrawGizmos()
    {
        if (enabled)
            CheckCollision();
    }
    #endif

    void Awake()
    {
        GetPlayers();
    }

    private void GetPlayers()
    {
        if (players.Count >= 2) return;

        PlayerInfo[] p = FindObjectsOfType<PlayerInfo>();
        int PlayerInfoCount = p.Length;

        for (int i = 0; i < 2; i++)
        {
            if (p[i] == null) Debug.Log("Missing a player object");
            players.Add(p[i].transform.gameObject);
        }
        /*
        for (int i = 0; i < playerCount; i++)
        {
            players.Add( transform.GetChild(i).transform.gameObject );
        }*/
    }

    private void DisplayBeam()
    {
        GetPlayers();
        if (line == null) line = this.transform.GetComponent<LineRenderer>();

        line.enabled = true;
        line.SetWidth(1f, 1f);

        line.SetPosition(0, players[0].transform.position);
        line.SetPosition(1, players[1].transform.position);

        if (offset.x <= 1 && offset.x >= -1)
            offset.x += .075f;
        else
            offset.x = 0;

        this.transform.GetComponent<Renderer>().material.mainTextureScale = new Vector2(3 * currentPlayer, 1);
        this.transform.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);
    }

    void Update()
    {
        DisplayBeam();
    }

    private void CheckCollision()
    {
        RaycastHit hit;
        Vector3 direction = (players[1].transform.position - players[0].transform.position);
        if( Physics.Raycast(players[0].transform.position, direction, out hit) )
        {
            if(hit.collider.transform.gameObject.tag.Contains("Obstacle"))
                SetBeamColor(Color.red);

            return;
        }

        SetBeamColor(Color.green);
    }

    void SetBeamColor(Color c)
    {
        Debug.Log("Set a color: " + c);
        this.transform.GetComponent<Renderer>().material.color = c;
    }

}