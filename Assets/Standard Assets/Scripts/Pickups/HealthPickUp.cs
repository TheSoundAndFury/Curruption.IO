using UnityEngine;
using System.Collections;

public class HealthPickUp : MonoBehaviour {

	public int value;
	public AudioSource pickup; 
	public float waitTime;
	private bool JustOnce ;

	void Start(){
		JustOnce = false;
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Player")&& JustOnce == !true)
		{
			JustOnce = true;
			PlayerController gethealth = other.gameObject.GetComponent<PlayerController>();
			gethealth.currentHealth = gethealth.currentHealth + value;
			Debug.Log (gethealth.currentHealth);
			pickup.Play();
			Destroy (gameObject, waitTime);	
		}
	}
}
