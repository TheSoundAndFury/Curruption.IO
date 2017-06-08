using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

	public int gunDamage = 25;
	public float fireRate = .25f;
	public float weaponRange = 50f;
	public float hitForce = 300f;
	public Transform gunEnd;
	public AudioSource gunAudio;
	public GameObject rocket;

	private WaitForSeconds shotDuration = new WaitForSeconds (.07f);

	private float nextFire;  
	private string myGun;
	private Camera fpsCam;

	// Use this for initialization
	void Start () 
	{
		gunAudio = GetComponent<AudioSource> ();	
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 0));
			RaycastHit hit;
			StartCoroutine (ShotEffect ());
			//Rigidbody shellinstance = 
		//Instantiate (rocket, gunEnd.position, gunEnd.rotation) as Rigidbody;		
		}
			
	}

	private IEnumerator ShotEffect()
	{
		gunAudio.Play ();
		yield return shotDuration;
	}
}
