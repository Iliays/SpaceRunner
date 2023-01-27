using UnityEngine;

public class Missile : Weapon
{
	public override void Shoot(Transform shootPoint)
	{
		Instantiate(Bullet, shootPoint.position, Quaternion.identity);
	}
}