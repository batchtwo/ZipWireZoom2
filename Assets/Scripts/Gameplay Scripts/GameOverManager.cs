using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour 
{
	// public float restartDelay = 0.2f;
	public GameObject screenFade;
	public GameObject gameOverScreen;
	public GameObject gameOverText;
	public GameObject againTexture;

	private ScreenFadeInOut screenFadeInOut;

	// private float restartTimer;
	public static bool gameOver;

	void Awake()
	{
		gameOver = false;
		screenFadeInOut = screenFade.GetComponent <ScreenFadeInOut> ();
		// restartTimer = 1f;
	}

	void Update()
	{
		// If time of day is over, the game is over!
		if (ScoreManager.timeOfDay <= 0f)
		{
			gameOver = true;
			// restartTimer += Time.deltaTime;
			MoveWorld.MoveSpeed = 0f;

			// Fade in the background fader and the gameover image
			screenFadeInOut.EndScene();
			screenFadeInOut.FadeIn(gameOverScreen.GetComponent<GUITexture>());

			// Set the end score text
			GUIText endText = gameOverText.GetComponent<GUIText>();
			endText.text = "Distance \n Travelled: \n"
						   + ScoreManager.score + "m";

			// Enable the text so it is visible
		    endText.enabled = true;

		    // Enable the restart button
		    againTexture.SetActive(true);
		}
	}
}
