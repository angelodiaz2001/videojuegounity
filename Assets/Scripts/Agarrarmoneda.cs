using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Agarrarmoneda : MonoBehaviour
{

    public Text puntos;
    public int monedas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puntos.text = monedas.ToString();
        
    }

    public void agarrar()
    {
        monedas += 1;
    }
}
