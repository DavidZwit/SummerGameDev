using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class PlayerPassLineTool : MonoBehaviour
{
    public bool enabled = true;
    private int playerCount = 2;
    private List<GameObject> players = new List<GameObject>();
    public LayerMask rayHit;

    private LineRenderer line;

    public void OnDrawGizmos()
    {
        if (enabled)
        {
            CheckCollision();
        }
    }

    private void GetPlayers()
    {
        if (players.Count >= 2) return;

        Debug.Log(players.Count);
        for (int i = 0; i < playerCount; i++)
        {
            players.Add( transform.GetChild(i).transform.gameObject );
        }
    }

    private void DisplayBeam()
    {
        GetPlayers();
        if (line == null) line = this.transform.GetComponent<LineRenderer>();

        line.enabled = true;
        line.SetWidth(.075f, .075f);

        line.SetPosition(0, players[0].transform.position);
        line.SetPosition(1, players[1].transform.position);
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
            {
                Gizmos.color = Color.red;
                float radius = .75f;
                Vector3 pos = hit.transform.position + new Vector3(0, radius/2);
                Gizmos.DrawSphere(pos, radius);
            }
        }

        // Debug.DrawRay(players[0].transform.position, direction);
    }

}