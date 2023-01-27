using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
	[SerializeField] private ParticleSystem _hitEffect;
	[SerializeField] private AudioSource _hitSound;

	private void Update()
    {
        Move();
    }

    protected virtual void Move()
	{
        transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.World);
    }

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.TryGetComponent(out Enemy enemy))
		{
			Instantiate(_hitSound);
			Instantiate(_hitEffect, transform.position, transform.rotation);
			enemy.TakeDamage(_damage);
			Destroy(gameObject);
		}
		else if (collision.TryGetComponent(out Destroyer destroyer))
		{
			Destroy(gameObject);
		}
	}
}