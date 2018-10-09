using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeFrutas : MonoBehaviour {

	public GameObject melancia;
	public GameObject bomba;
	public float tamanhoDaTela;
	public float forca;
	

	// Use this for initialization
	void Start () {
		Invoke ("Gerar", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Gerar() {
		InvokeRepeating("GerarGrupoDeFrutas", 1, 6f); // é uma função que chama outra função depois de um certo tempo a cada 6 segundos
	}

	void GerarGrupoDeFrutas() {
		StartCoroutine("GerarFruta");
		if (Random.Range(0, 6) > 2) {
			GerarBomba();
		}
	}

	IEnumerator GerarFruta() {
		for (int i = 0; i < Random.Range(5, 20); i++) {
			float aleatorio = Random.Range(-tamanhoDaTela, tamanhoDaTela); // em qual posicao da tela a melancia vai nascer
			Vector3 posicao = new Vector3 (aleatorio, transform.position.y, 0); // definindo a variavel posicao
			GameObject melanciaClone = Instantiate(melancia, posicao, Quaternion.identity) as GameObject; // Criando a melancia e salvando a melancia na variavel clone
			melanciaClone.GetComponent<Rigidbody2D>().AddForce (new Vector2(0, forca), ForceMode2D.Impulse);
			melanciaClone.GetComponent<Rigidbody2D>().AddTorque (Random.Range(-20f, 20f)); // Torque é uma ação de girar
			yield return new WaitForSeconds (Random.Range(0.2f, 0.6f)); // esperando meio segundo
		}
	}

	void GerarBomba() {
		float aleatorio = Random.Range(-tamanhoDaTela, tamanhoDaTela); // em qual posicao da tela a melancia vai nascer
		Vector3 posicao = new Vector3 (aleatorio, transform.position.y, 0); // definindo a variavel posicao
		GameObject bombaClone = Instantiate(bomba, posicao, Quaternion.identity) as GameObject; // Criando a melancia e salvando a melancia na variavel clone
		bombaClone.GetComponent<Rigidbody2D>().AddForce (new Vector2(0, forca), ForceMode2D.Impulse);
		bombaClone.GetComponent<Rigidbody2D>().AddTorque (Random.Range(-20f, 20f)); // Torque é uma ação de girar
	}
}
