using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Experience : MonoBehaviour
{
    // Start is called before the first frame update
    private int player_experience = 0;
    private int level_threshold = 2;
    public LevelUpButtonMngr levelUpButtonMngr;
    public GameObject levelUpOptions;

    [SerializeField]
    TextMeshProUGUI exp_label;

    private int player_level = 0;

    public ExpBar expBar;
    void Start()
    {
        expBar.initExpSlider(level_threshold);
    }

    public void checkLevelUp(){
        if(player_experience >= level_threshold){
            //enable level up screen
            levelUpButtonMngr.setImages();
            levelUpOptions.SetActive(true);
            Time.timeScale = 0f;

            level_threshold = level_threshold + 2;
            player_experience = 0;
            player_level++;

            exp_label.SetText("Level: "+ player_level);
            expBar.LevelUpSliderReset(level_threshold);
        }

        print("New Level Threshold: "+ level_threshold);
        print("Player Experience: " + player_experience);
    }

    public void setPlayerExperience(){
        player_experience += 1;
        expBar.SetExpSliderValue(player_experience);
    }
}
