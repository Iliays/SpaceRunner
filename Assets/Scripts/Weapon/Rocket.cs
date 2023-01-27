using UnityEngine;

public class Rocket : Weapon
{
	public override void Shoot(Transform shootPoint)
	{
		Instantiate(Bullet, shootPoint.position, Quaternion.identity);
	}
}