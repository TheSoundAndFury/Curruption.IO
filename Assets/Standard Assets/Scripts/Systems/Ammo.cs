using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ammo : MonoBehaviour {

	public static int bullets; 
	public static int shells; 
	public static int rockets; 

	public Text amount;
	public Text hud; 

	public string ammotype;
	public static string currentWeapon;

	public int maxBullets;
	public int maxShells;
	public int maxRockets; 

	public static Ammo Instance;

	// Use this for initialization
	void Awake () {
		bullets = 30;
		shells = 10;
		rockets = 9;
		currentWeapon = "Pistol"; 
		Instance = this;
	}
		
	public void Update(){	

		//Show the type of ammo we're currently using
		if (currentWeapon == "Pistol") 
		{
			amount.text = bullets.ToString(); 
		}
		if (currentWeapon == "Machine Gun") 
		{
			amount.text =  bullets.ToString(); 
		}
		if (currentWeapon == "Shotgun") 
		{
			amount.text = shells.ToString();
		}
		if (currentWeapon == "Rocket Launcher") 
		{
			amount.text =  rockets.ToString();
		}

		if (bullets > maxBullets) {

			bullets = maxBullets;
		}

		if (shells > maxShells) {

			shells = maxShells;
		}

		if (rockets > maxRockets) {

			rockets = maxRockets;
		}
	}

	//function to actually use and update the ammo
	public void UseAmmo (string weapon) 
	{

		if (weapon == "Pistol") 
		{
			bullets = bullets - 1;

		}
		if (weapon == "Machine Gun") 
		{
			bullets = bullets - 1;

		}
		if (weapon == "Shotgun") 
		{
			shells = shells - 1;
		}
		if (weapon == "Rocket Launcher") 
		{
			rockets = rockets - 1;

		}
	}
		
}
