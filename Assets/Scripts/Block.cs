using UnityEngine;

public class Block : MonoBehaviour
{
	[SerializeField] private AudioClip breakSound;
	[SerializeField] private GameObject blockSparklesVFX;

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
		TriggerSparklesVFX();
		_level.BlockDestroyed();
		_gameStatus.AddToScore();
		AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
		Destroy(gameObject);
	}

	private void TriggerSparklesVFX()
	{
		var transform1 = transform;
		var sparkles = Instantiate(blockSparklesVFX, transform1.position, transform1.rotation);
		Destroy(sparkles, 1f);
	}
}
