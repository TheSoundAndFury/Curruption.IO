using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {

	// Use this for initialization
	private void Start () {

		Destroy (gameObject, GetComponent<ParticleSystem> ().duration);
	
	}

}
