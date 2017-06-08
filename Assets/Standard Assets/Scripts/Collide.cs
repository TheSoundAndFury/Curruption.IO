using UnityEngine;
using System.Collections;

public class Collide : MonoBehaviour {

	GameObject player; 

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");	
	}
	
	void OnCollisionEnter(Collision other) 
	{	 
		Debug.Log (other);

		if (other.gameObject.CompareTag ("shootable")) {
			Debug.Log ("test");

			player.transform.position = gameObject.transform.position;

			Destroy (gameObject);
		}
	}
}
