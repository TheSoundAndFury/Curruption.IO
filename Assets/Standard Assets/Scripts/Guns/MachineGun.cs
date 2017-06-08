using UnityEngine;
using System.Collections;


public class MachineGun : MonoBehaviour {

	public float Damage = 1f;
	public float fireRate = 15000f;
	public float weaponRange = 50f;
	public float hitForce = 100f;
	public Transform gunEnd;
	public AudioSource gunAudio;
	public GameObject objectToSpawn;

	private string myGun;
	private Camera fpsCam;
	private WaitForSeconds shotDuration = new WaitForSeconds (.1f);

	private LineRenderer laserLine; 
	private float nextFire;  
	private int hasammo;

	// Use this for initialization
	void Awake () 
	{
		laserLine = GetComponent<LineRenderer> ();
		gunAudio = GetComponent<AudioSource> ();
		fpsCam = GetComponentInParent<Camera> ();

	}


	// Update is called once per frame
	void Update () 
	{

		if (isActiveAndEnabled)
		{
			Ammo getammo = GetComponent<Ammo>();
			Ammo.currentWeapon = "Machine Gun";
			hasammo = Ammo.bullets;
		}


		if (Input.GetButton ("Fire1") && Time.time > nextFire && isActiveAndEnabled && hasammo > 0) 
		{
			nextFire = Time.time + fireRate;
			Ammo getammo = (Ammo)this.GetComponentInParent(typeof(Ammo));

			myGun = Ammo.currentWeapon;

			getammo.UseAmmo(myGun);

			StartCoroutine (ShotEffect ());

			Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 0));

			RaycastHit hit;

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
		gunAudio.Play ();
		laserLine.enabled = true;
		yield return shotDuration;
		laserLine.enabled = false;
	}
}
