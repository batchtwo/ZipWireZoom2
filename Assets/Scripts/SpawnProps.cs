using UnityEngine;
using System.Collections;

public class SpawnProps : MonoBehaviour 
{
	// Array of prefab GameObjects to be the props. Increase to add more
	public GameObject[] Props = new GameObject[1];

	// Array of locations and rotations. These will be set so they can't appear any old place
	private Vector3[] Locations = new Vector3[2];
	private Vector3[] Rotations = new Vector3[2];

	void Awake()
	{
		// Hard code the locations and rotations
		Locations[0] = new Vector3(-6.3f,-1.45f,40f); // x +/- 3
		Rotations[0] = new Vector3(-3f,-100f,0f); // y +/- 40
		Locations[1] = new Vector3(7.3f,-1.45f,40f);
		Rotations[1] = new Vector3(-9f,113f,3f);
	}

	void Start()
	{
		// Constantly spawn the prefabs
		InvokeRepeating("Spawn", 0f, 1f);
	}

	void Spawn()
	{
		// Randomly pick one of the locations and set location with a +- value so they vary
		int randomSpawnIndex = Random.Range(0,Locations.Length);
		Vector3 location = Locations[randomSpawnIndex];
		location = new Vector3(location.x + Random.Range(-6f, 6f), location.y, location.z);

		// Do the same for rotations
		Vector3 rotation = Rotations[randomSpawnIndex];
		rotation = new Vector3(rotation.x, rotation.y + Random.Range(-40f, 40f), rotation.z);

		// Choose from the props and set the location and rotations
		int randomPropIndex = Random.Range(0, Props.Length);
		Instantiate(Props[randomPropIndex], location, Quaternion.Euler(rotation.x, rotation.y, rotation.z) );
	}

}
