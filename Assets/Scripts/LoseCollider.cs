using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D col)
	{
		SceneManager.LoadScene("Game Over");
	}
}
