using UnityEngine;
using System.Collections;

public class Pistol : MonoBehaviour {
	//Basic stats 
	public float Damage = 1f;
	public float fireRate = .25f;
	public float weaponRange = 50f;
	public float hitForce = 300f;
	public Transform gunEnd;
	public AudioSource gunAudio;
	GameObject player; 
	public GameObject objectToSpawn;

	private Camera fpsCam;
	private WaitForSeconds shotDuration = new WaitForSeconds (.07f);
	private LineRenderer laserLine; 
	private float nextFire;  
	private string myGun;
	private int hasammo;


	// Use this for initialization
	void Awake () 
	{
		//laserLine = GetComponent<LineRenderer> ();
		gunAudio = GetComponent<AudioSource> ();
		fpsCam = GetComponentInParent<Camera> ();	
		Ammo getammo = (Ammo)this.GetComponentInParent(typeof(Ammo));
		player = GameObject.FindGameObjectWithTag ("Player");	
	}

	// Update is called once per frame
	void Update () 
	{
		if (isActiveAndEnabled) 
		{			
			Ammo.currentWeapon = "Pistol";
			hasammo = Ammo.bullets;
		}

		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire && hasammo > 0) 
		{
			nextFire = Time.time + fireRate;
			Ammo getammo = (Ammo)this.GetComponentInParent(typeof(Ammo));
			myGun = Ammo.currentWeapon = "Pistol";

			getammo.UseAmmo(myGun);

			StartCoroutine (ShotEffect ()); 

			Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 0));

			RaycastHit hit;

//			laserLine.SetPosition (0, gunEnd.position);

			Vector3 fireDirection = fpsCam.transform.forward;

			Quaternion fireRotation = Quaternion.LookRotation (fireDirection);

			Quaternion randomrotation = Random.rotation;


			if (Physics.Raycast (rayOrigin, fireRotation * Vector3.forward, out hit, weaponRange)) {

				GunHit gunHit = new GunHit ();
				gunHit.damage = Damage;
				gunHit.raycastHit = hit;
				CanShoot health = hit.collider.GetComponent<CanShoot>();

				if (health == true) {
					
				} else {
					Instantiate (objectToSpawn, gunHit.raycastHit.point, Quaternion.LookRotation (gunHit.raycastHit.normal));
				}

				//player.transform.position = hit.point;

				if (health != null) 
				{
					health.TakeDamage (gunHit);
				}

				if (hit.rigidbody != null) 
				{
					hit.rigidbody.AddForce (-hit.normal * hitForce);
				}

			} else 
			{
				//laserLine.SetPosition (1, rayOrigin + (fpsCam.transform.forward * weaponRange));
			}
		}


	}

	private IEnumerator ShotEffect()
	{
		//laserLine.enabled = true;
		gunAudio.Play ();
		yield return shotDuration;
		//laserLine.enabled = false;
	}
}
