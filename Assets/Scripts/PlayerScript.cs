using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D player_rb;
    public float moveSpeed = 5f;
    Vector2 movement;
    public Camera cam;
    public SpriteRenderer player_sr;
    public GameObject enemy;
    public Enemy enemyRef;
    int health = 10;
    bool hit = false;
    bool canAttack = true;
    Vector2 knockback;
    private CinemachineImpulseSource impulseSource;

    void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
        //temporary for testing

        //Instantiate(enemy, new Vector3(3.81f, 1.67f, 0), Quaternion.identity);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.x < 0){
            player_sr.flipX = true;
            
        }else if(movement.x > 0){
            player_sr.flipX = false;
        }

        checkGameOver();
        

    }

    private void checkGameOver()
    {
        if(health <= 0){
            print("Game Over");
            health = 10;
        }
    }

    void FixedUpdate(){
        if(hit){
            //print("In player Normal: "+ knockback);
            player_rb.AddForce(knockback * 1.15f, ForceMode2D.Impulse);
            Invoke("hitForceDelay", 0.15f);
            
        }else if(!hit){
            player_rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);

            Vector2 screenPos = cam.WorldToScreenPoint(transform.position);

            if((screenPos.x - 32 < 0 && movement.x < 0) || (screenPos.x + 30 > cam.pixelWidth && movement.x > 0)){
                player_rb.velocity = new Vector2(0,0);
            }
            if((screenPos.y - 32 < 0 && movement.y < 0) || (screenPos.y + 30 > cam.pixelHeight && movement.y > 0)){
                player_rb.velocity = new Vector2(0,0);
            }
        }

        
    }
    void hitForceDelay(){
        hit = false;

    }
    void attackDelay(){
        canAttack = true;
    }
    void DamageHealth(){
        health -= 5;
    }
    void OnTriggerEnter2D(){
        CameraShakeManager.instance.CameraShake(impulseSource);
    }
    void OnTriggerStay2D(Collider2D coll){
        if(canAttack){
            DamageHealth();
            canAttack = false;
            Invoke("attackDelay", 1);
        }
        
        //Calculates the direction for the knockback
        Vector2 dir = (coll.transform.position - transform.position).normalized;

        knockback = -dir;

        hit = true;
   }
}
