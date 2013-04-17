using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed = 10.0f;
	float forwardSpeed;
	float sideSpeed;
	Vector3 totalMove = Vector3.zero;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		forwardSpeed += Input.GetAxis("Vertical") * speed * Time.deltaTime;
		sideSpeed += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		rigidbody.MovePosition(new Vector3(sideSpeed,1,forwardSpeed));
		//rigidbody.AddForce(new Vector3(sideSpeed,0,forwardSpeed),ForceMode.Acceleration);
	}
}
