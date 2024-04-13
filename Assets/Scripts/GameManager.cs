using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private int score;
	private int highScore;
	public Player player;
	public GameObject bird;
	public Text scoreText;
	public Text highScoreText;  
	public GameObject playButton;
	public GameObject pauseButton;
	public GameObject resumeButton;
	public GameObject gameOver;
	public GameObject title;
	public GameObject ready;
	public GameObject tapMe;
	public GameObject playerTap;
	public GameObject bronzeMedal;
	public GameObject silverMedal;
	public GameObject shinySilverMedal;
	public GameObject goldMedal;
	public GameObject reset;
	private int bronze = 5;
	private int silver = 10;
	private int shinySilver = 15;
	private int gold = 20; 


	private bool isGamePaused = false;

	private void Awake(){
		Pause();
		gameOver.SetActive(false);
		pauseButton.SetActive(false);
		resumeButton.SetActive(false);
		bird.SetActive(false);

		highScore = PlayerPrefs.GetInt("HighScore", 0);
    	highScoreText.text = highScore.ToString(); 
	}
	public void Play(){
		score = 0;
		scoreText.text = score.ToString();

		bird.SetActive(true);
		gameOver.SetActive(false);
		playButton.SetActive(false);
		pauseButton.SetActive(true);
		resumeButton.SetActive(false);
		title.SetActive(false);
		ready.SetActive(false);
		tapMe.SetActive(false);
		playerTap.SetActive(false);
		bronzeMedal.SetActive(false);
		silverMedal.SetActive(false);
		shinySilverMedal.SetActive(false);
		goldMedal.SetActive(false);

		Time.timeScale = 1f;
		player.enabled = true;

		Pipes[] pipes = FindObjectsOfType<Pipes>();
		for (int i = 0; i < pipes.Length; i++){
			Destroy(pipes[i].gameObject);
		}
		player.ResetPlayerPosition(); 
	}

	public void Pause(){
		Time.timeScale = 0f;
		player.enabled = false;
		pauseButton.SetActive(false);
		resumeButton.SetActive(true);  
		isGamePaused = true;
	}

	public void Resume(){
		Time.timeScale = 1f;
		player.enabled = true;
		pauseButton.SetActive(true);
		resumeButton.SetActive(false);
		playButton.SetActive(false);
		isGamePaused = false;
	}
	public void GameOver(){
		gameOver.SetActive(true);
		playButton.SetActive(true); 
		pauseButton.SetActive(false);
		resumeButton.SetActive(false);
		title.SetActive(true);
		ready.SetActive(false);
		tapMe.SetActive(false);
		playerTap.SetActive(false);

		Time.timeScale = 0f;
		player.enabled = false;
		isGamePaused = true;

		if (score > highScore){
			highScore = score;
			PlayerPrefs.SetInt("HighScore", highScore);
			highScoreText.text = highScore.ToString(); 
			PlayerPrefs.Save();
		}
	}

	public void IncreaseScore(){
		score++;
		scoreText.text = score.ToString(); 

		if (score >= bronze){
			bronzeMedal.SetActive(true);
		} if (score >= silver){
			silverMedal.SetActive(true);
		} if (score >= shinySilver){
			shinySilverMedal.SetActive(true);
		} if (score >= gold){
			goldMedal.SetActive(true);
		}
	}
	public bool IsGamePaused(){
		return isGamePaused;
	}
	public void ResetHighScore() {
    PlayerPrefs.SetInt("HighScore", 0);
    highScore = 0;
    highScoreText.text = highScore.ToString();
}
}
