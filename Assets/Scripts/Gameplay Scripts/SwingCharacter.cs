using UnityEngine;
using System.Collections;

public class SwingCharacter : MonoBehaviour 
{
	// Controlling the character swing
	// Pivot must be set to the top of the swing rope

	// Change for a more reactive swing
	public float swingSpeed = 8f;

	private float rotation;

	void Update()
	{
		GetUserInputs();
		ApplyRotation();
	}

	void GetUserInputs()
	{
		// Rotation is simply the horizontal axis, so arrows keys or A & D
		rotation += Input.GetAxis("Horizontal") * swingSpeed;
	}

	void ApplyRotation()
	{
		// Always lerp back to original position
		if (rotation != 0)
			rotation = Mathf.Lerp(rotation, 0f, 6f * Time.deltaTime);

		// Clamp rotation to sides
		rotation = Mathf.Clamp(rotation, -100f, 100f);

		//Apply rotation
		transform.localEulerAngles = new Vector3(36f, rotation/2f, rotation);
	}

}
