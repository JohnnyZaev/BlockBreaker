using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
	[SerializeField] private Paddle paddle;
	[SerializeField] private float ballPunchPower = 15f;
	[SerializeField] private AudioClip[] ballAudioClips;
	[SerializeField] private float randomFactor = 0.5f;

	private AudioSource _ballAudioSource;
	private Vector3 _offset;
	private Rigidbody2D _ballRb;
	private Vector2 _ballVel;
	private bool _hasStarted;
	
    private void Start()
    {
	    _offset = transform.position - paddle.transform.position;
	    _ballRb = GetComponent<Rigidbody2D>();
	    _ballAudioSource = GetComponent<AudioSource>();
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

    private void OnCollisionEnter2D(Collision2D col)
    {
	    if (!_hasStarted)
		    return;
	    var velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
	    var clip = ballAudioClips[Random.Range(0, ballAudioClips.Length)];
	    _ballAudioSource.PlayOneShot(clip);
	    _ballRb.velocity += velocityTweak;
    }
}
