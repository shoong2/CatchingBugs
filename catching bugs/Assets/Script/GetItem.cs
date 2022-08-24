using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItem : MonoBehaviour
{
    //item prefab에 부착
    gauge healthgauge;
    player Player;
    
    
    void Start()
    {
        healthgauge = GameObject.Find("GameManager").GetComponent<gauge>();
        Player = GameObject.Find("PlayerCollider").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            Audio.instance.itemsound();
            //Player.itemAudio();
            healthgauge.getItem();
            Destroy(gameObject);
        }
        
    }
}
