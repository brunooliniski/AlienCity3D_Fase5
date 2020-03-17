using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RotacionaPedra : MonoBehaviour {
	HUD hud;
	private int qtdePedras;
	void Update () {
		transform.Rotate(new Vector3(0, 0, 1), 30 * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) 
	{
		hud = GameObject.Find("Canvas").GetComponent<HUD>();
		if (other.gameObject.CompareTag("Player")||(other.gameObject.CompareTag("tiro")))
		{
			Destroy(gameObject);
			qtdePedras++;
			hud.pedras.text = qtdePedras.ToString();
		}
	}
}
