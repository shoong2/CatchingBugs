using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class testGamemanager : MonoBehaviour
{
    public GameObject spawner;
    public Text wave;
    int score =1;
    float realplay;

    void Start()
    {
    
        StartCoroutine(playtime(score));
    }

    IEnumerator playtime(int score)
    {
        if(realplay > 20 && realplay < 240)
            spawner.transform.GetChild(score).gameObject.SetActive(true);
        wave.text ="Wave "+score;
        
        score +=1;
        yield return new WaitForSeconds(20f);
        StartCoroutine(playtime(score));
        
    }
    void Update()
    {
        
    }
}
