using UnityEngine;
using System.Collections;

public class ScreenFadeInOut : MonoBehaviour 
{
	public float fadeSpeed = 1.5f;

	private bool sceneStarting = true;
	// private Color startColor;

	void Awake()
	{
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		// startColor = guiTexture.color;
	}

	void Update()
	{
		if (sceneStarting)
		{
			StartScene();
		}
	}

	void FadeToClear()
	{
		guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
	}

	void FadeToWhite()
	{
		guiTexture.color = Color.Lerp(guiTexture.color, Color.grey, fadeSpeed * Time.deltaTime);
	}

	public void FadeIn(GUITexture texture)
	{
		texture.color = Color.Lerp(texture.color, Color.grey, fadeSpeed * Time.deltaTime);
	}

	public void FadeText(GUIText text)
	{
		text.color = Color.Lerp(text.color, Color.grey, fadeSpeed * Time.deltaTime);
	}

	void StartScene()
	{
		FadeToClear();

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
			// Application.LoadLevel(0);
		}
	}

}
