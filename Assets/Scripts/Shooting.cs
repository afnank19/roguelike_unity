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

    [SerializeField]
    AudioSource bulletAS;
    private int numberOfBullets = 1;
    float timeBwBlts = 0.1f;
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
            bulletAS.Play();
            canFire = false;
            timeBwBlts = 0.1f;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            //Invoke("SecondBulletDelay", 0.1f);

            for(int i = 1; i < numberOfBullets; i++){
                Invoke("SecondBulletDelay", timeBwBlts);
                timeBwBlts += 0.1f;
            }
            
            //figure out a way to reverse the velocity vector when instantiating the second bullet
        }

        Vector2 screenPos = cam.WorldToScreenPoint(transform.position);
    }
    void SecondBulletDelay(){
        Instantiate(bullet, bulletTransform.position, Quaternion.identity);
    }

    public void IncrementBullets(){
        numberOfBullets++;
    }
}
