using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Blink : MonoBehaviour
{
	private SpriteRenderer imageToToggle;

	private float interval = 0.14f;
	private float startDelay = 0f;
	public bool currentState = true;
	public bool defaultState = true;
	bool isBlinking = false;

	void Start ()
	{
		imageToToggle = GetComponent<SpriteRenderer> ();
		imageToToggle.enabled = defaultState;
	}

	public void StartBlink ()
	{
		if (isBlinking)
			return;
		
		if (imageToToggle != null) {
			isBlinking = true;

			StartCoroutine (Routinee ());
		}
	}

	public void ToggleState ()
	{
		imageToToggle.enabled = !imageToToggle.enabled;
	}

	public IEnumerator Routinee ()
	{
		InvokeRepeating ("ToggleState", startDelay, interval);
		yield return new WaitForSeconds (3);
		StopBlink ();
	}

	void StopBlink ()
	{
		isBlinking = false;
		CancelInvoke ("ToggleState");
	}
}