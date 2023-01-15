using UnityEngine;

public class Block : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D col)
	{
		Destroy(gameObject);
	}
}
