using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private int qtdePedra = 0;
    public Text pedras;
    public Image lifeBar;
    private int life = 100;
    private int dano = 20;
    
    void Start()
    {
        pedras.text = qtdePedra.ToString();
    }

    void Update() {
    }
}
