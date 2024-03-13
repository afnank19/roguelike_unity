using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;

    //DONOT hardcode this, find a more generic solution
    private float XDistPositive = 6.8f, YDistPositive = 3.8f;
    void Start()
    {
        //Spawns the enemies with the correct parameters after every minute.
        InvokeRepeating("SpawnHelper",1, 15);
    }

    void Update()
    {
        
    }

    void SpawnHelper(){
       Spawn(2);
    }
    void Spawn (int enemyCount) {
        int[] quadrantChange = {-1, 1};

        for (int i = 1; i <= enemyCount; i++) {
            int selector = Random.Range(0,2);
            int quadrantSelector = Random.Range(0,2);

            if (selector == 0) {
                float xPos = Random.Range(0f, 7f);
                Instantiate(Enemy, new Vector3(xPos * quadrantChange[quadrantSelector], YDistPositive), Quaternion.identity);
            }
            else if (selector == 1) {
                float yPos = Random.Range(0f, YDistPositive+0.3f);
                Instantiate(Enemy, new Vector3(XDistPositive, yPos * quadrantChange[quadrantSelector]), Quaternion.identity);
            }
        }
    }
}
