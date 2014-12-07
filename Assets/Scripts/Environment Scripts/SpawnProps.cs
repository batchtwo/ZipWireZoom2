using UnityEngine;
using System.Collections;

public class SpawnProps : MonoBehaviour 
{
	// Array of prefab GameObjects to be the props. Increase to add more
	public GameObject[] Props = new GameObject[1];

	// Array of rotations for added control.
	private Vector3[] Rotations = new Vector3[2];

	void Awake()
	{
		// Hard code the rotations for the bending in effect
		Rotations[0] = new Vector3(-3f,-100f,0f);
		Rotations[1] = new Vector3(-9f,113f,3f);
	}

	void Start()
	{
		// Constantly spawn the prefabs
		InvokeRepeating("Spawn", 0.2f, 0.2f);
	}

	void Spawn()
	{
		// Repeat as long as it isn't game over
		if (!GameOverManager.gameOver)
		{
			// Choose random number, 0 or 1. Left or right.
			// Max is exclusive to range goes to 2
			int randomSpawnIndex = (Random.Range(0,2));

			// Ternary. Get a plus or minus depending on prop being left or right
			// This will be multiplied by the x location to position it correctly
			// left is 1 right is -1
			int leftOrRight = randomSpawnIndex > 0 ? -1 : 1;

			// Initial location set. y and z remain the same. x changes to +- depending on left or right
			Vector3 location = new Vector3(leftOrRight * -6.3f, -1.45f, 40f);

			//Variation is added here, value set because it works well.
			location = new Vector3(location.x + (leftOrRight * Random.Range(-7f, 2f)), location.y, location.z);

			// Choose the correct rotations and vary.
			// Separate so props bend inwards for a jazzy 
			Vector3 rotation = Rotations[randomSpawnIndex];
			rotation = new Vector3(rotation.x, rotation.y + Random.Range(-40f, 40f), rotation.z);

			// Choose from the props and set the location and rotations
			int randomPropIndex = Random.Range(0, Props.Length);
			Instantiate(Props[randomPropIndex], location, Quaternion.Euler(rotation.x, rotation.y, rotation.z) );
		}
	}

}
