using UnityEngine;
using System.Collections;

public class ControleJogoScript : MonoBehaviour
{
	public static bool Iniciado = false;

	private static GameObject cnvJogo;
	private ControleVidaScript controleVida;

	static ControleJogoScript ()
	{
		cnvJogo = GameObject.FindGameObjectWithTag ("CanvasJogo");
		cnvJogo.SetActive (false);
	}

	public static void IniciarJogo ()
	{
		Iniciado = true;

		GameObject cnvInicio = GameObject.FindGameObjectWithTag ("CanvasInicio");
		cnvInicio.SetActive (false);
		cnvJogo.SetActive (true);
	}

	public static void TerminarJogo ()
	{
		Iniciado = false;

		GameObject cnvFim = GameObject.FindGameObjectWithTag ("CanvasFim");
		cnvFim.SetActive (false);
		cnvFim.SetActive (true);
		}
	}
	