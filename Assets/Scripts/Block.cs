using UnityEngine;

public class Block : MonoBehaviour
{
	[SerializeField] private AudioClip breakSound;

	private Level _level;

	private void Start()
	{
		_level = FindObjectOfType<Level>();
		_level.CountBreakableBlocks();
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		_level.BlockDestroyed();
		AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
		Destroy(gameObject);
	}
}
