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

	public void DecreaseOne ()
	{
		vidasRestantes -= 1;

		updateTextView ();
	}

	public bool lastLife ()
	{
		return vidasRestantes == 0;
	}

	void updateTextView ()
	{
		txtVidas.text = vidasRestantes.ToString ("00");
	}
}
