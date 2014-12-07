using UnityEngine;
using System.Collections;

public class MoveProp : MonoBehaviour 
{
	void Update()
	{
		// Move prop towards player
		transform.position += new Vector3(0f, 0f, 1f * - MoveWorld.MoveSpeed * Time.deltaTime);

		// Destroy prop if behind view
		if (transform.position.z <= -15f)
			Destroy(gameObject);
	}
}
