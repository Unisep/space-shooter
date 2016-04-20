﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
	public GameObject prefExplosaoMeteoro;
	public GameObject prefExplosaoPlayer;
	public GameObject prefabLaser;

	private BoxCollider2D screenLimit;
	private GameObject lancadorLaser;
	private Rigidbody2D body;
	private float direction;

	private AudioSource somTiro;

	void Start ()
	{
		GameObject obj = GameObject.FindGameObjectWithTag ("LimitesTela");
		screenLimit = obj.GetComponent<BoxCollider2D> ();

		direction = 0;
		body = GetComponent<Rigidbody2D> ();
		somTiro = GetComponent<AudioSource> ();

		lancadorLaser = GameObject.FindGameObjectWithTag ("Lancador");
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
		}
	}

	void FixedUpdate ()
	{
		if (ControleJogoScript.Iniciado) {
			body.velocity = new Vector2 (direction * 300 * Time.deltaTime, 0);
			body.position = new Vector2 (Mathf.Clamp (body.position.x, screenLimit.bounds.min.x, screenLimit.bounds.max.x),
				body.position.y);
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.CompareTag ("Meteoro")) {			
			Destroy (gameObject);
			Destroy (col.gameObject);

			Instantiate (prefExplosaoMeteoro, col.gameObject.transform.position, col.gameObject.transform.rotation);
			Instantiate (prefExplosaoPlayer, transform.position, transform.rotation);
		}
	}
}