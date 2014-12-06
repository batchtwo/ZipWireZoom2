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
		mesh = GetComponent <MeshFilter> ().mesh;
		colors = new Color[mesh.vertices.Length];

		colors[0] = bottomColor;
		colors[1] = topColor;
		colors[2] = bottomColor;
		colors[3] = topColor;

		mesh.colors = colors;
	}

	void Update()
	{
		Color lerpedColorTop = Color.Lerp(topSunsetColor, topColor, ScoreManager.timeOfDay);
		Color lerpedColorBottom = Color.Lerp(bottomSunsetColor, bottomColor, ScoreManager.timeOfDay);

		colors[0] = lerpedColorBottom;
		colors[1] = lerpedColorTop;
		colors[2] = lerpedColorBottom;
		colors[3] = lerpedColorTop;

		mesh.colors = colors;
	}
}
