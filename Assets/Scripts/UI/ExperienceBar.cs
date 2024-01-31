using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxExperience (float maxExperience) {
        slider.maxValue = maxExperience;
        slider.value = maxExperience;
    }
    
    public void SetExperience (float experience) {
        slider.value = experience;
    }
}
