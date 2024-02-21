using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[Header("*** Global Values ***")]
    public int level = 1;
    public int score = 0;
    public int lives = 3;

	[Header("*** Level References ***")]
	private BallMovement ball;
	private PlayerMovement player;
	private Brick[] bricks;

	[Header("*** Debugs ***")]
	[SerializeField] private bool debug_DontStartLevel1; 

	private void Awake()
	{
		DontDestroyOnLoad(this.gameObject);

		SceneManager.sceneLoaded += LevelLoaded;
	}

	// Start is called before the first frame update
	private void Start()
    {
		// If debug is not on, load new game on start
		if (!debug_DontStartLevel1)
		{
			NewGame();
		}
	}

	private void NewGame()
	{
		this.score = 0;
		this.lives = 3;

		LoadLevel(1);
	}

	private void LoadLevel(int level)
	{
		this.level = level;

		SceneManager.LoadScene("Level" + level);
	}

	private void LevelLoaded(Scene scene, LoadSceneMode mode)
	{
		ball = FindObjectOfType<BallMovement>();
		player = FindObjectOfType<PlayerMovement>();
		bricks = FindObjectsOfType<Brick>();
	}

	private void ResetLevel()
	{
		ball.ResetBall();
		player.ResetPlayer();
	}

	private void GameOver()
	{
		// Load Game Over Scene
		NewGame();
	}

	private bool Cleared()
	{
		for(int i = 0; i < bricks.Length; i++)
		{
			if (bricks[i].gameObject.activeInHierarchy)
			{
				return false;
			}
		}

		return true;
	}

	public void LooseLife()
	{
		--lives;

		if(lives > 0)
		{
			ResetLevel();
		}
		else
		{
			GameOver();
		}
	}

	public void Hit(Brick brick)
	{
		score += brick.Points;

		if (Cleared())
		{
			LoadLevel(level + 1);
			Debug.Log("CLEARED BOARD");
		}
	}
}
