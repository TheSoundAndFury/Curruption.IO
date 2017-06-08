using UnityEngine;
using System.Collections;

public class HitEffect : MonoBehaviour {

	public GameObject objectToSpawn;

	void Damage(float damageAmount)
	{
		Instantiate (objectToSpawn, transform.position, transform.rotation);
	}
		
}
