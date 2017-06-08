using UnityEngine;
using System.Collections;

public class CanShoot: MonoBehaviour {

	public float currentHealth = 3;
	public GameObject objectToSpawn;
	public int particle;

	public void TakeDamage(GunHit gunHit)
	{
		
		Instantiate (objectToSpawn, gunHit.raycastHit.point, Quaternion.LookRotation (gunHit.raycastHit.normal));

		currentHealth -= gunHit.damage;

		if (currentHealth <= 0) {
			Destroy (gameObject);


		}
	}
}
		



