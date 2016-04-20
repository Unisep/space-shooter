using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControleVidaScript : MonoBehaviour
{
	public Text txtVidas;

	private int totalVidas = 5;
	private int vidasRestantes;

	void Start ()
	{
		vidasRestantes = totalVidas;
		updateTextView ();
	}

	void Update ()
	{
	}

	public void DecreaseOne ()
	{
		vidasRestantes -= 1;

		updateTextView ();
	}

	public bool hasRemaining ()
	{
		return vidasRestantes > 0;
	}

	void updateTextView ()
	{
		txtVidas.text = vidasRestantes.ToString ("00");
	}
}
