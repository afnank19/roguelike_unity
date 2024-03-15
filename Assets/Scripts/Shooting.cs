using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Shooting : MonoBehaviour
{
    public Camera cam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBwFiring;
    private CinemachineImpulseSource impulseSource;
    // Start is called before the first frame update
    void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;//learn this 

        transform.rotation =  Quaternion.Euler(0,0, rotZ);

        if(!canFire){
            timer += Time.deltaTime;
            if(timer > timeBwFiring){
                canFire = true;
                timer = 0;
            }
        }

        if(Input.GetMouseButton(0) && canFire)
        {
            CameraShakeManager.instance.CameraShake(impulseSource);
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            //figure out a way to reverse the velocity vector when instantiating the second bullet
        }

        Vector2 screenPos = cam.WorldToScreenPoint(transform.position);

    }
}
