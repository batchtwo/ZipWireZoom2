using UnityEngine;
using System.Collections;

public class FlashOnOff : MonoBehaviour 
{
	// Script to flash a GUITexture on and off
	// After a given start delay

	public GUITexture textureToFlash;
	public float timeBetweenFlashes = 0.2f;

	private bool isOn = false;
	private float timer = 0f;
	
	private bool initialDelayDone = false;
	private float initialDelay = 2f;

	void Update()
	{
		// Only do if game over
		if (GameOverManager.gameOver)
		{
			timer += Time.deltaTime;

			// Check for the initial delay, if not reached delay, return out
			if (!initialDelayDone)
			{
				if (timer >= initialDelay)
					initialDelayDone = true;
				else
					return;
			}

			// If not already on, turn on. Once enough time has passed, reset and switch
			if (!isOn)
			{
				textureToFlash.enabled = true;
				if (timer >= timeBetweenFlashes)
					SwitchAndReset();
			}

			// If on, do the same
			else
			{
				textureToFlash.enabled = false;
				if (timer >= timeBetweenFlashes)
					SwitchAndReset();
			}
		}
	}

	// Simple method to reset the timer and switch the on state
	private void SwitchAndReset()
	{
		timer = 0f;
		isOn = !isOn;
	}

}
