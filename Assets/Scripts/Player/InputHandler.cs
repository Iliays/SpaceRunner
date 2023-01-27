using UnityEngine;

public class InputHandler : MonoBehaviour
{
	private Vector2 _inputVector;
	private Vector3 _mousePosition;

	public Vector2 InputVector => _inputVector;
	public Vector3 MousePosition => _mousePosition;

	private void Update()
	{
		var horizontalInput = Input.GetAxis("Horizontal");
		var verticalInput = Input.GetAxis("Vertical");

		_inputVector = new Vector2(horizontalInput, verticalInput);
		_mousePosition = Input.mousePosition;
	}
}