using UnityEngine;
using System.Collections;

public class playerControllerCC : MonoBehaviour {

	//PUBLIC VARIABLES
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public GameObject rotZobject;
	public GameObject rotXobject;
	public GameObject sphereMesh;

	//PRIVATE VARIABLES
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;

	//rotations
	private float rotX = 0.0f;
	private float rotZ = 0.0f;

	private float distance = 5.0f;
	private float xSpeed = 100.0f;
	private float ySpeed = 100.0f;

	// Use this for initialization
	void Start () 
	{
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame

	void Update() 
	{
		if (controller.isGrounded) {
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;
			if (Input.GetButton ("Jump"))
				moveDirection.y = jumpSpeed;
			
		} 
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		rotZ -= Input.GetAxis("Horizontal") * xSpeed * distance* 0.02f;
		//Quaternion rotationZ = Quaternion.Euler(0.0f, 0.0f, rotZ);
		//rotZobject.transform.rotation = rotationZ;
		//rotZobject.transform.Rotate(0, 0, rotZ, Space.Self);

		rotX += Input.GetAxis ("Vertical") * ySpeed * distance* 0.02f;
		//Quaternion rotationX = Quaternion.Euler(rotX, 0.0f, 0.0f);
		//rotXobject.transform.rotation = rotationX;
		//rotZobject.transform.Rotate(rotX, 0, 0, Space.Self);

		Debug.Log (rotZ);
		rotZobject.transform.eulerAngles = new Vector3(rotX, 0, -rotZ);
		//rotXobject.transform.eulerAngles = new Vector3(, 0, 0);









	}
}
