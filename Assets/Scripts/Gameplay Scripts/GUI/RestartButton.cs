using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour 
{
	void OnMouseDown()
	{
		Application.LoadLevel(0);
	}
}
