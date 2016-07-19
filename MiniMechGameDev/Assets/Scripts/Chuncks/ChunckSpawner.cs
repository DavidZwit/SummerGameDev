using UnityEngine;
using System.Collections;

public class ChunckSpawner : MonoBehaviour {

    [SerializeField]
    GameObject[] chuncks;
    IChunck[] chunckScripts;

    [SerializeField]
    GameObject interChunck;
    IChunck[] interChunckScript;


    [SerializeField]
    int spawnTime = 1;
    [SerializeField]
    float speed = 15;

    void Start()
    {
        chunckScripts = new IChunck[chuncks.Length];

        for (var i = 0; i < chuncks.Length; i++) {
            GameObject chunck = Instantiate(chuncks[i], new Vector3(), new Quaternion()) as GameObject;
            chunckScripts[i] = chunck.GetComponent<IChunck>();
        }

        interChunckScript = new IChunck[20];
        for (int i = 0; i < 20; i++) {

            GameObject currInterChunck = Instantiate(interChunck, new Vector3(), new Quaternion())as GameObject;
            interChunckScript[i] = currInterChunck.GetComponent<IChunck>();
        }

        arrayCounter = chunckScripts.Length-1;
        interChunckCouter = interChunckScript.Length - 1;
    }


    void FixedUpdate()
    {
        if (Time.time % spawnTime == 0) {
            SpawnAChunck();
        }
    }

    bool SpawnInterChunck = false;
    int arrayCounter;
    int interChunckCouter;

    void SpawnAChunck()
    {
        if (SpawnInterChunck) {

            if (arrayCounter >= 0) {
                interChunckScript[interChunckCouter].Spawn(0, speed);
                interChunckCouter--;
            } else interChunckCouter = interChunckScript.Length-1;

        } else {

            if (arrayCounter >= 0) {
                chunckScripts[arrayCounter].Spawn(0, speed);
                arrayCounter--;
            } else {
                arrayCounter = chunckScripts.Length-1;
            }

        }
        SpawnInterChunck = !SpawnInterChunck;
            //spSpawnInterChunckawn logic
    }
}
