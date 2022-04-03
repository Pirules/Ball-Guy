using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject Bala;
    public Transform referenciaDePosicion;
    public Healthbar healthbar;
     private float nextActionTime = 0.0f;
    public float frecuencia_de_disparo = 1f;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
         if (Time.time > nextActionTime ) {
            nextActionTime += frecuencia_de_disparo;
            Instantiate(
                Bala, 
                referenciaDePosicion.position, 
                referenciaDePosicion.rotation
            );
         }

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
