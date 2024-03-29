using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Experience : MonoBehaviour
{
    // Start is called before the first frame update
    private int player_experience = 0;
    private int level_threshold = 1;

    public LevelUpButtonMngr levelUpButtonMngr;
    public GameObject levelUpOptions;
    void Start()
    {

    }

    public void checkLevelUp(){
        if(player_experience >= level_threshold){
            //enable level up screen
            levelUpButtonMngr.setImages();
            levelUpOptions.SetActive(true);
            Time.timeScale = 0f;

            level_threshold *= 2;
            player_experience = 0;
        }

        print("New Level Threshold: "+ level_threshold);
        print("Player Experience: " + player_experience);
    }

    public void setPlayerExperience(){
        player_experience += 1;
    }
}
