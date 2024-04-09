using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject levelUpOptions;
    public LevelUpButtonMngr levelUpButtonMngr;
    public BulletScript bullet;
    // Start is called before the first frame update
    void Start()
    {
        levelUpOptions.SetActive(false);
        bullet.BulletDamage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //This is for testing the level up menu, in future this should be replaced by the Pause Menu
        //and other game management requirements
    }
}
