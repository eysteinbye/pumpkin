using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class levelGenerator : MonoBehaviour 
{

	//public string modelPath = "Assets/Models/LevelPieces/"
	// Use this for initialization


	//DirectoryInfo dir = new DirectoryInfo("Assets/Models/LevelPieces");
	//FileInfo[] info = dir.GetFiles("*.fbx");

	void Start () 
	{
		Debug.Log ("model loaded");
		List<GameObject> preFabs = FindAssetsUsingSearchFilter ();
		//GameObject[] preFabs = GetLevelPreFabs ();
		foreach (GameObject preFab in preFabs) 
		{
			preFab.transform.position = new Vector3 (10, 10, 10);
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public List<GameObject> FindAssetsUsingSearchFilter () 
	{
		// Find all level assets 
		string[] GUIDs = AssetDatabase.FindAssets("", new string[] {"Assets/Models/LevelPieces"});
		//store gameObjects
		List<GameObject> preFabs = new List<GameObject>();
		//loop over paths
		foreach(string fbx in GUIDs)
		{
			//Debug.Log (AssetDatabase.GUIDToAssetPath(fbx));
			string path = AssetDatabase.GUIDToAssetPath(fbx);
			Mesh mesh = Resources.Load(fbx) as Mesh;
			GameObject tile = new GameObject(path); 
			tile.AddComponent<MeshFilter>();
			tile.AddComponent<MeshRenderer>();
			tile.GetComponent<MeshFilter>().mesh = mesh;
			tile.GetComponent<MeshRenderer>().material = Resources.Load("Materials/SquareGroundB&W") as Material;
			preFabs.Add(tile);
		}
		return preFabs;



	}



}

/*
using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour {
	public Vector3[] newVertices;
	public Vector2[] newUV;
	public int[] newTriangles;
	void Start() {
		Mesh mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
		mesh.vertices = newVertices;
		mesh.uv = newUV;
		mesh.triangles = newTriangles;
	}
}
*/