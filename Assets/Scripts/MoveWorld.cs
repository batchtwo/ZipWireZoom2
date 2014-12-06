using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveWorld : MonoBehaviour 
{
	// Infinitely moving world
	// Move tiles towards player, when they're past the view point,
	// Move them back behind the last one.
	// Still not perfect, get some overlapping.

	public static float MoveSpeed = 15f;

	// Variables for speed boosting
	private float speedBoostDuration = 2f;
	private float time;
	private bool boosting;

	// Create a static list of the tiles, belonging to the class.
	// This is so that the furthest back tile will always be accessed in order to place the new one
	public static List<Transform> Tiles = new List<Transform>();

	void Awake()
	{
		// Initialise the correct order of tiles
		Tiles.Add(GameObject.Find("Sea2").transform);
		Tiles.Add(GameObject.Find("Sea1").transform);
		Tiles.Add(GameObject.Find("Sea0").transform);
	}	

	void Update()
	{
		// If the tile is too far behind the camera
		// Move the position to the 3rd tile in the list's position.
		// Then remove that tile from the start of the array
		// And push it onto the end, making it to the new tile at the back

		if (transform.position.z <= -10f)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, Tiles[2].position.z + 10f);
			Tiles.RemoveAt(0);
			Tiles.Add(gameObject.transform);
		}

		// Constantly move the tiles towards the player
		transform.position += new Vector3(0f, 0f, 1f * - MoveSpeed * Time.deltaTime);

		// If we're boosting, increment the time we've been boosting
		if (boosting)
		{
			time += 1 * Time.deltaTime;
			// Once done for long enough, set speed and boosting back to normal
			if (time >= speedBoostDuration)
			{
				MoveSpeed = 15f;
				boosting = false;
			}
		}
	}

	// Subscribe the speed boost method to the special pickup event
	void OnEnable()
	{	
		SpecialPickup.OnPickup += SpeedBoost;
	}

	// Unsubscribe from the event after it has occurred.
	void OnDisable()
	{
		SpecialPickup.OnPickup -= SpeedBoost;
	}

	// Actions to make when speed boosting.
	// Reset the time so we only boost for a set time
	// Change the speed and set 'boosting' to true for use in the Update

	void SpeedBoost()
	{
		time = 0;
		MoveSpeed = 25f;
		boosting = true;
	}

}
