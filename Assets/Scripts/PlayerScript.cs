using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
        //temporary for testing

        Instantiate(enemy, new Vector3(3.81f, 1.67f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.x < 0){
            //transform.localScale = new Vector3(-1, 1, 1);
            player_sr.flipX = true;
            
        }else if(movement.x > 0){
            //transform.localScale = new Vector3(1, 1, 1);
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
        // if(movement.x == 0 && movement.y == 0)
        //     return;
        if(hit){
            print("In player Normal: "+ knockback);
            player_rb.AddForce(knockback * 0.7f, ForceMode2D.Impulse);
            Invoke("hitForceDelay", 0.2f);
            
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
        canAttack = true;
    }
    void attackDelay(){

    }

    void OnTriggerStay2D(Collider2D coll){
        if(canAttack){
            health -= 5;
            Invoke("attackDelay", 1f);
        }
        

        Vector2 dir = (coll.transform.position - transform.position).normalized;

        knockback = -dir;

        hit = true;
        //player_rb.AddForce(-transform.right * 10f, ForceMode2D.Impulse);
   }
}
