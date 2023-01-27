using System.Collections;
using UnityEngine;

public class SelfDestruction : MonoBehaviour
{
	[SerializeField] private float _time = 1f;

	private void Start()
	{
		StartCoroutine(LifeTime());
	}

	private IEnumerator LifeTime()
	{
		yield return new WaitForSeconds(_time);

		Destroy(gameObject);
	}
}