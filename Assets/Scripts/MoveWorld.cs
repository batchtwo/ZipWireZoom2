using UnityEngine;
using System.Collections;

public class MoveWorld : MonoBehaviour 
{
	// Quick sketch of infinite moving world.
	// Just move tiles back once they're past the camera

	public static float moveSpeed = 7f;

	void Update()
	{
		if (transform.position.z <= -10f)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 30f);
		}

		transform.position += new Vector3(0f, 0f, 1f * - moveSpeed * Time.deltaTime);
	}


}
