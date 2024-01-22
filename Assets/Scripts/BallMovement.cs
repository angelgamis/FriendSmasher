using UnityEngine;

public class BallMovement : MonoBehaviour
{
	[Header("Ball Properties")]
	public Rigidbody2D rigid;
	[SerializeField] private Vector2 force;
	[SerializeField] private float speed = 400f;
	[SerializeField] private float friction = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
		if(GetComponent<Rigidbody2D>() != null)
		{
			rigid = GetComponent<Rigidbody2D>();
		}

		// When game starts delay a ball drop
		Invoke("StartRandomBallDrop", 2f);
    }

	private void StartRandomBallDrop()
	{
		force = Vector2.zero;
		force.x = Random.Range(-0.5f, 0.5f);
		force.y = -1;

		this.rigid.AddForce(force.normalized * speed);
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{

	}
}
