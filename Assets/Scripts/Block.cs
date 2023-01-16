using UnityEngine;

public class Block : MonoBehaviour
{
	[SerializeField] private AudioClip breakSound;

	private Level _level;
	private GameStatus _gameStatus;

	private void Start()
	{
		_level = FindObjectOfType<Level>();
		_level.CountBreakableBlocks();
		_gameStatus = FindObjectOfType<GameStatus>();
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		BlockDestroyed();
	}

	private void BlockDestroyed()
	{
		_level.BlockDestroyed();
		_gameStatus.AddToScore();
		AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
		Destroy(gameObject);
	}
}
