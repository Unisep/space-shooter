using UnityEngine;
using System.Collections;

public class ExplosaoScript : MonoBehaviour
{
	private ParticleSystem part;

	void Start ()
	{
		part = GetComponent<ParticleSystem> ();
	}

	void Update ()
	{
		if (!part.isPlaying) {
			Destroy (gameObject);
		}
	}
}
