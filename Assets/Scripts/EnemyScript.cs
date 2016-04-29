using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
	public GameObject prefExplosaoEnemy;
	public GameObject prefabLaser;

	// private Blink turbinaEsq;
	// private Blink turbinaDir;
	// private Blink ship;

	private ControleVidaScript vida;
	private BoxCollider2D screenLimit;
	private GameObject lancadorLaser;
	private Rigidbody2D body;

	private Vector2 velocidade;

	private AudioSource somTiro;

	void Start ()
	{
		//GameObject[] blinkObjects = GameObject.FindGameObjectsWithTag ("GreenEnemy");
		//turbinaEsq = blinkObjects [0].GetComponent<Blink> ();
		//turbinaDir = blinkObjects [1].GetComponent<Blink> ();
		//ship = blinkObjects [2].GetComponent<Blink> ();

		GameObject obj = GameObject.FindGameObjectWithTag ("LimitesTela");
		screenLimit = obj.GetComponent<BoxCollider2D> ();

		body = GetComponent<Rigidbody2D> ();
		somTiro = GetComponent<AudioSource> ();

		lancadorLaser = GameObject.FindGameObjectWithTag ("LancadorEnemy");
		vida = GetComponent<ControleVidaScript> ();

		velocidade = Vector2.down * Random.Range (180, 220);
		InvokeRepeating ("FireEnemyBullet", 1f, Random.Range (0.4f, 0.9f));
	}

	void FixedUpdate ()
	{
		if (ControleJogoScript.Iniciado) {
			body.velocity = velocidade * Time.deltaTime;
			body.position = new Vector2 (Mathf.Clamp (body.position.x, screenLimit.bounds.min.x, screenLimit.bounds.max.x),
				body.position.y);
		}
	}

	void FireEnemyBullet ()
	{
		if (lancadorLaser != null) {
			Instantiate (prefabLaser, lancadorLaser.transform.position, lancadorLaser.transform.rotation);
			//somTiro.Play ();
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.CompareTag ("LaserPlayer")) {
			Destroy (col.gameObject);

			vida.DecreaseOne ();

			if (vida.lastLife ()) {
				Destroy (gameObject);
				Instantiate (prefExplosaoEnemy, transform.position, transform.rotation);	
				//} else {
				//	StartBlink ();
			}
		}
	}

	//void StartBlink ()
	//{
	//	turbinaEsq.StartBlink ();
	//	turbinaDir.StartBlink ();

	//	ship.StartBlink ();
	//}
}
