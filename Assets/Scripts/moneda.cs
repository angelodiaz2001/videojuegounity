using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneda : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "jugador")
        {
            other.gameObject.GetComponent<Agarrarmoneda>().agarrar();
            Destroy(gameObject);
        }
    }
}