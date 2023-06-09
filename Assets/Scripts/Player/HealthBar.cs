using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public TMP_Text healthText;
    
    public Slider slider;
    private int fullHealth;

    private void Start() {
        healthText.alignment = TextAlignmentOptions.Center;
    }

    public void SetMaxHealth(int maxHealth){
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        fullHealth = maxHealth;
    }

    public void SetCurrentHealth(int currentHealth){
        slider.value = currentHealth;
        healthText.text = currentHealth + "/" + fullHealth;
    }

}
