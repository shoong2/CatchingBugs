using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public GameObject Item;
    public float randomTime =1f;

    void Start()
    {
        InvokeRepeating("randomLocation" , 5, randomTime);
    }

    void randomItem(float a, float b, float c, float d)
    {
        float randomX = Random.Range(a, b);
        float randomZ = Random.Range(c, d);

        if(true)
        {
             GameObject item = (GameObject)Instantiate(Item, new Vector3(randomX, 3.65f,randomZ), Quaternion.identity);
        }
    }

    void randomLocation()
    {
        int randomLocation = Random.Range(0,4);

        if(randomLocation == 0)
            randomItem(-24f, -7f, 1f, 8f);

        else if(randomLocation == 1)
            randomItem(-11f, -1f, -8f, -1f);
        
        else if(randomLocation == 2)
            randomItem(-1f, 3f, 3f, 14f);
        
        else if(randomLocation == 3)
            randomItem(-17f, -1f, 16f, 19f);
        
        else if(randomLocation == 4)
            randomItem(-9f, 2f, 12f, 15f);

    }
}
