using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {
    private Animator anim;

    public ChaveController chaveControllerScript;

    void Start() {
        anim = GetComponent<Animator>();

        
    }

    void Update()
    {
        if (chaveControllerScript.chave1 && chaveControllerScript.chave2) {
            anim.Play("move_porta");
        }
    }
}
