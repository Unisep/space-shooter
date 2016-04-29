using UnityEngine;
using System.Collections;

public class InimigoAzul : MonoBehaviour {

	private Rigidbody2D body;

	private Vector2 velocidade;

	// Use this for initialization
	void Start () {
		velocidade = new Vector2 (0, -Random.Range (100, 250));
		body.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		body.velocity = velocidade * Time.deltaTime; 
	}

}
