using UnityEngine;
using System.Collections;

public class SpawnPickups : MonoBehaviour 
{
	public GameObject Pickup;

	private Vector3[] Locations = new Vector3[3];

	void Start()
	{
		InvokeRepeating("Spawn", 0.2f, 0.2f);

		Locations[0] = new Vector3(0f, 2f, 22f);
		Locations[1] = new Vector3(-2f, 3.6f, 22f);
		Locations[2] = new Vector3(2.2f, 3.6f, 22f);
	}

	void Spawn()
	{
		int spawnPointIndex = Random.Range (0, Locations.Length);
		Instantiate (Pickup, Locations[spawnPointIndex], Pickup.transform.rotation);
	}

}
