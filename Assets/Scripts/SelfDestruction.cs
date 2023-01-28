using UnityEngine;

public class SelfDestruction : MonoBehaviour
{
	[SerializeField] private float _time = 1f;

	private void Start()
	{
		Destroy(gameObject, _time);
	}
}