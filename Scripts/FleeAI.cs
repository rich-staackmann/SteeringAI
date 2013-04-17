using UnityEngine;
using System.Collections;

public class FleeAI : MonoBehaviour {
	public GameObject target;
	Vector3 desiredSpeed;
	public float speed = 30;
	const float rangeSQ = 1.5f * 1.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	//Flee is really just seek with the math reversed..ie we subtract our position from the target we a fleeing from
	void Update () 
	{
		desiredSpeed = Vector3.Normalize( rigidbody.position - target.rigidbody.position) * speed * Time.deltaTime; 
		//subtracting the agent's position from the target's position gives us a direction. we then normalize the vector and multiply it by the speed to get the vector we need
		desiredSpeed -= rigidbody.velocity; //to properly steer the agent we subtract our current velocity vector from our desired velocity vector, then we add this to the rigidbody
		
		if(Vector3.Distance(rigidbody.position, target.rigidbody.position) > rangeSQ) //if the target is outside our rangeSQuared then the object stops fleeing
		{
			rigidbody.Sleep();
			return;
		}
		
		
		rigidbody.AddForce(desiredSpeed,ForceMode.Impulse);
	}
}
