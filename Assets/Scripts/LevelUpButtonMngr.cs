using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpButtonMngr : MonoBehaviour
{
    //public GameObject bulletObj;
    public BulletScript bullet;

    public GameObject PowerUpCanvas;
    // Start is called before the first frame update
    void Start()
    {
        bullet.force = 5.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Option1(){
        bullet.force = 10f;
        PowerUpCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
}
