using UnityEngine;
using System.Collections;

public class playerControllerRB : MonoBehaviour 
{

	//PUBLIC VARIBALES
	//Speed factor
	public float speedFactor;
	public GameObject outOfBoundsMesh;

	//PRIVATE VARIABLES
	//the rigidBody component of the player
	private Rigidbody rb;
	//the rigidBody component of the player
	private SphereCollider sc;
	//the MeswhRenderer component of the player
	private MeshRenderer ms;
	//detect if airborn
	private bool airborne;
	//check if on the groun
	private float radius = 0.0f;
	private Vector3 currentPosition;


	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		sc = GetComponent<SphereCollider>();
		ms = GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float horizontalMovement = Input.GetAxis ("Horizontal");
		float verticalMovement = Input.GetAxis ("Vertical");

		currentPosition = rb.position;

		Vector3 movement = new Vector3 (horizontalMovement, 0.0f, verticalMovement);

		if (Input.GetKeyDown ("space") && IsGrounded())
			movement.y = 30;


		rb.AddForce (movement * speedFactor);
		//rb.AddTorque (side * speedFactor);

	}


	//CUSTOME FUNCTIONS
	bool IsGrounded()
	{
		return Physics.Raycast(transform.position, -Vector3.up, sc.radius);
	}


	void OnCollisionEnter (Collision col)
	{

		if(col.gameObject.name == outOfBoundsMesh.name)
		{
			currentPosition.y = 2;
			currentPosition.x = 0;
			StartCoroutine(ResetDelay());
			rb.position = currentPosition;
			rb.velocity = new Vector3(0, 0, 0);
		}
	}



	IEnumerator ResetDelay() 
	{
		Time.timeScale = 0.1f;
		float pauseEndTime = Time.realtimeSinceStartup + 1;
		while (Time.realtimeSinceStartup < pauseEndTime)
		{
			ms.enabled = false;
			yield return 0;
			ms.enabled = true;
		}

		Time.timeScale = 1;
	}



}

