using UnityEngine;
using System.Collections;

public class ScreenFadeInOut : MonoBehaviour 
{
	// Script used to fade in and out using a guiTexture the size of the screen.
	// Used at the start and end of a game

	public float fadeSpeed = 1.5f;

	private bool sceneStarting = true;
	public bool sceneEnding = false;

	void Awake()
	{
		// Set texture to screen size
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}

	void Update()
	{
		if (sceneStarting)
			StartScene();

		if (sceneEnding)
			EndScene();
	}

	// Used at the beginning to fade in from a colour
	void FadeToClear()
	{
		guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
	}

	// Used at the end to fade in to the colour
	// Template these methods??
	void FadeToWhite()
	{
		guiTexture.color = Color.Lerp(guiTexture.color, Color.grey, fadeSpeed * Time.deltaTime);
	}

	// Used to fade a GUITexture in
	public void FadeIn(GUITexture texture)
	{
		texture.color = Color.Lerp(texture.color, Color.grey, fadeSpeed * Time.deltaTime);
	}

	// Used to fade a GUIText in
	public void FadeText(GUIText text)
	{
		text.color = Color.Lerp(text.color, Color.grey, fadeSpeed * Time.deltaTime);
	}

	void StartScene()
	{
		FadeToClear();

		// If we're close, go fully transparent.
		// Takes too long otherwise
		if (guiTexture.color.a <= 0.05f)
		{
			guiTexture.color = Color.clear;
			guiTexture.enabled = false;
			sceneStarting = false;
		}
	}

	public void EndScene()
	{
		guiTexture.enabled = true;
		FadeToWhite();

		if (guiTexture.color.a >= 0.95f)
		{
			guiTexture.color = Color.grey;
			sceneEnding = false;
		}
	}

}
