using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LaserPlayerScript : MonoBehaviour
{
	public GameObject prefExplosaoMeteoro;

	private Rigidbody2D body;
	private Vector2 origem;
	private ControleScoreScript controleScore;

	void Start ()
	{		
		body = GetComponent<Rigidbody2D> ();
		origem = transform.position;

		controleScore = GameObject.FindGameObjectWithTag ("Player")
			.GetComponent<ControleScoreScript> ();
	}

	void Update ()
	{
		body.velocity = Vector2.up * 750 * Time.deltaTime;
		float distance = Vector2.Distance (origem, transform.position);

		if (distance > 15) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.CompareTag ("Meteoro")) {
			Instantiate (prefExplosaoMeteoro, col.gameObject.transform.position, col.gameObject.transform.rotation);

			controleScore.updateScore (10);

			Destroy (col.gameObject);
			Destroy (gameObject);
		}
	}
}
