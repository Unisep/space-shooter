using UnityEngine;
using System.Collections;

public class GeradorInimigoAzul : MonoBehaviour {

	public GameObject prefabInimigoAzul;

	private Bounds limitesTela;
	private float timer;

	// Use this for initialization
	void Start () {
		GameObject objetoLimite = GameObject.FindGameObjectWithTag ("LimiteTela");
		limitesTela = objetoLimite.GetComponent<BoxCollider2D> ().bounds; 
		timer = 0;	
	}

	// Update is called once per frame
	void Update () {

		if (ControleJogoScript.Iniciado) {
			timer = timer + Time.deltaTime;
			if(timer > 3){
				GameObject inimigoAzul = (GameObject)Instantiate (prefabInimigoAzul);

				float px = Random.Range (limitesTela.min.x, limitesTela.max.x);
				inimigoAzul.transform.position = new Vector3 (px, transform.position.y, transform.position.z);

				timer = 0;

			}

		}
	}
}
