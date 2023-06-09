using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{

    public int playerLevel = 1;
    public int armor;

    public HealthBar healthBar;

    AnimationHandler animationHandler;
    ArmorManager armorManager;

    private void Awake()
    {
        animationHandler = GetComponentInChildren<AnimationHandler>();
        armorManager = GetComponentInChildren<ArmorManager>();
    }

    void Start()
    {
        maxHealth = SetMaxHealthFromLevel();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetCurrentHealth(currentHealth);
    }

    private int SetMaxHealthFromLevel()
    {
        maxHealth = Mathf.RoundToInt(vitalityLevel * 1.6f ) + 10 + playerLevel;
        return maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
        {
            return;
        }
        double damageMulti = (float)damage/((float)damage+(float)armor);
        Debug.Log(damage +" "+ armor +" "+ damageMulti);
        double damageTaken = damage*damageMulti;
        Debug.Log(damageTaken);
        currentHealth = currentHealth - (int)damageTaken;

        healthBar.SetCurrentHealth(currentHealth);
        animationHandler.PlayTargetAnimation("Take_Damage", true);

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            animationHandler.PlayTargetAnimation("Dead_01", true);
            isDead = true;
            // Handle death
        }
    }

    public void Heal(int value)
    {
        currentHealth += currentHealth;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

}
