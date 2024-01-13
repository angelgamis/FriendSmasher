using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Vector3 ballPosition;
	private Rigidbody2D rigid;
	// Give a random X force downwards
	private float xForce;
	private Vector2 force;

    // Start is called before the first frame update
    void Start()
    {
		if(GetComponent<Rigidbody2D>() != null)
		{
			rigid = GetComponent<Rigidbody2D>();
		}

		xForce = Random.Range(-0.5f, 0.5f);
		force = new Vector2(xForce, 1f);
		ballPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		if(rigid != null)
		{
			rigid.AddForce(force);

		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		force *= -1;
	}
}
