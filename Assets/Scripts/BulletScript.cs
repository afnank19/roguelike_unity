using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Vector3 mousePos;
    private Camera cam;
    public Rigidbody2D bullet_rb;
    public float force;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;

        bullet_rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPos = cam.WorldToScreenPoint(transform.position);

        if((screenPos.x < 0) || (screenPos.x  > cam.pixelWidth)){
            Destroy(gameObject);
        }
        if((screenPos.y - 32 < 0 ) || (screenPos.y  > cam.pixelHeight)){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(UnityEngine.Collider2D coll)
    {
        //print("Collision");
        //Destroy(enemy);
        print(coll.gameObject.name);
        if (coll.gameObject.name == "Enemy(Clone)")
            Destroy(gameObject);
    }
}
