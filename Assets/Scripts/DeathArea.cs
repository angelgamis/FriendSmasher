using UnityEngine;

public class DeathArea : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		BallMovement ball = collision.gameObject.GetComponent<BallMovement>();

		// If collision was the ball
		if (ball != null)
		{
			FindObjectOfType<GameManager>().LooseLife();
		}
	}
}
