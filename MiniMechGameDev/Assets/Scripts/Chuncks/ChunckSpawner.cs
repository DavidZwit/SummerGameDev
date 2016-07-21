using UnityEngine;
using System.Collections;

public class ChunckSpawner : MonoBehaviour {

    [SerializeField]
    GameObject[] chuncks;
    IChunck[] chunckScripts;
    public LayerMask chunkMask;

    [SerializeField]
    GameObject interChunck;
    IChunck[] interChunckScript;

    [SerializeField]
    int amoundOfInterChuncks = 10;

    [SerializeField]
    int spawnTime = 1;
    [SerializeField]
    float speed;
    float chunckLength = 20;

    void Start()
    {
        chunckScripts = new IChunck[chuncks.Length];

        float spawnPos = -chunckLength * amoundOfInterChuncks;
        for (var i =0; i < chuncks.Length; i++) {
            GameObject chunck = Instantiate(chuncks[i], new Vector3(), new Quaternion()) as GameObject;
            chunckScripts[i] = chunck.GetComponent<IChunck>();
            chunckScripts[i].Spawn(-800, speed);
        }

        interChunckScript = new IChunck[amoundOfInterChuncks];
        for (int i = interChunckScript.Length-1; i >= 0; i--) {

            GameObject currInterChunck = Instantiate(interChunck, new Vector3(), new Quaternion())as GameObject;
            interChunckScript[i] = currInterChunck.GetComponent<IChunck>();

            if (i != interChunckScript.Length -1) interChunckScript[i].Spawn(spawnPos, speed);

            currInterChunck.transform.position = new Vector3(0, 0, spawnPos);
            spawnPos += chunckLength;
        }

        arrayCounter = chunckScripts.Length-1;
        interChunckCouter = interChunckScript.Length - 1;
    }

    void OnDrawGizmos()
    {

        Gizmos.DrawCube(new Vector3(0, 0, 5), new Vector3(2, 2, 10));
    }

    void Update()
    {
        Collider[] ObjectsInSpawnPoint = Physics.OverlapBox(new Vector3(0, 0, 5), new Vector3(2, 2, 6.75f), new Quaternion(), chunkMask);

        if (ObjectsInSpawnPoint.Length <= 0) {
            if (SpawnInterChunck) {
                SpawnInterchunck();
            } else {
                SpawnObstacleChunck();
            }
            SpawnInterChunck = !SpawnInterChunck;
        }

    }


    /*
    float startTime,
            timeLeft;
    float timeOffset;
    bool countOffset;
    
    void FixedUpdate()
    {

        if (NonDestroyableData.GameSpeed != 1) {

            countOffset = true;

        } else countOffset = false;

        if (timeLeft - startTime > spawnTime / NonDestroyableData.GameSpeed) {  
            SpawnAChunck();
            timeLeft = startTime = Time.time;
        } else {
            timeLeft += Time.deltaTime;
            //countOffset += 
        }
    }
    */
    bool SpawnInterChunck = true;
    int arrayCounter;
    int interChunckCouter;
    bool gameStarted = false;

    void SpawnAChunck()
    {
        
            //spSpawnInterChunckawn logic
    }

    void SpawnInterchunck()
    {
        if (interChunckCouter > 0)
        {
            interChunckScript[interChunckCouter].Spawn(0, speed);
            interChunckCouter--;
        }
        else
        {
            interChunckCouter = interChunckScript.Length - 1;
            interChunckScript[0].Spawn(0, speed);
        }
    }

    void SpawnObstacleChunck ()
    {
           if (arrayCounter > 0)
           {
               chunckScripts[arrayCounter].Spawn(0, speed);
               arrayCounter--;
               if (gameStarted)
                   NonDestroyableData.currentChunck = chunckScripts[arrayCounter];
           } else {
               chunckScripts[0].Spawn(0, speed);
               arrayCounter = chunckScripts.Length - 1;
               NonDestroyableData.currentChunck = chunckScripts[chunckScripts.Length - 1];

               gameStarted = true;
           }
    }
}
