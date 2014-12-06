using UnityEngine;
using System.Collections;

public class Gradient : MonoBehaviour 
{
	// Simple script to create a 2D gradient from top to bottom between 2 colours.
	// Must be used on a 4 vert quad
	
	public Color topColor;
	public Color bottomColor;

	public Color topSunsetColor;
	public Color bottomSunsetColor;

	Mesh mesh;
	Color[] colors;

	void Start()
	{
		// Get the vertex data to store the colours
		mesh = GetComponent <MeshFilter> ().mesh;
		colors = new Color[mesh.vertices.Length];

		// Set the initial top and bottom colours, which will linearlly interpolate giving a great gradient
		colors[0] = bottomColor;
		colors[1] = topColor;
		colors[2] = bottomColor;
		colors[3] = topColor;

		mesh.colors = colors;
	}

	void Update()
	{
		// Lerp the colours from normal to sunset by time of day
		// This will only be between 0 and 1.
		// Because time of day goes slightly over 1, this means we won't be lerping the whole time
		// Gives the effect of 'normal day' before sunset

		Color lerpedColorTop = Color.Lerp(topSunsetColor, topColor, ScoreManager.timeOfDay);
		Color lerpedColorBottom = Color.Lerp(bottomSunsetColor, bottomColor, ScoreManager.timeOfDay);

		// Assign the new lerped colours
		colors[0] = lerpedColorBottom;
		colors[1] = lerpedColorTop;
		colors[2] = lerpedColorBottom;
		colors[3] = lerpedColorTop;

		mesh.colors = colors;
	}
}
