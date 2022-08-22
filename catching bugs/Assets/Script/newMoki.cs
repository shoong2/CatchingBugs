using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class newMoki : MonoBehaviour
{
    Transform target;
    Rigidbody rigid;
    NavMeshAgent nav;
    Vector3 targetpos;
    bool god =false;
    public float bakiwait;
    public float godmodeTime;
   
    int bakiDie;

    public float knockBack;

    void Awake() {
        nav = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Player").transform;
        bakiDie = 0;
    }

    void FreezeVelocity()
    {
         rigid.velocity = Vector3.zero;
    //     rigid.angularVelocity = Vector3.zero;
     }
    void FixedUpdate() {
             FreezeVelocity();
    }

    // Update is called once per frame
    void Update()
    {
        targetpos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        nav.SetDestination(targetpos);
        
    }

    public void die() {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "spray")
        {
            if(!god)
            {
                
                Vector3 reactVec = transform.position - other.transform.position;
                reactVec = reactVec.normalized;
                rigid.AddForce(reactVec * knockBack , ForceMode.Impulse);
                nav.speed = 0;
                god = true;
                bakiDie +=1;
                StartCoroutine(godmode());
                StartCoroutine(wait());
                Debug.Log(bakiDie);
            }


        }

        if(bakiDie == 3)
        {
            GameManager.instance.bakiCount+=1;
            GameManager.instance.data.coin +=2;
            Destroy(gameObject);
            
        }

        IEnumerator wait()
        {
            yield return new WaitForSeconds(bakiwait);
            nav.speed = 2f;
        }

        IEnumerator godmode()
        {
            yield return new WaitForSeconds(godmodeTime);
            god = false;
            Debug.Log("god");
        }
    }
}
