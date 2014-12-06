using UnityEngine;
using System.Collections;

public class MoveSun : MonoBehaviour 
{
	public Vector3 startPos;
	public Vector3 endPos;

	void Update()
	{
		// Spherically interpolate between the two positions as the sun sets
		// Based on time of day found in ScoreManager
		
		transform.position = Vector3.Slerp(endPos, startPos, ScoreManager.timeOfDay);
	}
}
