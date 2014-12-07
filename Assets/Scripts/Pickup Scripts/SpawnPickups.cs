using UnityEngine;
using System.Collections;

public class SpawnPickups : MonoBehaviour 
{
	// Script to spawn all the collectible items.
	// Banana pickups will be stored as prefabs in pattern formations
	// Any number of patterns can be stored and added here
	// prefab positions should be the intended spawn position

	// Array of pickup prefabs
	public GameObject[] Pickups = new GameObject[2];
	public float timeBetweenSpawns = 0.2f;

	// Special collectible to speed up game
	public GameObject Special;

	private float timer = 0f;

	// Possible locations of special collectible
	private Vector3[] Locations = new Vector3[3];

	void Start()
	{
		// Constantly spawn collectibles every timeBetweenSpawns seconds
		// Better way of doing this: every time interval.
		// Reset a time after so many seconds.

		// Hardcoded locations for the special collectable, just middle, left and right.
		Locations[0] = new Vector3(0f, 3.2f, 50f);
		Locations[1] = new Vector3(-2.8f, 4.5f, 50f);
		Locations[2] = new Vector3(2.8f, 4.5f, 50f);
	}

	void Update()
	{
		timer += Time.deltaTime;

		// Was using invokeRepeating but this is better
		// More control, can make time gaps more/less frequent
		if (timer >= timeBetweenSpawns)
		{
			Spawn();
			timer = 0f;

			// Call the special pickup here.
			// Could have it's own timer though
			// Chance in that method so won't be every time
			Invoke("SpawnSpecial", timeBetweenSpawns/2f);
		}

	}

	// Choose a random prefab from the array and instantiate it in the original position
	void Spawn()
	{
		// If it isn't game over
		if (!GameOverManager.gameOver)
		{
			int pickupPatternIndex = Random.Range(0, Pickups.Length);
			Instantiate (Pickups[pickupPatternIndex], Pickups[pickupPatternIndex].transform.position, Pickups[pickupPatternIndex].transform.rotation);
		}
	}

	// Spawn the special object, but not every time.
	// Shouldn't be overly frequent
	void SpawnSpecial()
	{
		// If it isn't game over
		if (!GameOverManager.gameOver)
		{
			// Change seconds number to get less likely spawns
			int rand = Random.Range(0,4);

			// Spawn the object in one of the locations
			if(rand == 1)
			{
				// Choose a location
				int locationIndex = Random.Range(0, Locations.Length);
				Instantiate (Special, Locations[locationIndex], Special.transform.rotation);
			}
		}
	}

}
