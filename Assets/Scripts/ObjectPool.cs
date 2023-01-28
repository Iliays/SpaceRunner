using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

	private Queue<GameObject> _pool = new Queue<GameObject>();

	protected void Initialize(GameObject prefab)
	{
		for (int i = 0; i < _capacity; i++)
		{
			GameObject spawner = Instantiate(prefab, _container.transform);
			spawner.SetActive(false);

			_pool.Enqueue(spawner);
		}
	}

	protected void Initialize(GameObject[] prefabs)
	{
		for (int i = 0; i < _capacity; i++)
		{
			int randomIndex = Random.Range(0, prefabs.Length);
			GameObject spawned = Instantiate(prefabs[randomIndex], _container.transform);
			spawned.SetActive(false);

			_pool.Enqueue(spawned);
		}
	}

	protected bool TryGetObject(out GameObject result)
	{
		result = _pool.FirstOrDefault(p => p.activeSelf == false);

		return result != null;
	}
}