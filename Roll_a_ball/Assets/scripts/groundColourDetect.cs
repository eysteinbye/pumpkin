using UnityEngine;
using System.Collections;


public class NewBehaviourScript : MonoBehaviour 
{

	public float centerOfGravityY = 0.0f;
	public Texture2D sourceTex;

	// Use this for initialization
	void Start () 
	{
		// I usually alter the center of mass to make the car more stable. I'ts less likely to flip this way
		GetComponent<Rigidbody>().centerOfMass = new Vector3(0.0f, centerOfGravityY, 0.1f);
		//rigidbody.centerOfMass += new Vector3(0.0f, centerOfGravityY, 0.1f);
		
		Debug.Log ("rigidbody.centerOfMass");
		Debug.Log (GetComponent<Rigidbody>().centerOfMass);



	}
	
	// Update is called once per frame
	void Update () 
	{
		RaycastHit hit;
		float distanceToGround = 0;
		
		if (Physics.Raycast(transform.position, Vector3.down, out hit, 100.0F))
		{
			distanceToGround = hit.distance;
			Renderer rend = hit.transform.GetComponent<Renderer>();
			Texture2D tex = rend.material.mainTexture as Texture2D;
			Vector2 pixelUV = hit.textureCoord;
			pixelUV.x *= tex.width;
			pixelUV.y *= tex.height;

			//Color[] pix = sourceTex.GetPixels(hit.textureCoord.x, hit.textureCoord.y, tex.width, tex.height);
			if( tex.GetPixel((int)pixelUV.x, (int)pixelUV.y) == Color.black )
			{
				print("It's black!!");
			}
			else if( tex.GetPixel((int)pixelUV.x, (int)pixelUV.y) == Color.white )
			{
				print("It's white!!");
			}

		}


	}

}
