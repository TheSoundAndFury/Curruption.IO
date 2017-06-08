using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowWeapon : MonoBehaviour {

		[SerializeField]
		public GameObject item1;
		[SerializeField]
		public GameObject item2;
		[SerializeField]
		public GameObject item3;
		[SerializeField]
		public GameObject item4;

		public bool showItem1;
		public bool showItem2;
		public bool showItem3;
		public bool showItem4;

		public bool gotShotgun;
		public bool gotMachineGun;
		public bool gotRocket;
		public bool gotLaser;
	 
		public Text gun_type;

		// Use this for initialization
		void Start()
		{
			showItem1 = true;
			gun_type.text = "Bullets :";
			showItem2 = false;
			showItem3 = false;
			showItem4 = false;
		}

		// Update is called once per frame
		void Update()
		{
			if (showItem1 == false)
			{
				item1.SetActive(false);
			}
			if (showItem1 == true)
			{	
				gun_type.text = "Bullets :";
				item1.SetActive(true);
			}
			if (showItem2 == false)
			{
				gun_type.text = "Bullets :";
				item2.SetActive(false);
			}
			if (showItem2 == true)
			{
				item2.SetActive(true);
			}
			if (showItem3 == false)
			{
				item3.SetActive(false);
			}
			if (showItem3 == true)
			{
				gun_type.text = "Shells :";
				item3.SetActive(true);
			}
			if (showItem4 == false)
			{
				item4.SetActive(false);
			}
			if (showItem4 == true)
			{
				item4.SetActive(true);
			}

			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				showItem1 = true;
				showItem2 = false;
				showItem3 = false;
				showItem4 = false;
				gun_type.text = "Bullets :";
			}
		if(Input.GetKeyDown(KeyCode.Alpha2)&& gotMachineGun == true)
			{
				showItem2 = true;
				showItem1 = false;
				showItem3 = false;
				showItem4 = false;
				gun_type.text = "Bullets :";
			}
			if (Input.GetKeyDown(KeyCode.Alpha3) && gotShotgun == true)
			{
				showItem3 = true;
				showItem1 = false;
				showItem2 = false;
				showItem4 = false;
			gun_type.text = "Shells :";
			}
			if(Input.GetKeyDown(KeyCode.Alpha4))
			{
				showItem4 = true;
				showItem3 = false;
				showItem2 = false;
				showItem1 = false;
				gun_type.text = "Rockets :";
			}
		}
	}

