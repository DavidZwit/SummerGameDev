using UnityEngine;
using System.Collections;

public class ChunckSpawner : MonoBehaviour {

    [SerializeField]
    GameObject[] chunks;
    IChunck[] chunkScripts;
    public LayerMask chunkMask;

    [SerializeField]
    GameObject interChunck;
    IChunck[] interChunkScript;

    [SerializeField]
    int amoundOfInterChuncks = 10;

    [SerializeField]
    int spawnTime = 1;
    [SerializeField]
    float speed;
    float chunckLength = 20;

    private GameObject chunkHolder;
    public GameObject ChunkHolder
    {
        get
        {
            if (chunkHolder == null)
            {
                chunkHolder = new GameObject();
                chunkHolder.transform.parent = this.transform;
                chunkHolder.transform.name = "ChunkHolder";
            }

            return chunkHolder;
        }
    }

    void Start()
    {
        chunkScripts = new IChunck[chunks.Length];

        float spawnPos = -chunckLength * amoundOfInterChuncks + 1;
        for (var i =0; i < chunks.Length; i++) {
            GameObject chunk = Instantiate(chunks[i], new Vector3(), new Quaternion()) as GameObject;
            chunk.transform.name = "Chunk_" + (i+1);
            chunk.transform.parent = ChunkHolder.transform;
            chunkScripts[i] = chunk.GetComponent<IChunck>();
            chunkScripts[i].Spawn(-800, speed);
        }

        interChunkScript = new IChunck[amoundOfInterChuncks];
        for (int i = interChunkScript.Length-1; i >= 0; i--) {

            GameObject currInterChunck = Instantiate(interChunck, new Vector3(), new Quaternion())as GameObject;
            currInterChunck.transform.name = "Chunk_" + (i+1);
            currInterChunck.transform.parent = ChunkHolder.transform;
            interChunkScript[i] = currInterChunck.GetComponent<IChunck>();

            if (i != interChunkScript.Length -1) interChunkScript[i].Spawn(spawnPos, speed);

            currInterChunck.transform.position = new Vector3(0, 0, spawnPos);
            spawnPos += chunckLength;
        }

        arrayCounter = chunkScripts.Length-1;
        interChunckCouter = interChunkScript.Length - 1;
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
            interChunkScript[interChunckCouter].Spawn(0, speed);
            interChunckCouter--;
        }
        else
        {
            interChunckCouter = interChunkScript.Length - 1;
            interChunkScript[0].Spawn(0, speed);
        }
    }

    void SpawnObstacleChunck ()
    {
           if (arrayCounter > 0)
           {
               chunkScripts[arrayCounter].Spawn(0, speed);
               arrayCounter--;
               if (gameStarted)
                   NonDestroyableData.currentChunck = chunkScripts[arrayCounter];
           } else {
               chunkScripts[0].Spawn(0, speed);
               arrayCounter = chunkScripts.Length - 1;
               NonDestroyableData.currentChunck = chunkScripts[chunkScripts.Length - 1];

               gameStarted = true;
           }
    }
}
