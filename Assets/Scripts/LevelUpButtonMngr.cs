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
    public Shooting shooting;
    public PlayerScript player;
    public Enemy enemy;
    public EnemySpawner enemySpawner;
    public AudioSource cardHover;

    [SerializeField]
    TextMeshProUGUI description;
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
    // void Update()
    // {
        
    // }

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
        int curse_rand = UnityEngine.Random.Range(0,2);

        if(prompt == "strength"){
            //increase damage
            bullet.SetBulletDamage(5);
            print("more Strength");
            player.DamageOnAbility();
        }

        if (prompt == "multi"){
            //add bullets
            shooting.IncrementBullets();
            player.DamageOnAbility();
        }
        if (prompt == "speed") {
            //increase projectile speed
            bullet.force = 10f;
            player.DamageOnAbility();
        }
        if(prompt == "curse1"){
                player.HealOnCurse(10);
                print("increased enemy speed");
                enemy.speed_mult += 0.15f;
        }
        if(prompt == "curse2"){
                player.HealOnCurse(10);
                player.dmg += 5;
        }
        if(prompt == "curse3"){
                player.HealOnCurse(20);
                enemySpawner.IncreaseEnemyQty();
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


    public void HoverOp1(){
        setDescription(option1Image.sprite.name);
        // RectTransform oTransform = option1.GetComponent<RectTransform>();
        // oTransform.localScale = new Vector3(1.1f,1.1f);
        option1.transform.localScale = new Vector3(1.1f, 1.1f);
    }
    public void HoverOp2(){
        setDescription(option2Image.sprite.name);
        option2.transform.localScale = new Vector3(1.1f, 1.1f);
    }
    public void HoverOp3(){
        setDescription(option3Image.sprite.name);
        option3.transform.localScale = new Vector3(1.1f, 1.1f);
    }

    public void HoverExit(){
        option1.transform.localScale = new Vector3(1,1);
        option2.transform.localScale = new Vector3(1,1);
        option3.transform.localScale = new Vector3(1,1);
    }


    void setDescription(string prompt){
        cardHover.Play();
        if(prompt == "strength"){
            description.SetText("SACRIFICE: Give up health for increased damage");
        }
        if (prompt == "multi"){
            description.SetText("SACRIFICE: Give up health to add more charges");
        }
        if (prompt == "speed") {
            description.SetText("SACRIFICE: Give up health for increased charge speed");
        }
        if(prompt == "curse1"){
            description.SetText("CURSED: Returns health but increases enemy speed");
        }
        if(prompt == "curse2"){
            description.SetText("CURSED: Returns health but increases enemy damage");
        }
        if(prompt == "curse3"){
            description.SetText("CURSED: Returns health but increases enemy quantity");
        }
    }

    public void SkipLevelUp(){
        PowerUpCanvas.SetActive(false);
        Time.timeScale = 1f;
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
