using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private Camera mainCam;

	[Header("Mouse")]
	private bool mouseIsDown;
	private Vector3 mouseWorldPosition;

	// x positions
	private float maxMousePosition = 2.137f;
	private float minMousePosition = -2.313f;

	[Header("Player")]
	private Vector3 playerPosition;

	// Update is called once per frame
	void Update()
	{
		//Vector3 inputs = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		//transform.Translate(inputs * 5 * Time.deltaTime);

		// While the mouse is being held down on player move the player to the mouse
		if (mouseIsDown)
		{
			mouseWorldPosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
			ConstrainPosition();
			if(mouseWorldPosition.x < maxMousePosition && mouseWorldPosition.x > minMousePosition) {
				transform.position = mouseWorldPosition;
			}
		}
	}

	private void ConstrainPosition()
	{
		//// Constrain X
		//if (mouseWorldPosition.x <= 2.3f)
		//{
		//	mouseWorldPosition.x = -2.3f;
		//}

		// Constrain Y
		mouseWorldPosition.y = transform.position.y;

		// Constrain Z
		mouseWorldPosition.z = 0;
	}

	// Check when mouse is down and cache to mouseIsDown
	private void OnMouseDown()
	{
		mouseIsDown = true;
	}
	private void OnMouseUp()
	{
		mouseIsDown = false;
	}


}
