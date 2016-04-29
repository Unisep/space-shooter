using UnityEngine;
using System.Collections;

public class LaserEnemyScript : MonoBehaviour
{
	private Rigidbody2D body;
	private Vector2 origem;

	void Start ()
	{		
		body = GetComponent<Rigidbody2D> ();
		origem = transform.position;
	}

	void Update ()
	{
		body.velocity = Vector2.down * Random.Range (280, 550) * Time.deltaTime;
		float distance = Vector2.Distance (origem, transform.position);

		if (distance > 20) {
			Destroy (gameObject);
		}
	}
}
