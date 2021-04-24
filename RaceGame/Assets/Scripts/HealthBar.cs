using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health) //setting maximum health using health number
    {
        slider.maxValue = health; //the maximum value of slider is the health
        slider.value = health; //making sure slider value is set to health

        //fill color to gradient
        fill.color = gradient.Evaluate(1f); //getting specific colour from specific point of health; value from 0 (left of gradient; red) to 1 (right of gradient; green)
    }

    public void SetHealth(int health) //setting health using a number called health
    {
        slider.value = health; //value of the slider is the health
                                            //normalized Value in range from 0 to 1
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}