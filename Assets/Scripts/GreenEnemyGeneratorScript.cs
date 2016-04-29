using UnityEngine;
using System.Collections;

public class GreenEnemyGeneratorScript : MonoBehaviour
{
	public GameObject prefabEnemy;
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
				GameObject enemy = (GameObject)GameObject.Instantiate (prefabEnemy);

				float pX = Random.Range (limitesTela.min.x, limitesTela.max.x);
				enemy.transform.position = new Vector3 (pX, transform.position.y, transform.position.z);

				timer = 0;
			}
		}
	}
}
