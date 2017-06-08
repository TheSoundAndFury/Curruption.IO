using UnityEngine;
using System.Collections;

public class GunBase : MonoBehaviour {

	public int gunDamage = 1;
	public float fireRate = .25f;
	public float weaponRange = 50f;
	public float hitForce = 300f;
	public Transform gunEnd;

	public int maxAmmo = 0;//Infite ammo 
	public bool automaticFire = false; 


	private Camera fpsCam;
	private WaitForSeconds shotDuration = new WaitForSeconds (.07f);

	private LineRenderer laserLine; 
	private float nextFire;  


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
