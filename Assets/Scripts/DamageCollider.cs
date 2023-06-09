using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    
    BoxCollider damageCollider;
    // Collider damageCollider;

    public int currentWeaponDamage = 2;

    private void Awake() {
        // damageCollider = GetComponent<Collider>();
        damageCollider = GetComponent<BoxCollider>();
        damageCollider.gameObject.SetActive(true);
        damageCollider.isTrigger = true;
        damageCollider.enabled = false;
    }

    public void EnableDamageCollider(){
        damageCollider.enabled = true;
    }

    public void DisableDamageCollider(){
        damageCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();

            if(playerStats != null)
            {
                playerStats.TakeDamage(currentWeaponDamage);
            }
        }

        if(other.tag == "Enemy" || other.tag == "Destructible")
        {
            EnemyStats enemyStats = other.GetComponent<EnemyStats>();
            Debug.Log("Hit");
            if(enemyStats != null)
            {
                enemyStats.TakeDamage(currentWeaponDamage);
            }
        }
    }
}
