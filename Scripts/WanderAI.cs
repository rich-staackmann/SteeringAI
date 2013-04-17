using UnityEngine;
using System.Collections;

//wander makes an agent randomly move around
//this version works by projecting a circle and selecting a random target point on the circle

public class WanderAI : MonoBehaviour {
	float wanderRadius = 2.0f;
	float wanderDist = 2.0f;
	float wanderJitter = 0.5f;
	Vector3 wanderTarget = new Vector3(0,1,0);
	Vector3 localTarget;
	
	// Use this for initialization
	void Start () {
	Random.seed = (int)Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{	
		wanderTarget += new Vector3(Random.Range(-1.0f,1.0f) * wanderJitter, 0, Random.Range(-1.0f,1.0f) * wanderJitter); //we add a random amount to our target
		wanderTarget.Normalize(); 
		wanderTarget *= wanderRadius; //after normalizing the vector, we scale it by our radius
		wanderTarget.y = 1; //make sure the y value doesn't change, i wanted 2d movement
		
		localTarget = wanderTarget + new Vector3(wanderDist,0,wanderDist); //porject the target ahead of the object by wander distance
		localTarget -= transform.position; //subtract the position to give us our vector to the wanderTarget
		
		Debug.DrawLine(transform.position,localTarget);
		
		transform.Translate((localTarget * Time.deltaTime));
	}
	
	
}
