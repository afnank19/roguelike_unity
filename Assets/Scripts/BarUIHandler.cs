using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarUIHandler : MonoBehaviour
{
    public Slider health_slider;
    // Start is called before the first frame update

    public void initHealthSlider(int starting_health){
        health_slider.value = starting_health;
    }

    public void SetHealthSlider(int value){
        health_slider.value = value;
    }
}
