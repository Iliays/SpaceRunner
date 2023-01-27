using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;
	[SerializeField] private AudioClip _shootSound;
	[SerializeField] private AudioClip _hitSound;
	
    private Weapon _currentWeapon;
    private int _currentWeaponNumber = 0;
    private int _currentHealth;
	private AudioSource _audioSource;

	public int Money { get; private set; }

	public event UnityAction<int, int> HealthChanged;
	public event UnityAction<int> MoneyChanged;
	public event UnityAction Died;

	private void Start()
	{
		_audioSource = GetComponent<AudioSource>();
		_currentHealth = _health;
		ChangeWeapon(_weapons[_currentWeaponNumber]);
		HealthChanged?.Invoke(_currentHealth, _health);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_currentWeapon.Shoot(_shootPoint);
			_audioSource.PlayOneShot(_shootSound);
		}
	}

	public void ApplyDamage(int damage)
	{
		_audioSource.PlayOneShot(_hitSound);
		_currentHealth -= damage;

		if (_currentHealth <= 0)
		{
			Die();
			Destroy(gameObject);
		}

		HealthChanged?.Invoke(_currentHealth, _health);
	}

	public void Die()
	{
		Died?.Invoke();
	}

	public void AddMoney(int money)
	{
		Money += money;
		MoneyChanged?.Invoke(Money);
	}

	public void BuyWeapon(Weapon weapon)
	{
		Money -= weapon.Price;
		MoneyChanged?.Invoke(Money);
		_weapons.Add(weapon);
	}

	public void NextWeapon()
	{
		if (_currentWeaponNumber == _weapons.Count - 1)
			_currentWeaponNumber = 0;
		else
			_currentWeaponNumber++;

		ChangeWeapon(_weapons[_currentWeaponNumber]);
	}

	public void PreviousWeapon()
	{
		if (_currentWeaponNumber == 0)
			_currentWeaponNumber = _weapons.Count - 1;
		else
			_currentWeaponNumber--;

		ChangeWeapon(_weapons[_currentWeaponNumber]);
	}

	public void ChangeWeapon(Weapon weapon)
	{
		_currentWeapon = weapon;
	}
}