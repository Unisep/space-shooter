using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
	public GameObject prefExplosaoMeteoro;
	public GameObject prefExplosaoEnemy;
	public GameObject prefExplosaoPlayer;
	public GameObject prefabLaser;

	private Blink turbinaEsq;
	private Blink turbinaDir;
	private Blink ship;

	private ControleVidaScript vida;
	private BoxCollider2D screenLimit;
	private GameObject lancadorLaser;
	private Rigidbody2D body;
	private Vector2 origin;
	private float direction;
	private bool Dead = false;

	private AudioSource somTiro;

	void Start ()
	{
		ship = GetComponent<Blink> ();
		GameObject[] turbinas = GameObject.FindGameObjectsWithTag ("Turbina");
		turbinaEsq = turbinas [0].GetComponent<Blink> ();
		turbinaDir = turbinas [1].GetComponent<Blink> ();

		GameObject obj = GameObject.FindGameObjectWithTag ("LimitesTela");
		screenLimit = obj.GetComponent<BoxCollider2D> ();

		direction = 0;
		body = GetComponent<Rigidbody2D> ();
		origin = body.position;
		somTiro = GetComponent<AudioSource> ();

		lancadorLaser = GameObject.FindGameObjectWithTag ("Lancador");
		vida = GetComponent<ControleVidaScript> ();
	}

	void Update ()
	{
		direction = Input.GetAxis ("Horizontal");

		if (Input.GetKeyDown (KeyCode.R) && !ControleJogoScript.Iniciado) {
			ControleJogoScript.ReiniciarJogo ();
			TogglePLayerFromScreen ();
			vida.Reset ();
			gameObject.GetComponent<ControleScoreScript> ().clearScore ();
			body.position = origin;
			Dead = false;
		} else if (!Dead && Input.GetButtonDown ("Fire1")) {
			if (ControleJogoScript.Iniciado) {
				Instantiate (prefabLaser, lancadorLaser.transform.position, lancadorLaser.transform.rotation);
				somTiro.Play ();
			} else {
				ControleJogoScript.IniciarJogo ();
			}
		}
	}

	void FixedUpdate ()
	{
		if (ControleJogoScript.Iniciado) {
			body.velocity = new Vector2 (direction * 370 * Time.deltaTime, 0);
			body.position = new Vector2 (Mathf.Clamp (body.position.x, screenLimit.bounds.min.x, screenLimit.bounds.max.x),
				body.position.y);
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		bool isAsteroid = col.gameObject.CompareTag ("Meteoro");
		bool isEnemyLaser = col.gameObject.CompareTag ("LaserEnemy");
		bool isEnemy = col.gameObject.CompareTag ("GreenEnemy");
			
		if (isAsteroid || isEnemyLaser) {
			DestroyEnemy (col.gameObject, isAsteroid, isEnemyLaser, isEnemy);

			vida.DecreaseOne ();

			if (vida.lastLife ())
				DestroyMySelf ();
			else
				StartBlink ();
			
		} else if (isEnemy) {
			vida.Kill ();

			DestroyEnemy (col.gameObject, isAsteroid, isEnemyLaser, isEnemy);
			DestroyMySelf ();
		}
	}

	void DestroyEnemy (GameObject enemy, bool isAsteroid, bool isEnemyLaser, bool isEnemy)
	{
		GameObject prefabExplosao = null;

		if (isAsteroid)
			prefabExplosao = prefExplosaoMeteoro;
		else if (isEnemyLaser || isEnemy)
			prefabExplosao = prefExplosaoEnemy;

		Destroy (enemy);
		Instantiate (prefabExplosao, enemy.transform.position, enemy.transform.rotation);
	}

	void StartBlink ()
	{
		turbinaEsq.StartBlink ();
		turbinaDir.StartBlink ();

		ship.StartBlink ();
	}

	void DestroyMySelf ()
	{
		Dead = true;
		TogglePLayerFromScreen ();
		Instantiate (prefExplosaoPlayer, transform.position, transform.rotation);

		ControleJogoScript.TerminarJogo (gameObject.GetComponent<ControleScoreScript> ().lblScore.text);
	}

	void TogglePLayerFromScreen ()
	{
		turbinaEsq.ToggleState ();
		turbinaDir.ToggleState ();
	
		ship.ToggleState ();
	}
}
