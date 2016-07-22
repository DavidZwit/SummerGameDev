using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticleSpawner : Singleton<ParticleSpawner>
{

    public List<GameObject> particlesList;

    public void SpawnParticle(Vector3 pos, GameObject particle)
    {
        GameObject p = GameObject.Instantiate(particle);
        p.transform.name = particle.transform.name;

        p.transform.position = pos;
    }

}
