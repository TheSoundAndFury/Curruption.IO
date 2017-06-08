using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour {
    public List<GameObject> detected = new List<GameObject>();
    void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "Player")
        {


            foreach (GameObject g in detected)
            {
                if (g == other.gameObject)
                {
                    return;
                }
            }
            //if no duplicate
            Debug.Log("added " + other.gameObject.name);
            detected.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            detected.Remove(other.gameObject);
        }
    }

}

