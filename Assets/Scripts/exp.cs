using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exp : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D exp_rb;


    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(-1,2);
        int y = Random.Range(-1,2);

        Vector2 spawn_velocity = new Vector2(x,y);

        exp_rb.velocity = spawn_velocity;
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.name == "Player")
            Destroy(gameObject);
    }
}
