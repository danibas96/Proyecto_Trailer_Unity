using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject camion;
    private Vector3 distancia;
    // Start is called before the first frame update
    void Start()
    {
        
        distancia = transform.position - camion.transform.position;
    }
    
 
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = camion.transform.position + distancia;
    }
}
