using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour 
{
	public GameObject screenFade;
	public GameObject gameOverScreen;
	public GameObject gameOverText;
	public GameObject againTexture;

	private ScreenFadeInOut screenFadeInOut;
	private GUITexture gameOverTexture;

	public static bool gameOver;

	void Awake()
	{
		gameOver = false;
		// Set these values in awake rather than when need
		// More robust, may cause issues finding them at run time
		screenFadeInOut = screenFade.GetComponent <ScreenFadeInOut> ();
		gameOverTexture = gameOverScreen.GetComponent <GUITexture> ();
	}

	void Update()
	{
		// If time of day is over, the game is over!
		if (ScoreManager.timeOfDay <= 0f)
		{
			gameOver = true;
			MoveWorld.MoveSpeed = 0f;

			// Fade in the background fader and the gameover image
			screenFadeInOut.sceneEnding = true;
			// screenFadeInOut.EndScene();
			screenFadeInOut.FadeIn(gameOverTexture);

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
