using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
	public GameObject prefExplosaoMeteoro;
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

		if (Input.GetButtonDown ("Fire1")) {
			if (ControleJogoScript.Iniciado) {
				Instantiate (prefabLaser, lancadorLaser.transform.position, lancadorLaser.transform.rotation);
				somTiro.Play ();
			} else {
				ControleJogoScript.IniciarJogo ();
			}
		} else if(Input.GetKeyDown (KeyCode.R) && !ControleJogoScript.Iniciado) {
			ControleJogoScript.ReiniciarJogo ();
			TogglePLayerFromScreen();
			vida.Reset();
			body.position = origin;
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

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.CompareTag ("Meteoro")) {
			DestroyEnemy (col.gameObject);

			vida.DecreaseOne ();

			if (vida.lastLife ()) {
				// Destroy (gameObject);
				TogglePLayerFromScreen();
				Instantiate (prefExplosaoPlayer, transform.position, transform.rotation);
				ControleJogoScript.TerminarJogo();
			} else {
				StartBlink ();
			}
		}
	}

	void DestroyEnemy (GameObject enemy)
	{
		Destroy (enemy);
		Instantiate (prefExplosaoMeteoro, enemy.transform.position, enemy.transform.rotation);
	}

	void StartBlink ()
	{
		turbinaEsq.StartBlink ();
		turbinaDir.StartBlink ();

		ship.StartBlink ();
	}

	void TogglePLayerFromScreen ()
	{
		turbinaEsq.ToggleState ();
		turbinaDir.ToggleState ();
	
		ship.ToggleState();
	}
}
