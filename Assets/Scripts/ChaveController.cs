using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaveController : MonoBehaviour
{
    public bool chave1 = false;
    public bool chave2 = false;
    
    public Image key1;
    public Image key2;

    private GameObject pedra;
    
    void Start() {
        key1.enabled = false;
        key2.enabled = false;
    }

    void Update()
    {
        
    }
    
   
}
