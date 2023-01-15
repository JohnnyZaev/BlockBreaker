using UnityEngine;

public class Ball : MonoBehaviour
{
	[SerializeField] private Paddle paddle;

	private Vector3 _offset;
	
    private void Start()
    {
	    _offset = transform.position - paddle.transform.position;
    }

    private void Update()
    {
	    transform.position = paddle.transform.position + _offset;
    }
}
