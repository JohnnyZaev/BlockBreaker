using UnityEngine;

public class Paddle : MonoBehaviour
{
	[SerializeField] private float screenWidthInUnits = 16f;
	[SerializeField] private float minX = 1f;
	[SerializeField] private float maxX = 15f;

	private Vector2 _paddlePos;

	private void Update()
	{
		var mousePosition = Input.mousePosition.x / Screen.width * screenWidthInUnits;
		_paddlePos.x = Mathf.Clamp(mousePosition, minX, maxX);
		var paddleTransform = transform;
		_paddlePos.y = paddleTransform.position.y;
		paddleTransform.position = _paddlePos;
	}
}
