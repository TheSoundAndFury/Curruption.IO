using UnityEngine;
using System.Collections;

public class GotShotGun : MonoBehaviour {

	public AudioSource pickup; 
	public float waitTime;
	private ShowWeapon shotgun;
	private bool JustOnce ;

	void Start(){
		JustOnce = false;
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Player") && JustOnce == !true)
		{
			JustOnce = true;
			shotgun = other.gameObject.GetComponentInChildren<ShowWeapon> ();
			shotgun.gotShotgun = true;
			shotgun.showItem3 = true; 
			Debug.Log ("Got The Shotgun");
			pickup.Play();
			Destroy (gameObject, waitTime);	

		}

	}

}