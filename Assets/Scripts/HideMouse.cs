using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HideMouse : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        print("Entered: " + name);
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;   
    }
}
