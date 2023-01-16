using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
	[Range(0.1f, 10)][SerializeField] private float gameSpeed = 1f;
	[SerializeField] private TMP_Text scoreText;
	
	// state variables
	[SerializeField] private int pointsPerBlockDestroyed = 15;
	[SerializeField] private int currentScore;

	private void Start()
	{
		scoreText.text = currentScore.ToString();
	}

	private void Update()
	{
		Time.timeScale = gameSpeed;
	}

	public void AddToScore()
	{
		currentScore += pointsPerBlockDestroyed;
		scoreText.text = currentScore.ToString();
	}
}
