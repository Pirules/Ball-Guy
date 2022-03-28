using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ballguy : MonoBehaviour
{
    public float velocidad = 5;
    public float Health = 100; 
    public GameObject original;
    public Transform referenciaDePosicion;
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
            original, 
            referenciaDePosicion.position, 
            referenciaDePosicion.rotation
        );
        }
        if (Input.GetKeyDown ("joystick 1 button 0")){
        Instantiate(
            original, 
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
