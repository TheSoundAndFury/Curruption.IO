using UnityEngine;
using System.Collections;

public class BulletPickUp : MonoBehaviour {

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
				Ammo bullets = (Ammo)this.GetComponentInParent(typeof(Ammo));
				Ammo.bullets = Ammo.bullets + value;
				pickup.Play();
				Destroy (gameObject, waitTime);					
			}
			
		}
		
}
