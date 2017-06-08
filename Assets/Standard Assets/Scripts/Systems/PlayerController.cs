using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float maxHealth;
	public float currentHealth;
	public Text health;

	void Start()
	{
		health.text = currentHealth.ToString();

	}

	public void damage(float damage)
	{
		Debug.Log(damage);

		currentHealth -= damage;

		health.text = currentHealth.ToString();

		if (currentHealth <= 0) 
		{
			Application.LoadLevel(Application.loadedLevel);
		}

	}

	void Update()
	{
		if (currentHealth > maxHealth)
			
			currentHealth = maxHealth;

		health.text = currentHealth.ToString();
	}


}
