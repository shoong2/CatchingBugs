using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class joy : MonoBehaviour,IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Transform player;
    Vector3 move;
    public float speed;
    public RectTransform pad;
    public RectTransform stick;
    bool walking;
    public ParticleSystem particleObject;
    player realplayer;
    public bool fallOver;
    public bool over;
    float timer;
    int waitingtime;
   
    public void OnDrag(PointerEventData eventData)
    {
        stick.position = eventData.position;
        stick.localPosition = Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position,pad.rect.width*0.5f);

        move = new Vector3(stick.localPosition.x, 0, stick.localPosition.y).normalized;

        if(!walking)
        {
            walking = true;
            player.GetComponent<Animator>().SetBool("move", true);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager gameS = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(gameS.gamestart == true)
        {
        pad.position = eventData.position;
        pad.gameObject.SetActive(true);
        StartCoroutine("Movement");
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        stick.localPosition = Vector2.zero;
        pad.gameObject.SetActive(false);
        StopCoroutine("Movement");
        move = Vector3.zero;
        walking = false;
        player.GetComponent<Animator>().SetBool("move", false);
        
    }

    IEnumerator Movement()
    {
        while(true)
        {
            player.Translate(move * speed * Time.deltaTime, Space.World);

            if(move != Vector3.zero)
                player.rotation = Quaternion.Slerp(player.rotation, Quaternion.LookRotation(move), 150 *Time.deltaTime);
            
            yield return null;
        }
    }

    void Start() {
        fallOver = false;
        over = false;
        realplayer = GameObject.Find("Player").GetComponent<player>();
        GameManager gameS = GameObject.Find("ControlPanel").GetComponent<GameManager>();
        
    }

    void Update() {
        if(player.position.y <=3.8)
        {
            
            
            player.GetComponent<Animator>().SetTrigger("death");
            speed = 0;
            particleObject.Stop();
            move = Vector3.zero;
            fallOver = true;
            
            
            // Invoke("changeScene", 2f);
        }

        if(realplayer.isDie == true)
        {
            speed = 0;
            particleObject.Stop();
            move = Vector3.zero;
            over = true;
        }
        
       
    }

    void changeScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    
}
