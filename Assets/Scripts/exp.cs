using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.name == "Player")
            Destroy(gameObject);
    }
}
