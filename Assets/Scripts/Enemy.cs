using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

//NOTES: Enemies should not collide with each other, FIX needed
    //2: Destroy() in shooting script sometimes randomly destroys not the intended enemy. @fixed
public class Enemy : MonoBehaviour
{
    private GameObject player;
    private PlayerScript playerScript;
    public Rigidbody2D enemy_rb;
    public SpriteRenderer enemy_sr;
    const float SPEED = 2;
    public Vector3 normalized_dir;
    private int health = 10;
    bool hit = false;
    public Animator animator;
    public GameObject exp;
    public GameObject bullet;
    public BulletScript bulletScript;
    public float speed_mult = 1;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //bulletScript = bullet.GetComponent<BulletScript>();
    }


    void Update()
    {

        if(health <= 0){
            Destroy(gameObject);
            playerScript = player.GetComponent<PlayerScript>();
            playerScript.EnemyDeathSound();
            Instantiate(exp, transform.position, Quaternion.identity);
        }

    }

    void FixedUpdate(){
        if(hit){
            //print("Enemy Normal: "+ normalized_dir);
            enemy_rb.AddForce(-normalized_dir * 0.9f, ForceMode2D.Impulse);
            Invoke("hitForceDelay", 0.1f);
            
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

            enemy_rb.velocity = SPEED * speed_mult * normalized_dir;
        }

    }

    public void incrementSpeedMult(){
        speed_mult = speed_mult + 1f;
        print(speed_mult);
    }

    void hitForceDelay(){
        hit = false;
    }
    void Damage(){
        print(bulletScript.GetBulletDamage());
        print(bulletScript.BulletDamage);
        health -= bulletScript.GetBulletDamage();
    }

    void OnTriggerEnter2D (Collider2D coll) {
        
        //enemy_rb.velocity = new Vector3(5,5,5);
        //print("Enemy Collided"+normalized_dir);
        //hit = true;
        if (coll.gameObject.name == "Bullet(Clone)") {
            animator.SetBool("enemyBeingHit", true);
            Invoke("resetHitAnimation", 0.2f);
            Damage();
        }
    }
    private void resetHitAnimation(){
        animator.SetBool("enemyBeingHit", false);
   }
    void OnTriggerStay2D (Collider2D coll) {
        if (coll.gameObject.name == "Bullet(Clone)")
            hit = true;
    }

}
