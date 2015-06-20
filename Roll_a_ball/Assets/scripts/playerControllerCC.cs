using UnityEngine;
using System.Collections;

public class playerControllerCC : MonoBehaviour {

	//PUBLIC VARIABLES
	public float speed = 0.20F;
	public float rotateSpeed = 50F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public GameObject sphereMesh;

	//PRIVATE VARIABLES
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;


	// Use this for initialization
	void Start () 
	{
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame

	void Update() 
	{

		//sphereMesh.transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, Input.GetAxis("Vertical") * speed);

		if(controller.isGrounded) {
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;
			if (Input.GetButton ("Jump"))
				moveDirection.y = jumpSpeed;
			
		} 

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);

		//rotations
	
		Vector3 pivot = controller.transform.position;
		float angleSideways = 10 * Input.GetAxis ("Horizontal");
		float angleForward = 10 * Input.GetAxis ("Vertical");

		// To rotate around the world's up axis
		//sphereMesh.transform.RotateAround(pivot, Vector3.up, angle);
		//sphereMesh.transform.RotateAround(pivot, Vector3.left, angleForward);

		// To rotate around the object's up axis
		sphereMesh.transform.RotateAround(pivot, sphereMesh.transform.forward, -angleSideways);

		//sphereMesh.transform.RotateAround(pivot, sphereMesh.transform.right, angleForward);


		//sphereMesh.transform.rotation=Quaternion.identity;
		//sphereMesh.transform.Rotate(moveDirection,Space.World); 
		//sphereMesh.transform.Rotate( 0.5f, -0.5f, 0 );
		//Vector3 forward = transform.TransformDirection(Vector3.forward);
		//float curSpeed = speed * Input.GetAxis("Vertical");
		//controller.SimpleMove(forward * curSpeed);


	}

}
