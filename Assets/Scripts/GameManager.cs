using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject levelUpOptions;
    public GameObject pauseMenu;
    public LevelUpButtonMngr levelUpButtonMngr;
    public BulletScript bullet;

    private bool pauseToggle = true;
    // Start is called before the first frame update
    void Start()
    {
        levelUpOptions.SetActive(false);
        pauseMenu.SetActive(false);
        bullet.BulletDamage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //This is for testing the level up menu, in future this should be replaced by the Pause Menu
        //and other game management requirements
        if(Input.GetKeyDown(KeyCode.Escape) && !levelUpOptions.activeSelf){
            if(pauseToggle){
                pauseToggle = false;
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else {
                pauseToggle = true;
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
