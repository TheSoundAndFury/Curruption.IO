using UnityEngine;
using System.Collections;

public class Enemy_1 : MonoBehaviour
{
	Transform player;               // Reference to the player's position.
	GameObject playerHealth;      // Reference to the player's health.
	GameObject enemyHealth;        // Reference to this enemy's health.
	UnityEngine.AI.NavMeshAgent nav;  // Reference to the nav mesh agent.
	Transform currentplayerpos; // Where the player is 
//	Animator anim; 

	public BoxCollider collider1;

	public SphereCollider collider2;

	//bool SeesPlayer;
	//bool CanAttack;

	void Awake ()
	{
	//	anim = GetComponent <Animator> ();
	
		// Set up the references.
		player = GameObject.FindGameObjectWithTag ("Player").transform;
//		playerHealth = player.GetComponent <currentHealth> ();
//		enemyHealth = GetComponent <EnemyHealth> ();
//		nav = GetComponent <NavMeshAgent> ();
//		nav.SetDestination = null;
	}

	void OnTriggerEnter(Collider other) 
	{
		
			
	}

		
}