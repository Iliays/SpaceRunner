using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class PlayerMover : MonoBehaviour
{
	[SerializeField] private float _movementSpeed;
	[SerializeField] private Camera _camera;

	private const float _minXPosition = -40f;
	private const float _maxXPosition = 40f;
	private const float _minZPosition = -3f;
	private const float _maxZPosition = 20f;

	private InputHandler _input;

	private void Awake()
	{
		_input = GetComponent<InputHandler>();
	}

	private void Update()
	{
		var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);

		MoveTowardTarget(targetVector);

		transform.position = new Vector3(Mathf.Clamp(transform.position.x, _minXPosition, _maxXPosition), 0, Mathf.Clamp(transform.position.z, _minZPosition, _maxZPosition));
	}

	private void MoveTowardTarget(Vector3 targetVector)
	{
		var speed = _movementSpeed * Time.deltaTime;
		targetVector = Quaternion.Euler(0, _camera.transform.rotation.eulerAngles.y, 0) * targetVector;
		var targetPosition = transform.position + targetVector * speed;
		transform.position = targetPosition;
	}
}