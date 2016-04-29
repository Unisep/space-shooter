using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Blink : MonoBehaviour
{
	private SpriteRenderer imageToToggle;

	public float interval = 0.14f;
	public float startDelay = 0f;
	public int duration = 3;

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

			StartCoroutine (JustBlink ());
		}
	}

	public void ToggleState ()
	{
		imageToToggle.enabled = !imageToToggle.enabled;
	}

	public IEnumerator JustBlink ()
	{
		InvokeRepeating ("ToggleState", startDelay, interval);
		yield return new WaitForSeconds (duration);
		StopBlink ();
	}

	void StopBlink ()
	{
		isBlinking = false;
		CancelInvoke ("ToggleState");
	}
}