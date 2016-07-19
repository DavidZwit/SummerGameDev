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
    float chunckLength = 20;

    void Start()
    {
        chunckScripts = new IChunck[chuncks.Length];

        float spawnPos = -100;
        for (var i =0; i < chuncks.Length; i++) {
            GameObject chunck = Instantiate(chuncks[i], new Vector3(), new Quaternion()) as GameObject;
            chunckScripts[i] = chunck.GetComponent<IChunck>();

        }

        interChunckScript = new IChunck[5];
        for (int i = 5-1; i >= 0; i--) {

            GameObject currInterChunck = Instantiate(interChunck, new Vector3(), new Quaternion())as GameObject;
            interChunckScript[i] = currInterChunck.GetComponent<IChunck>();

            interChunckScript[i].Spawn(spawnPos, speed);
            spawnPos += chunckLength;
        }

        arrayCounter = chunckScripts.Length-1;
        interChunckCouter = interChunckScript.Length - 1;

        StartCoroutine(loop());
    }

    IEnumerator loop ()
    {
        while (true)
        {
            SpawnAChunck();
            yield return new WaitForSeconds(spawnTime / NonDestroyableData.GameSpeed);
        }
    }

    bool SpawnInterChunck = true;
    int arrayCounter;
    int interChunckCouter;

    void SpawnAChunck()
    {
        NonDestroyableData.GameSpeed /= 1.1f;
        if (SpawnInterChunck) {

            if (arrayCounter > 0) {
                interChunckScript[interChunckCouter].Spawn(0, speed);
                interChunckCouter--;
            } else {
                interChunckCouter = interChunckScript.Length-1;
                interChunckScript[0].Spawn(0, speed);
            }
        } else {

            if (arrayCounter > 0) {
                chunckScripts[arrayCounter].Spawn(0, speed);
                arrayCounter--;
            } else {
                arrayCounter = chunckScripts.Length-1;
                chunckScripts[0].Spawn(0, speed);
            }

        }
        SpawnInterChunck = !SpawnInterChunck;
            //spSpawnInterChunckawn logic
    }
}
