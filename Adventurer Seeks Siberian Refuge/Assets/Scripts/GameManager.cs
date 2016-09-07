using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int lives = 3;
	public int bricks = 24;
	public float resetDelay = 1f;
	
	public int currentPage = 1;
	
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	
	public static GameManager instance = null;

	private GameObject clonePaddle;

	// Use this for initialization
	void Awake() 
	{		
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);	

		DontDestroyOnLoad(gameObject);
		if (SceneManager.GetActiveScene().name == "level1")
		{
			Setup ();
		}
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
			SceneManager.LoadScene(1);
	}

	public void Setup()
	{
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
		Instantiate (bricksPrefab, transform.position, Quaternion.identity);
	}

	void CheckGameOver()
	{
		if (bricks < 1) 
		{
			youWon.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("ResetWin", resetDelay);
		}

		if (lives < 1) {
			gameOver.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("ResetLose", resetDelay);
		}
	}

	void ResetLose()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (0);
	}
	
	void ResetWin()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (1);
	}

	public void LoseLife()
	{
		lives--;
		livesText.text = "Lives: " + lives;
		Instantiate (deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy (clonePaddle);
		Invoke ("SetupPaddle", resetDelay);
		CheckGameOver ();
	}

	void SetupPaddle()
	{
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
	}

	public void DestroyBrick()
	{
		bricks--;
		CheckGameOver ();
	}
}