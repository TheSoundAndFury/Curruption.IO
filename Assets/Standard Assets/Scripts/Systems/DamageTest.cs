using UnityEngine;
using System.Collections;

public class DamageTest : MonoBehaviour {

	public int damage;


	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			PlayerController hurt = other.gameObject.GetComponent<PlayerController>();

			hurt.damage (damage);
		}
	}

}
