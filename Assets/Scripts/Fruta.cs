﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruta : MonoBehaviour {

	public GameObject corte1;
	public GameObject corte2;

	public AudioClip som;
	GameObject fonteDeSom;

	GameObject gerador;

	// Use this for initialization
	void Start () {
		fonteDeSom = GameObject.FindGameObjectWithTag("SomCorteFruta");
		gerador = GameObject.FindGameObjectWithTag("GeradorDeFrutas");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D obj) {
		if(obj.gameObject.tag == "Linha") {
			gerador.GetComponent<GeradorDeFrutas>().Pontuar();

			fonteDeSom.GetComponent<AudioSource>().clip = som;
			fonteDeSom.GetComponent<AudioSource>().Play();

			GameObject parte1 = Instantiate(corte1, transform.position, Quaternion.identity) as GameObject;
			GameObject parte2 = Instantiate(corte2, new Vector3(transform.position.x - 2f, transform.position.y, 0), corte2.transform.rotation) as GameObject;

			parte1.GetComponent<Rigidbody2D>().AddForce(new Vector2(2f,2f), ForceMode2D.Impulse);
			parte2.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2f,-2f), ForceMode2D.Impulse);

			parte1.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-2f,2f), ForceMode2D.Impulse);
			parte2.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-2f,2f), ForceMode2D.Impulse);

			Destroy(gameObject);
		}
	}
}
