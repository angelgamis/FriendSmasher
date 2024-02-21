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

	[Header("Ball")]
	private float maxBallBounceAngle = 60f;

	// Update is called once per frame
	void Update()
	{
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

	private void OnCollisionEnter2D(Collision2D collision)
	{
		BallMovement ball = collision.gameObject.GetComponent<BallMovement>();

		// If collision was the ball
		if (ball != null)
		{
			// Setting collision positions
			Vector3 playerPosition = transform.position;
			Vector2 contactPoint = collision.GetContact(0).point;

			// Setting offset position and player width
			float offset = playerPosition.x - contactPoint.x;
			float playerWidth = collision.otherCollider.bounds.size.x / 2;

			// Calculate Angle
			float currentBallAngle = Vector2.SignedAngle(Vector2.up, ball.rigid.velocity);
			float ballBounceAngle = (offset / playerWidth) * maxBallBounceAngle;
			float newBallAngle = Mathf.Clamp(currentBallAngle + ballBounceAngle, -maxBallBounceAngle, maxBallBounceAngle);

			// Caluclate Rotation
			Quaternion rotation = Quaternion.AngleAxis(newBallAngle, Vector3.forward);

			ball.rigid.velocity = rotation * Vector2.up * ball.rigid.velocity.magnitude;
		}
	}

	public void ResetPlayer()
	{
		transform.position = new Vector2(0, transform.position.y);
	}
}
