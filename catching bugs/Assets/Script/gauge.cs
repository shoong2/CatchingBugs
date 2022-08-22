using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gauge : MonoBehaviour
{
    public Image health;
    public float time;
    public float addtime;
    public GameObject particleObject;
    
    void Update()
    {
        health.fillAmount -= 1 / time *Time.deltaTime;

        if(health.fillAmount == 0)
        {
            particleObject.SetActive(false);
        }
        else
            particleObject.SetActive(true);
    }

    public void getItem()
    {
        health.fillAmount += addtime *Time.deltaTime;
    }
}
