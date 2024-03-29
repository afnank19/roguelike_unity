using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Suicide", 0.45f);
    }

    private void Suicide(){
        Destroy(gameObject);
    }
}
