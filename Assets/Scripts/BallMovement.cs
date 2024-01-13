using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Vector3 ballPosition;
	private Rigidbody2D rigid;
	// Give a random X force downwards
	private float force = 3f;
	private float xVelocity;
	private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
		if(GetComponent<Rigidbody2D>() != null)
		{
			rigid = GetComponent<Rigidbody2D>();
		}

		xVelocity = Random.Range(-0.5f, 0.5f);
		velocity = new Vector2(xVelocity, force);
		ballPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		if(rigid != null)
		{
			rigid.AddForce(velocity);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		velocity *= -1;
	}
}
