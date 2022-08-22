using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakiSpawner : MonoBehaviour
{
    public GameObject bakiPrefab;
     private Transform target;
    public float spawnRate;
    private float timeAfterSpawn;
    void Start()
    {
        timeAfterSpawn = 0;
        
        target = FindObjectOfType<player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
         timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            GameObject baki = Instantiate(bakiPrefab, transform.position, transform.rotation);
            baki.transform.LookAt(target);

           
        }
    }
}
