using UnityEngine;

public class BallMovement : MonoBehaviour
{
	[Header("Ball Properties")]
	public Rigidbody2D rigid;
	[SerializeField] private Vector2 force;
	[SerializeField] private float speed = 400f;

    // Start is called before the first frame update
    void Start()
    {
		if(GetComponent<Rigidbody2D>() != null)
		{
			rigid = GetComponent<Rigidbody2D>();
		}

		ResetBall();
    }

	private void StartRandomBallDrop()
	{
		force = Vector2.zero;
		force.x = Random.Range(-0.5f, 0.5f);
		force.y = -0.5f;

		this.rigid.AddForce(force.normalized * speed);
	}

	public void ResetBall()
	{
		// Zeroing out position and velocity
		transform.transform.position = Vector2.zero;
		rigid.velocity = Vector2.zero;

		Invoke("StartRandomBallDrop", 1.5f);
	}
}
