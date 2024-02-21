using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float[] states;
    [SerializeField] private Sprite endSprite;
    [SerializeField] private int health;
	[SerializeField] private int points = 10;
	public int Health => health;
	public int Points => points;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	// Start is called before the first frame update
	void Start()
    {
		if (health == 1)
		{
			spriteRenderer.sprite = endSprite;
		}
		gameObject.transform.localScale = new Vector2(states[health - 1], states[health - 1]);
    }

	private void Hit()
	{
		// Lower health
		health--;

		// If health is depleted turn off object
		if(health <= 0)
		{
			gameObject.SetActive(false);
		}
		// If health is at 1 change the sprite to end sprite
		else if(health == 1)
		{
			spriteRenderer.sprite = endSprite;

			// Update the scale of the object with new 
			gameObject.transform.localScale = new Vector2(states[health - 1], states[health - 1]);
		}
		else
		{
			// Update the scale of the object with new 
			gameObject.transform.localScale = new Vector2(states[health - 1], states[health - 1]);
		}

		FindObjectOfType<GameManager>().Hit(this);
	}

	// When ball collides with brick call Hit function
	private void OnCollisionEnter2D(Collision2D collision)
	{
		BallMovement ball = collision.gameObject.GetComponent<BallMovement>();

		// If collision was the ball
		if (ball != null)
		{
			Hit();
		}
	}
}
