using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int lives;
	public int bricks;
	public float resetDelay = 1f;
	
	public Text livesText;
	public Text upgradeText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	
	public static GameManager instance = null;

	private GameObject clonePaddle;

	public static float paddleMod;
	public static float paddleStrech;
	public static float ballMod;

	// Use this for initialization
	void Awake() 
	{
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);

		paddleMod = 1f;
		paddleStrech = 1f;
		ballMod = 1f;

		lives = 3;
		bricks = 24;

		Debug.Log(PlayerPrefs.GetString("supplies"));

		switch (PlayerPrefs.GetString ("supplies")) 
		{
		case "spear":
			ballMod = .8f;
			upgradeText.text = "Upgrade: Slow Ball";
			break;
		case "metal":
			paddleMod = 2f;
			upgradeText.text = "Upgrade: Fast Paddle";
			break;
		default:
			paddleMod = 2f;
			upgradeText.text = "";
			break;
		}

		Debug.Log ("ballMod " + ballMod);
		Debug.Log ("paddleStrech " + paddleStrech);
		Debug.Log ("paddleMod " + paddleMod);

		Setup ();
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
		PlayerPrefs.SetInt ("currentPage", 1);
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