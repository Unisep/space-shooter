using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControleScoreScript : MonoBehaviour
{
	private int score;
	private float timer;

	private int minutos;
	private int segundos;

	public Text lblTimer;
	public Text lblScore;

	void Start ()
	{
		score = 0;
		timer = 0;

		minutos = 0;
		segundos = 0;
	}

	void Update ()
	{
		if (ControleJogoScript.Iniciado) {
			timer += Time.deltaTime;

			if (timer > 1) {
				timer = 0;

				segundos++;

				if (segundos == 60) {
					minutos++;
					segundos = 0;
				}

				lblTimer.text = minutos.ToString ("00") + ":" + segundos.ToString ("00");
			}
		}
	}

	public void updateScore (int pontos)
	{
		score = score + pontos;
		lblScore.text = score.ToString ();
	}
}
