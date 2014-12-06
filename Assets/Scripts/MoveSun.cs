using UnityEngine;
using System.Collections;

public class MoveSun : MonoBehaviour 
{
	public Vector3 startPos;
	public Vector3 endPos;

	void Update()
	{
		transform.position = Vector3.Slerp(endPos, startPos, ScoreManager.timeOfDay);
	}
}
