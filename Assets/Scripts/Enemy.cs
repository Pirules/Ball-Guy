using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Healthbar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {


        if (currentHealth <= 0){
            Destroy(gameObject);
        }   
        
    }
    void OnCollisionEnter(Collision c){
        GameObject projectil = c.gameObject;
        if (projectil.CompareTag("Bala")){
            TakeDamage(10);
        }

        if (projectil.CompareTag("MegaBala")){
            TakeDamage(25);
        }
    }
       
    void TakeDamage(int damage){
        currentHealth -= damage;
        healthbar.setHealth(currentHealth);
    }
}