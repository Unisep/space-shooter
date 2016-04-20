using UnityEngine;
using System.Collections;

public class GeradorMeteoroScript : MonoBehaviour
{
	public GameObject prefabMeteoro;
	private Bounds limitesTela;

	private float timer;

	void Start ()
	{
		GameObject objlimite = GameObject.FindGameObjectWithTag ("LimitesTela");
		limitesTela = objlimite.GetComponent<BoxCollider2D> ().bounds;

		timer = 0;
	}

	void Update ()
	{
		if (ControleJogoScript.Iniciado) {
			timer += Time.deltaTime;

			if (timer > 3) {
				GameObject meteoro = (GameObject)GameObject.Instantiate (prefabMeteoro);

				float pX = Random.Range (limitesTela.min.x, limitesTela.max.x);
				meteoro.transform.position = new Vector3 (pX, transform.position.y, transform.position.z);

				timer = 0;
			}
		}
	}
}
