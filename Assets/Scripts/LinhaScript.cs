using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LinhaScript : MonoBehaviour {

	int numeroDeVertices = 0;
	LineRenderer linha;
	bool apertandoBotaoMouse = false;
	public GameObject Boom;

	public AudioClip audio;
	GameObject FonteDeSom;

	public AudioClip audioExp;
	GameObject FonteDeSomExp;


	// Use this for initialization
	void Start () {
		linha = GetComponent<LineRenderer> ();
		FonteDeSom = GameObject.FindGameObjectWithTag("SomLamina");
		FonteDeSomExp = GameObject.FindGameObjectWithTag("SomExplosao");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			apertandoBotaoMouse = true;
		}
		if (Input.GetMouseButtonUp(0)) {
			apertandoBotaoMouse = false;
		}
		if (apertandoBotaoMouse) {
			CriarLinha();
		} else {
			DeletarLinha();
		}
	}

	void CriarLinha() {
		FonteDeSom.GetComponent<AudioSource>().clip = audio;
		FonteDeSom.GetComponent<AudioSource>().Play();
		//linha.SetVertexCount(numeroDeVertices + 1);
		linha.positionCount = numeroDeVertices + 1;
		Vector3 posicaoDoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		linha.SetPosition(numeroDeVertices, posicaoDoMouse);
		numeroDeVertices++;
		BoxCollider2D colisorLinha = gameObject.AddComponent<BoxCollider2D> (); // Cria o component atravez do script, no caso BoxCollider2D
		colisorLinha.transform.position = linha.transform.localPosition; // A posição do colisor vai ser igual a posição da linha
		colisorLinha.size = new Vector2(0.1f, 0.1f); // O tamanho do colisor da linha
	}

	void DeletarLinha() {
		numeroDeVertices = 0;
		//linha.SetVertexCount (0);
		linha.positionCount = 0;
		BoxCollider2D[] colisoresDaLinha = GetComponents<BoxCollider2D> (); // Pegando todos os colisores da linha e guardando dentro de um array

		foreach(BoxCollider2D colisor in colisoresDaLinha) {
			Destroy (colisor);
		}
	}

	void OnCollisionEnter2D(Collision2D obj) {
		if(obj.gameObject.tag == "Bomba") {
			FonteDeSomExp.GetComponent<AudioSource>().clip = audioExp;
			FonteDeSomExp.GetComponent<AudioSource>().Play();
			GameObject boomClone = Instantiate(Boom, obj.transform.position, Quaternion.identity) as GameObject;
			Destroy(boomClone, 5f);
			Destroy(obj.gameObject);
			GameOver();
		}
	}

	void RecarregarFase() {
		SceneManager.LoadScene("GameOver");
	}

	void GameOver() {
		Invoke("RecarregarFase", 1.5f); //Chama outra função depois de um certo tempo
	}
}
