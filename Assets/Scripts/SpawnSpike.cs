using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpike : MonoBehaviour
{
    public GameObject spike;
    public float respawnTime = 1.0f;
    void Start()
    {
        StartCoroutine(spikeWave());
    }
    private void spawnSpike()
    {
        GameObject a= Instantiate(spike) as GameObject;
        a.transform.position = new Vector2(Random.Range(11.0f,17.0f),-3.5f);
        
    }
    // Update is called once per frame
    
    IEnumerator spikeWave()
    {
        while(true){
            yield return new WaitForSeconds(respawnTime);
        spawnSpike();
        }
    }
}
