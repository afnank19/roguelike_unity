using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CursorScript : MonoBehaviour
{
    public Camera cam;

    
    // Start is called before the first frame update
    void Start()
    {
        //UnityEngine.Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(mousePos.x, mousePos.y, 1);
    }
}
