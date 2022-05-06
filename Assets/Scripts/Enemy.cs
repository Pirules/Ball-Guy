using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Healthbar healthbar;
    public float speed = 1.19f;
    public Vector3 offset1;
    public Vector3 offset2;
    Vector3 pointA;
    Vector3 pointB;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;  
        healthbar.setMaxHealth(maxHealth);
        pointA = GameObject.Find("Jugador").transform.position + offset1;
        pointB = GameObject.Find("Jugador").transform.position + offset2;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.currentHealth);
        //PingPong between 0 and 1
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);

        if (currentHealth <= 0){
        Debug.Log("Hello, World");
         //Do everything you want with this part, but before destroying the enemy, add this:
         GameObject.Find(gameObject.name + ("spawn point")).GetComponent<Respawn>().Death = true;
         //Then destroy it
         Destroy(gameObject);
        }   
        
    }
    void OnCollisionEnter(Collision c){
        GameObject projectil = c.gameObject;
        if (projectil.CompareTag("Bala")){
            Debug.Log("pre bala");
            TakeDamage(10);
            Debug.Log("post bala");
        }

        if (projectil.CompareTag("MegaBala")){
            TakeDamage(25);
        }
    }
       
    void TakeDamage(int damage){
        this.currentHealth = currentHealth - damage;
        healthbar.setHealth(this.currentHealth);
    }
}