using UnityEngine;

public class Ball : MonoBehaviour
{
	[SerializeField] private Paddle paddle;
	[SerializeField] private float ballPunchPower = 15f;

	private Vector3 _offset;
	private Rigidbody2D _ballRb;
	private Vector2 _ballVel;
	private bool _hasStarted;
	
    private void Start()
    {
	    _offset = transform.position - paddle.transform.position;
	    _ballRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
	    if (_hasStarted)
		    return;
	    transform.position = paddle.transform.position + _offset;
	    if (!Input.GetMouseButtonDown(0)) return;
	    _ballVel.x = Random.Range(-2f, 2f);
	    _ballVel.y = ballPunchPower;
	    _ballRb.velocity = _ballVel;
	    _hasStarted = true;
    }
}