using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public LayerMask m_Mask;
    public ParticleSystem m_ExplosionParticles;       
    public AudioSource m_ExplosionAudio;              
    public float m_MaxDamage = 100f;                  
    public float m_ExplosionForce = 1000f;            
    public float m_MaxLifeTime = 2f;                  
    public float m_ExplosionRadius = 5f;              


    private void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        // Find all the tanks in an area around the shell and damage them.
		Collider[] colliders = Physics.OverlapSphere (transform.position, m_ExplosionRadius, m_Mask);

		for (int i = 0; i < colliders.Length; i++)
		{
			Rigidbody targetRidgetbody = colliders[i].GetComponent<Rigidbody> ();

			if (!targetRidgetbody)
				continue;

			targetRidgetbody.AddExplosionForce (m_ExplosionForce, transform.position, m_ExplosionRadius);

			CanShoot targetHealth = targetRidgetbody.GetComponent<CanShoot>();

			if (!targetHealth)
				continue; 
			float damage = CalculateDamage (targetRidgetbody.position);

			//targetHealth.TakeDamage(gunhit);
		}
		//Remove child from parent when the object is destroied
		m_ExplosionParticles.transform.parent = null;
		m_ExplosionParticles.Play ();
		m_ExplosionAudio.Play ();
		//Wait the particle systems duration, then destory the system 
		Destroy (m_ExplosionParticles.gameObject, m_ExplosionParticles.duration);
		//Destory Rocket
		Destroy (gameObject);
    }


    private float CalculateDamage(Vector3 targetPosition)
    {
        // Calculate the amount of damage a target should take based on it's position.
		Vector3 explosionToTarget = targetPosition - transform.position;

		float explosionDistance = explosionToTarget.magnitude;

		float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

		float damage = relativeDistance * m_MaxDamage;

		damage = Mathf.Max (0f, damage);

		return damage;
    }
}