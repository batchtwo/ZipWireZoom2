using UnityEngine;
using System.Collections;

public class SwingCharacter : MonoBehaviour 
{
	private float Rotation;
	public float SwingSpeed = 8f;

	void Update()
	{
		GetUserInputs();
		ApplyRotation();
	}

	void GetUserInputs()
	{
		Rotation += Input.GetAxis("Horizontal") * SwingSpeed;
	}

	void ApplyRotation()
	{
		// Lerp back to original position
		if (Rotation != 0)
			Rotation = Mathf.Lerp(Rotation, 0f, 6f * Time.deltaTime);

		// Clamp rotation to sides
		Rotation = Mathf.Clamp(Rotation, -100f, 100f);

		//Apply rotation
		transform.localEulerAngles = new Vector3(0, 0, Rotation);
	}

}
