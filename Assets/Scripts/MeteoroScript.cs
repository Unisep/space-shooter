using UnityEngine;
using System.Collections;

public class MeteoroScript : MonoBehaviour {

	private Rigidbody2D body;
	private Vector2 velocidade;

	void Start () {
		velocidade = new Vector2 (0, - Random.Range(200, 350));
		body = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		body.velocity = velocidade * Time.deltaTime;
	}
}
