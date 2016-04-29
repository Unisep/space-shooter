using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControleVidaScript : MonoBehaviour
{
	public Text txtVidas;

	public int totalVidas = 5;
	private int vidasRestantes;

	void Start ()
	{
		vidasRestantes = totalVidas;
		updateTextView ();
	}

	public void Reset(){
		Start();
	}

	public void DecreaseOne ()
	{
		vidasRestantes -= 1;

		updateTextView ();
	}

	public void Kill ()
	{
		vidasRestantes = 0;

		updateTextView ();
	}

	public bool lastLife ()
	{
		return vidasRestantes == 0;
	}

	void updateTextView ()
	{
		if (txtVidas != null)
			txtVidas.text = vidasRestantes.ToString ("00");
	}
}
