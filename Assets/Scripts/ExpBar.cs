using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{

    public Slider exp_slider;

    public void initExpSlider(int maxValue){
        exp_slider.value = 0;
        exp_slider.maxValue = maxValue;
    }
    public void SetExpSliderValue(int value){
        exp_slider.value = value;
    }

    public void LevelUpSliderReset(int maxValue){
        exp_slider.value = 0;
        exp_slider.maxValue = maxValue;
    }
}
