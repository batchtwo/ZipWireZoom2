using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour 
{
	float moveSpeed = 10f;

	void Update()
	{
		transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - moveSpeed * Time.deltaTime);

		if (transform.position.z <= -10)
		{
			Destroy(gameObject, 0f);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			ScoreManager.timeOfDay += 0.03f;
			// ScoreManager.score += 1;
			Destroy(gameObject, 0f);
		}
	}
}
