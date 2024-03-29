using System;
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

    public Button option1, option2, option3;
    public Image option1Image, option2Image, option3Image;
    public Sprite[] testImage;
    // Start is called before the first frame update
    void Start()
    {
        bullet.force = 5.5f;
        option1Image = option1.GetComponent<Image>();
        option2Image = option2.GetComponent<Image>();
        option3Image = option3.GetComponent<Image>();
        option1Image.sprite = testImage[0];
        option2Image.sprite = testImage[1];
        option3Image.sprite = testImage[2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Option1 () {
        setAbilities(option1Image.sprite.name);
    }
    public void Option2 () {
        setAbilities(option2Image.sprite.name);
    }
    public void Option3 () {
        setAbilities(option3Image.sprite.name);
    }

    private void setAbilities (string prompt) {
        if(prompt == "strength"){
            //increase damage
            bullet.SetBulletDamage(5);
            print("more Strength");
        }

        if (prompt == "multi"){
            //add bullets
            print("added bullets");
        }
        if (prompt == "speed") {
            //increase projectile speed
            bullet.force = 10f;
        }

        PowerUpCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void setImages () {
        Shuffle<Sprite>(testImage);

        option1Image.sprite = testImage[0];
        option2Image.sprite = testImage[1];
        option3Image.sprite = testImage[2];
    }


    public static void Shuffle<Sprite>(Sprite[] array)
    {
        System.Random rng = new System.Random();

        // Loop through the array from the end to the beginning
        for (int i = array.Length - 1; i > 0; i--)
        {
            // Generate a random index within the range [0, i+1)
            int randomIndex = rng.Next(i + 1);

            // Swap the elements at randomIndex and i
            Sprite temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
}
