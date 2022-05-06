using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ballguy : MonoBehaviour
{
    public float velocidad = 5;
    public int maxEnergy = 100;
    public int maxHealth = 100;
    public int currentHealth;
    public Healthbar healthbar;
    public int currentEnergy;
    public EnergyBar energybar;
    public GameObject Bala;
    public GameObject MegaBala;
    public Transform referenciaDePosicion;
    public Transform spawnerMegaBala;
    private float nextActionTime = 0.0f;
    public float frecuencia_de_disparo = 1f;
    [SerializeField]
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody>();
        currentEnergy = maxEnergy;
        energybar.setMaxEnergy(maxEnergy);
    }
    

    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");        
        float diagonal = Input.GetAxis("Vertical");
        
        if (currentEnergy < 100)
        {
            if (Time.time > nextActionTime ) {
            nextActionTime += frecuencia_de_disparo;
            GainEnergy(10);
        }
        }


        //print(horizontal);
        if(Input.GetKeyDown(KeyCode.Space)){
            if(currentEnergy < 20){

            }

            else{
                Instantiate(
                    Bala, 
                    referenciaDePosicion.position, 
                    referenciaDePosicion.rotation
                );
                if(currentEnergy > 0){
                    TakeEnergy(20);
                }
                
            }



            }

        if(Input.GetKeyDown(KeyCode.Z)){
            if(currentEnergy <40){
                
            }
            else{
                Instantiate(
                    MegaBala, 
                    spawnerMegaBala.position, 
                    spawnerMegaBala.rotation
                );
                Instantiate(
                    MegaBala, 
                    spawnerMegaBala.position + new Vector3(horizontal * velocidad * Time.deltaTime, diagonal + 10 * velocidad * Time.deltaTime, 0), 
                    spawnerMegaBala.rotation
                );
                if(currentEnergy > 0){
                    TakeEnergy(40);
                }
            }


        }

        if (Input.GetKeyDown ("joystick 1 button 0")){

            Instantiate(
                Bala, 
                referenciaDePosicion.position, 
                referenciaDePosicion.rotation
        );
        }
        
        transform.Translate(
            velocidad * horizontal * Time.deltaTime, 
            velocidad * diagonal * Time.deltaTime, 
            0,
            Space.World
        );

        void TakeEnergy(int loss)
        {
            currentEnergy -= loss;
            energybar.SetEnergy(currentEnergy);
        }

        void GainEnergy(int gain)
        {
            currentEnergy += gain;
            energybar.SetEnergy(currentEnergy);
        }
        
        if (currentHealth <= 0){
            Debug.Log("YOU DIED :D");
            Destroy(gameObject);
            SceneManager.LoadScene("Death Screen");
        }   
    }

    void OnCollisionEnter(Collision c){
        TakeDamage(10);
    }

    void TakeDamage(int damage){
        this.currentHealth = currentHealth - damage;
        healthbar.setHealth(this.currentHealth);
    }
}
