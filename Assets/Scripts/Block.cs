using UnityEngine;

public class Block : MonoBehaviour
{
	//config params
	[SerializeField] private AudioClip breakSound;
	[SerializeField] private GameObject blockSparklesVFX;
	[SerializeField] private Sprite[] hitSprites;

	// cached reference
	private Level _level;
	private GameStatus _gameStatus;

	//state variable
	[SerializeField] private int timesHit; // TODO only serialize for debug
	private int maxHits;

	private void Start()
	{
		if (gameObject.CompareTag("Unbreakable"))
			return;
		maxHits = hitSprites.Length + 1;
		_level = FindObjectOfType<Level>();
		_level.CountBreakableBlocks();
		_gameStatus = FindObjectOfType<GameStatus>();
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (gameObject.CompareTag("Unbreakable"))
			return;
		timesHit++;
		if (timesHit >= maxHits)
		{
			BlockDestroyed();
		}
		else
		{
			ShowNextHitSprite();
		}
	}

	private void ShowNextHitSprite()
	{
		var spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex] != null)
		{
			GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else
		{
			Debug.LogError($"Block sprite is missing from array: {gameObject.name}");
		}
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
