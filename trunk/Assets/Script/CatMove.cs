using UnityEngine;
using System.Collections;

public class CatMove : MonoBehaviour
{
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	public bool airControl = false;
	private exSprite anim = null;
	private string a = "";
	private Vector3 scale;
	
	void Start ()
	{
		if (anim == null) {
			anim = this.GetComponent<exSprite> () as exSprite;
		}
		a = "CRM1201_101";
		scale = transform.localScale;
	}
	
	void Update ()
	{
		CharacterController controller = GetComponent<CharacterController> ();
		if (controller.isGrounded) {
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;
			airControl = false;
			
			if (Input.GetButton ("Jump")) {
				moveDirection.y = jumpSpeed;
				airControl = true;
			}
			if (Input.GetKey ("left")) {
				scale.x = 1;
				
				if (a != "CRM1201_202_Loop") {
					anim.spanim.Play ("CRM1201_202_Loop");
					a = "CRM1201_202_Loop";
				}
			}
			if (Input.GetKey ("right")) {
				scale.x = -1;
				
				if (a != "CRM1201_202_Loop") {
					anim.spanim.Play ("CRM1201_202_Loop");
					a = "CRM1201_202_Loop";
				}
			}
			
			if (Input.GetKeyUp ("right") || Input.GetKeyUp ("left")) {
				if (a != "CRM1201_101") {
					anim.spanim.Play ("CRM1201_101");
					a = "CRM1201_101";
				}
			}
		}
		
		if (airControl) {
			moveDirection.x = Input.GetAxis ("Horizontal") * speed;
			moveDirection.z = 0;
			
			if (a != "CRM1201_101") {
				anim.spanim.Play ("CRM1201_101");
				a = "CRM1201_101";
			}
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
		transform.localScale = scale;
	}
}
