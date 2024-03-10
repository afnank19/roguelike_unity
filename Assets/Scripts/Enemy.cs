using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    public Rigidbody2D enemy_rb;
    public SpriteRenderer enemy_sr;
    const float SPEED = 2;
    public Vector3 normalized_dir;
    public int health = 10;

    bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       //print (player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        

    }

    void FixedUpdate(){
        if(hit){
            print("Enemy Normal: "+ normalized_dir);
            enemy_rb.AddForce(-normalized_dir * 0.9f, ForceMode2D.Impulse);
            Invoke("hitForceDelay", 0.2f);
            
        }else if(!hit){
            float xDir = transform.position.x - player.transform.position.x;
            float yDir = transform.position.y - player.transform.position.y;
            float zDir = transform.position.z - player.transform.position.z;
            normalized_dir = new Vector3(-xDir, -yDir, -zDir).normalized;

            if(normalized_dir.x < 0){
                enemy_sr.flipX = false;
            }
            else if(normalized_dir.x >= 0){
                enemy_sr.flipX = true;
            }

            enemy_rb.velocity = normalized_dir*SPEED;
        }

    }

    void hitForceDelay(){
        hit = false;
    }

    void OnTriggerEnter2D(){
        
        //enemy_rb.velocity = new Vector3(5,5,5);
        //print("Enemy Collided"+normalized_dir);
        //hit = true;
    }
    void OnTriggerStay2D(){
        //hit = true;
    }
}