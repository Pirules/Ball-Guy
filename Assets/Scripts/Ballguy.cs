using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ballguy : MonoBehaviour
{
    public float velocidad = 5;
    public float Health = 100; 
    public GameObject Bala;
    public GameObject MegaBala;
    public Transform referenciaDePosicion;
    public Transform spawnerMegaBala;
    [SerializeField]
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    

    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");        
        float diagonal = Input.GetAxis("Vertical");

        //print(horizontal);
        if(Input.GetKeyDown(KeyCode.Space)){


            Instantiate(
                Bala, 
                referenciaDePosicion.position, 
                referenciaDePosicion.rotation
            );
            }

        if(Input.GetKeyDown(KeyCode.Z)){

            Instantiate(
                MegaBala, 
                spawnerMegaBala.position, 
                spawnerMegaBala.rotation
            );
            Instantiate(
                MegaBala, 
                spawnerMegaBala.position = spawnerMegaBala.position + new Vector3(horizontal * velocidad * Time.deltaTime, diagonal + 10 * velocidad * Time.deltaTime, 0), 
                spawnerMegaBala.rotation
            );

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
        
    }
}
