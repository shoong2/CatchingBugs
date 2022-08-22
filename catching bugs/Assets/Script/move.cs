using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class move : MonoBehaviour
{
    Vector2 movement;
    private Animator anim;
    Rigidbody playerRigidbody;
    public float speed = 8f;

    private void Awake() {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        if (xInput != 0 || zInput != 0 )
        {
            anim.SetBool("move", true);
        }
        else
        {
            anim.SetBool("move", false);
        }

        // anim.SetFloat("X", xInput);
        // anim.SetFloat("Y", zInput);

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed ).normalized;
        playerRigidbody.velocity = newVelocity;
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("!!!");
        if(other.tag == "end")
        {
            SceneManager.LoadScene("SamepleScene");
        }
    }
}
