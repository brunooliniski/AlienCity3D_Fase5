using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class key : MonoBehaviour {
    
    private GameObject portao;
    private Animator abrePortao;
    
    

    // Start is called before the first frame update
    void Start() {
        portao = GameObject.Find("door");
        abrePortao = portao.GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update() {
        gameObject.transform.Rotate(Vector3.right, 3.5f);
    }
    
    private void OnTriggerEnter(Collider col) {
        ChaveController chaveControllerScript = gameObject.GetComponentInParent<ChaveController>();

        if (gameObject.name == "Key1") {
            chaveControllerScript.chave1 = true;
            chaveControllerScript.key1.enabled = true;
        }
        if (name == "Key2") {
            chaveControllerScript.chave2 = true;
            chaveControllerScript.key2.enabled = true;
        };
        
        Destroy(gameObject);
    }
    
}
