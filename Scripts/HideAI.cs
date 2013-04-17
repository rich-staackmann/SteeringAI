using UnityEngine;
using System.Collections;
//this ai hides from the target behind obstacles
//
public class HideAI : MonoBehaviour {
	public GameObject target;
	GameObject[] obstacles; //a list of all objects with the obstacle tag
	
	Vector3 hidingSpot;
	float maxSpeed = 300.0f;
	const float deceleration = 0.05f; //a tweaking factor for the deceleration
	// Use this for initialization
	void Start () 
	{
		obstacles = GameObject.FindGameObjectsWithTag("Obstacle"); //get obstacles
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		float distToClosest = float.MaxValue; //start distance to the closest object at maximum
		Vector3 bestHidingSpot = transform.position; //set best hiding spot as the transform's position..as a fallback
		foreach(GameObject obstacle in obstacles)
		{
			hidingSpot = GetHidingPos(obstacle);
			float dist = Vector3.Distance(hidingSpot,transform.position) * Vector3.Distance(hidingSpot,transform.position);//work in distance squared space
			if( dist < distToClosest)
			{
				distToClosest = dist;
				bestHidingSpot = hidingSpot;
			}
		}
		Arrive(bestHidingSpot);

	}
	//calculates a spot 1 unit behind an obstacle based on the view of the target
	Vector3 GetHidingPos(GameObject obstacle)
	{
		const float DistanceFromBoundary = 1.0f;
		SphereCollider sphereCollider = obstacle.GetComponent<SphereCollider>();
		float distAway = (sphereCollider.radius * obstacle.transform.localScale.y) + DistanceFromBoundary; //the radius of s sphere collider is its radius times its scale
		
		Vector3 toObstacle = Vector3.Normalize(obstacle.transform.position - target.transform.position);
		
		return (toObstacle * distAway) + obstacle.transform.position; //vector to get behind the obstacle
		
	}
	
	void Arrive(Vector3 hidingPos) //arrive ai from earlier
	{
		float dist;
		Vector3 targetDirection = hidingPos - rigidbody.position; //find direction
		dist = Vector3.Magnitude(targetDirection); //find distance
		
		if(dist > 0)
		{
			float speed = dist / (deceleration); //our speed will slow as the distance to the target decreases
			speed = Mathf.Min(speed,maxSpeed); //make sure we don't exceed maximum speed limit
			
			Vector3 desiredSpeed = targetDirection * speed / dist * Time.deltaTime;
			desiredSpeed -= rigidbody.velocity;
			
			rigidbody.AddForce(desiredSpeed,ForceMode.Impulse);
			
		}
		else //we are on top of the target, so we stop
			rigidbody.velocity = Vector3.zero;
	}
}
