using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpButtonMngr : MonoBehaviour
{
    //public GameObject bulletObj;
    public BulletScript bullet;
    public GameObject PowerUpCanvas;

    public Button option1;
    Image option1Image;
    public Sprite[] testImage;
    // Start is called before the first frame update
    void Start()
    {
        bullet.force = 5.5f;
        option1Image = option1.GetComponent<Image>();
        option1Image.sprite = testImage[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Option1(){
        print(option1Image.sprite.ToString());
        if(option1Image.sprite.ToString() == "chi_blast_1 (UnityEngine.Sprite)"){
            print("found goku");
        }

        bullet.force = 10f;
        PowerUpCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
}
