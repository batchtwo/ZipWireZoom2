using UnityEngine;
using System.Collections;

public class Gradient : MonoBehaviour 
{
	// Simple script to create a 2D gradient from top to bottom between 2 colours.
	// Must be used on a 4 vert quad
	
	public Color topColor;
	public Color bottomColor;

	void Start()
	{
		Mesh mesh = GetComponent <MeshFilter> ().mesh;
		Color[] colors = new Color[mesh.vertices.Length];
		colors[0] = bottomColor;
		colors[1] = topColor;
		colors[2] = bottomColor;
		colors[3] = topColor;

		mesh.colors = colors;
	}
}
