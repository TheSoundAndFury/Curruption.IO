using UnityEngine;
using System.Collections;

public class GotMachinegun : MonoBehaviour {

	public AudioSource pickup; 
	public float waitTime;
	private ShowWeapon machinegun;
	private bool JustOnce ;

	void Start(){
		JustOnce = false;
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Player") && JustOnce == !true)
		{
			JustOnce = true;
			machinegun = other.gameObject.GetComponentInChildren<ShowWeapon> ();
			machinegun.gotMachineGun = true;
			machinegun.showItem2 = true;
			Debug.Log ("Got The MachineGun");
			pickup.Play();
			Destroy (gameObject, waitTime);	

		}

	}

}