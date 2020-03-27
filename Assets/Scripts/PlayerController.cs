using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

	public float MoveSpeed;
	public float RotationSpeed;
	CharacterController cc;
	private Animator anim;
	protected Vector3 gravidade = Vector3.zero;
	protected Vector3 move = Vector3.zero;
	private bool jump = false;
	Vector3 startPosition;
	public bool parede1;
	public bool parede2;

	private int energy = 100;
	public List<GameObject> life;

	void Start() {
		startPosition = gameObject.transform.position;
		cc = GetComponent<CharacterController> ();
		anim = GetComponent<Animator>();
		anim.SetTrigger("Parado");

		life.AddRange(GameObject.FindGameObjectsWithTag("vida"));
	
}

	void Update()
	{
		Vector3 move = Input.GetAxis ("Vertical") * transform.TransformDirection (Vector3.forward) * MoveSpeed;
		transform.Rotate (new Vector3 (0, Input.GetAxis ("Horizontal") * RotationSpeed * Time.deltaTime, 0));
		
		if (!cc.isGrounded) {
			gravidade += Physics.gravity * Time.deltaTime;
		} 
		else 
		{
			gravidade = Vector3.zero;
			if(jump)
			{
				gravidade.y = 6f;
				jump = false;
			}
		}
		move += gravidade;
		cc.Move (move* Time.deltaTime);
		Anima ();
	}
	 
	void Anima()
	{
		if (!Input.anyKey)
		{
			anim.SetTrigger("Parado");
		} 
		else 
		{
			if(Input.GetKeyDown("space"))
			{
				anim.SetTrigger("Pula");
				jump = true;
			}
			else
			{
				anim.SetTrigger("Corre");
			}
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("lava")) {
			Die();
		}

		if (other.CompareTag("parede1")) {
			parede1 = true;
		}

		if (other.CompareTag("parede2")) {
			parede2 = true;
		}

		if (parede1 && parede2) {
			Die();
		}
	}

	void Die() {
		var range = life.Count - 1;
		if (life.Count > 0) {
			Destroy(life[range]);
			life.RemoveAt(range);
		} else {
			Application.LoadLevel(Application.loadedLevel);
		}
		
		gameObject.transform.position = startPosition;
	}
}
