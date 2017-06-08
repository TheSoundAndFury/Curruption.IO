using UnityEngine;
using System.Collections;

public class ShellPickUp : MonoBehaviour {

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
			Ammo shells = (Ammo)this.GetComponentInParent(typeof(Ammo));
			Ammo.shells = Ammo.shells + value;
			pickup.Play();
			Destroy (gameObject, waitTime);	
		}

	}


}
