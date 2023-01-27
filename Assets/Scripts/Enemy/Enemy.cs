using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
	[SerializeField] private int _damage;
	[SerializeField] private int _health;
	[SerializeField] private int _reward;

	private int _maxHealth;

	public int Reward => _reward;

	public event UnityAction<Enemy> Dying;

	private void Start()
	{
		_maxHealth = _health;
	}

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.TryGetComponent(out Player player))
		{
			player.ApplyDamage(_damage);
			Die();
		}
		else if (collision.TryGetComponent(out Destroyer destroyer))
		{
			Die();
		}
	}

	private void Die()
	{
		_health = _maxHealth;
		gameObject.SetActive(false);
	}

	public void TakeDamage(int damage)
	{
		_health -= damage;

		if (_health <= 0)
		{
			Dying?.Invoke(this);
			Die();
		}
	}
}