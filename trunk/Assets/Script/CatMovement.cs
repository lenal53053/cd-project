using UnityEngine;
using System.Collections;

public enum CStates
{
	NONE,
	JUMP,
	DROP
}

public class CatMovement : MonoBehaviour
{
	private float y_axis;
	private float x_axis;
	private float space_time = 0;
	private float space_timeLimit = 2;
	private float speed = 100f;
	private Vector3 originalPos;
	private Vector3 scale;
	private CStates s = CStates.NONE;
	private exSprite anim =null;
	private string animation = "";

	void Start ()
	{
		if(anim == null){
			anim = this.GetComponent<exSprite>() as exSprite;
		}
		//Debug.Log(anim);
		//Debug.Log(anim.name);
		
		originalPos = transform.position;
		y_axis = originalPos.y;
		x_axis = originalPos.x;
		
		//scale = transform.localScale;
	}
	
	void FixedUpdate ()
	{
		originalPos = transform.position;
		y_axis = originalPos.y;
		x_axis = originalPos.x;
		
		//scale = transform.localScale;
		
		
		if (Input.GetKey (KeyCode.Space)) { 
			if(space_time < space_timeLimit){
				space_time += Time.deltaTime;
			}
		}
		
		if (Input.GetKey ("left")) {
			x_axis -= 2;
			//scale.x = 1;
			//if(animation!="CRM1201_202_Loop"){
			///	anim.spanim.Play ("CRM1201_202_Loop");
			//	animation = "CRM1201_202_Loop";
			//}
		}
		if (Input.GetKey ("right")) {
			x_axis += 2;
			//scale.x = -1;
			//if(animation!="CRM1201_202_Loop"){
			//	anim.spanim.Play ("CRM1201_202_Loop");
			//	animation = "CRM1201_202_Loop";
			//}
		}
		
		if (Input.GetKeyUp (KeyCode.Space)) {
		}
		
		if(s == CStates.JUMP){
			if(speed>0){
				Jump ();
			}else{
				s = CStates.DROP;
			}
		}
		
		if(s== CStates.DROP){
			Drop();
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void OnCollisionEnter (Collision obj)
	{

	}
	
	void Jump(){
		if(speed>0){
			y_axis += space_time*speed;
			speed--;
		}
	}
	
	void Drop(){
		y_axis -= speed;
		speed++;
	}
}
