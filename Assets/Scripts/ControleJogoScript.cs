using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControleJogoScript : MonoBehaviour
{
	public static bool Iniciado = false;

	private static GameObject cnvJogo;
	private static GameObject cnvFim;
	private static Text lblLastScore;

	static ControleJogoScript ()
	{
		cnvJogo = GameObject.FindGameObjectWithTag ("CanvasJogo");
		cnvJogo.SetActive (false);

		cnvFim = GameObject.FindGameObjectWithTag ("CanvasFim");
		cnvFim.SetActive (false);
	}

	public static void IniciarJogo ()
	{
		Iniciado = true;

		GameObject cnvInicio = GameObject.FindGameObjectWithTag ("CanvasInicio");
		cnvInicio.SetActive (false);
		cnvJogo.SetActive (true);
	}

	public static void TerminarJogo (string lastScore)
	{
		Iniciado = false;

		cnvJogo.SetActive (false);
		cnvFim.SetActive (true);

		lblLastScore = GameObject.FindGameObjectWithTag ("LastScore").GetComponent<Text> ();
		lblLastScore.text = lastScore;
	}

	public static void ReiniciarJogo ()
	{
		Iniciado = true;

		cnvJogo.SetActive (true);
		cnvFim.SetActive (false);
	}
}
	