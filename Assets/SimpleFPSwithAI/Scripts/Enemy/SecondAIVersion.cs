using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondAIVersion : MonoBehaviour {
    public enum State { idle, chasing, firing }
    public EnemyDetection detection;
    public State state = State.idle;
    public float attackTime = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        updateSenses();
        switch (state) {
            case State.idle:
                break;
            case State.chasing:
                break;
            case State.firing:

                attackTime -= Time.deltaTime;
                if (attackTime > 0) {
                    //fire here
                    Debug.Log("Firing at player");
                    attackTime = 2f;
                }
                break;
        }
	}


    public void updateSenses() {
        if (detection.detected.Count > 0)
        {
            state = State.firing;
        }
        else {
            state = State.idle;
        }
    }
}
