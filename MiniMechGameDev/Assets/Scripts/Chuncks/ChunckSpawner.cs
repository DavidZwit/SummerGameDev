using UnityEngine;
using System.Collections;

public class ChunckSpawner : MonoBehaviour {

    int spawnTime = 5;
    [SerializeField]
    GameObject[] chuncks;
    IChunck[] chunckScripts;

    void Start()
    {
        chunckScripts = new IChunck[chuncks.Length];

        for (var i = 0; i < chuncks.Length; i++) {
            GameObject chunck = Instantiate(chuncks[i], new Vector3(), new Quaternion()) as GameObject;
            chunckScripts[i] = chunck.GetComponent<IChunck>();
        }
        StartCoroutine(SpawnAChunck());
    }

    IEnumerator SpawnAChunck()
    {
        while (true)
        {
            chunckScripts[Random.Range(0, chunckScripts.Length)].Spawn(0, 0.5f);
            //spawn logic

            yield return new WaitForSeconds(spawnTime);

        }
    }
}
