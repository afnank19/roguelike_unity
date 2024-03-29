using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject levelUpOptions;
    public LevelUpButtonMngr levelUpButtonMngr;
    // Start is called before the first frame update
    void Start()
    {
        levelUpOptions.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //This is for testing the level up menu, in future this should be replaced by the Pause Menu
        //and other game management requirements
        if(Input.GetKeyDown(KeyCode.P)){
            levelUpButtonMngr.setImages();
            levelUpOptions.SetActive(true);
            Time.timeScale = 0f;
        }
        if(Input.GetKeyDown(KeyCode.L)){
            levelUpOptions.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
