using UnityEngine;
using System.Collections;

public class SeekAI : MonoBehaviour {
	public GameObject target;
	float maxSpeed = 300.0f;
	Vector3 desiredSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{	
		//remember, a vector is a direction and a magnitude
		desiredSpeed = Vector3.Normalize(target.rigidbody.position - rigidbody.position) * maxSpeed * Time.deltaTime; 
		//subtracting the target position from the agent's position gives us a direction. we then normalize the vector and multiply it by the speed to get the vector we need
		desiredSpeed -= rigidbody.velocity; //to properly steer the agent we subtract our current velocity vector from our desired velocity vector, then we add this to the rigidbody
		
		rigidbody.AddForce(desiredSpeed,ForceMode.Impulse);
	}
	
}
