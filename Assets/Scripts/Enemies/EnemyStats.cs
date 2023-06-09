using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    //public int vitalityLevel = 1;

    //public int currentHealth;
    //public int maxHealth;

    public UIEnemyHealthBar uiEnemyHealthBar;

    Animator animator;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        maxHealth = SetMaxHealthFromLevel();
        currentHealth = maxHealth;
        uiEnemyHealthBar.SetMaxHealth(maxHealth);
    }

    private int SetMaxHealthFromLevel()
    {
        maxHealth = (vitalityLevel) + 10;
        return maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
        {
            return;
        }

        currentHealth = currentHealth - damage;

        uiEnemyHealthBar.SetHealth(currentHealth);

        animator.Play("Take_Damage");

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            animator.Play("Dead_01");
            isDead = true;
            // Handle death
            StartCoroutine(DestroyDead());
        }
    }

    IEnumerator DestroyDead() {
        yield return new WaitForSeconds(8.0f);
        Destroy(gameObject);
    }
}
