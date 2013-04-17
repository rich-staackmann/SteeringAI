using UnityEngine;
using System.Collections;

//pursuit is like seek, however we attempt to anticipate where the target is heading
//that way we get a better following behavior

public class PursuitAI : MonoBehaviour {
	public GameObject target;
	float lookAhead;
	float maxSpeed = 300.0f;
	Vector3 vectorToTarget;
	Vector3 desiredSpeed;
	float heading;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		vectorToTarget = target.rigidbody.position - rigidbody.position;
		heading = Vector3.Dot( rigidbody.rotation.eulerAngles, target.rigidbody.rotation.eulerAngles);
		
		lookAhead = vectorToTarget.magnitude / (maxSpeed + target.rigidbody.velocity.magnitude); 
		//lookAhead is proportional to the distance btwn the target and pursuer, and inverse to their velocities
		
		Seek(target.rigidbody.position + target.rigidbody.velocity * lookAhead);
	}
	
	void Seek(Vector3 targetPos)
	{
		//remember, a vector is a direction and a magnitude
		desiredSpeed = Vector3.Normalize(targetPos - rigidbody.position) * maxSpeed * Time.deltaTime; 
		//subtracting the target position from the agent's position gives us a direction. we then normalize the vector and multiply it by the speed to get the vector we need
		desiredSpeed -= rigidbody.velocity; //to properly steer the agent we subtract our current velocity vector from our desired velocity vector, then we add this to the rigidbody
		
		rigidbody.AddForce(desiredSpeed,ForceMode.Impulse);
	}
}
