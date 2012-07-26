using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	float force;
	//public GameObject Ball;
	public Vector3 original;
	public Vector3 pos;
	public Vector3 p;
	private int numChild;
	// Use this for initialization
	void Start () {
		original = transform.position;
		rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
	}
		
	// Update is called once per frame
	void FixedUpdate () {
		force = 5;
		//Debug.Log(rigidbody.rotation);
		pos = transform.position;
		//Debug.Log(pos.z);
		/*if(pos.z<-50) pos.z = 50;
		if(pos.z>50) pos.z = -50;
		if(pos.x<-50) pos.x = 50;
		if(pos.x>50) pos.x = -50;*/
		transform.position=pos;
		//v = rigidbody.GetPointVelocity(original);
		//Debug.Log(original.z);
		if(Input.GetKey(KeyCode.UpArrow)){
			rigidbody.AddForce(0,0,force,ForceMode.VelocityChange);
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			rigidbody.AddForce(0,0,-force,ForceMode.VelocityChange);
		}
		if(Input.GetKey("left")){
			rigidbody.AddForce(-force,0,0,ForceMode.VelocityChange);
		}
		if(Input.GetKey("right")){
			rigidbody.AddForce(force,0,0,ForceMode.VelocityChange);
		}
		
		if(Input.GetKey("space")){
			rigidbody.AddForce(0,force*2,0,ForceMode.VelocityChange);
		}
		//rigidbody.transform.localToWorldMatrix;
		
	}
	
	/*void OnTriggerEnter(Collider other){
		Debug.Log("yes");
		//other.enabled = true;
		other.gameObject.transform.parent = rigidbody.transform;

		rigidbody.mass++;
	}*/
	
	void OnCollisionEnter(Collision other){
		if(other.collider.name == "Sphere_small(Clone)" || other.collider.name == "Sphere_small"){
			other.collider.gameObject.transform.parent = rigidbody.transform;
			foreach(ContactPoint contact in other.contacts){
				Debug.Log("yes");
			}
		}
	}
}
