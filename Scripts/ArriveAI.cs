using UnityEngine;
using System.Collections;

//arrive is like seek but we decelerate to the target
//this helps to eliminate the jitter that seek produces
public class ArriveAI : MonoBehaviour {
	public GameObject target;
	float maxSpeed = 300.0f;
	float speed;
	Vector3 targetDirection;
	Vector3 desiredSpeed;
	float dist;
	const float deceleration = 0.05f; //a tweaking factor for the deceleration
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		targetDirection = target.rigidbody.position - rigidbody.position; //find direction
		dist = Vector3.Magnitude(targetDirection); //find distance
		
		if(dist > 0)
		{
			speed = dist / (deceleration); //our speed will slow as the distance to the target decreases
			speed = Mathf.Min(speed,maxSpeed); //make sure we don't exceed maximum speed limit
			
			desiredSpeed = targetDirection * speed / dist * Time.deltaTime;
			desiredSpeed -= rigidbody.velocity;
			
			rigidbody.AddForce(desiredSpeed,ForceMode.Impulse);
			
		}
		else //we are on top of the target, so we stop
			rigidbody.Sleep();
	}
}
