using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PowerLabel;
    // Start is called before the first frame update
    void Start()
    {
        PowerLabel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //This is for testing the level up menu, in future this should be replaced by the Pause Menu
        //and other game management requirements
        if(Input.GetKeyDown(KeyCode.P)){
            PowerLabel.SetActive(true);
            Time.timeScale = 0f;
        }
        if(Input.GetKeyDown(KeyCode.L)){
            PowerLabel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
