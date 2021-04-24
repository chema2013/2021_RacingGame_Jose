using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth; //at beginning, current health will be max health
        healthBar.SetMaxHealth(maxHealth); //setting healthbar's health to max health
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)) //if this happens
        {
            TakeDamage(5); //take (this much) damage
        }

        if (Input.GetKeyDown(KeyCode.U)) //if this happens
        {
            Healing(5); //take (this much) damage
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage; //current health will be subtracted with the number for damage
        healthBar.SetHealth(currentHealth); //setting the healthbar health to current health, basically updating health bar after taking damage

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            //DeathScreen;
        }
        
    }

    /*void DeathScreen
    {

    }*/

    void Healing(int heal)
    {
        currentHealth += heal; //amount of heal added to health
        healthBar.SetHealth(currentHealth);

        if (currentHealth >= maxHealth) //if current health is greater or equals to max health
            currentHealth = maxHealth; //current health is set to max health limit, cannot become more
    }
}
