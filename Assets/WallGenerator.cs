using UnityEngine;
using System.Collections;

public class WallGenerator : MonoBehaviour {

	public GameObject start;
	public GameObject end;
	public GameObject wallPrefab;
	GameObject wall;
	GameObject terrainObject;
	Terrain terrain;
	public Vector3 terrainSize;
	Vector3 startPos;
	Vector3 endPos;
	Texture2D texture;

	// Use this for initialization
	void Start () {
		texture = (Texture2D)Resources.Load ("rock", typeof(Texture2D)); //Texture from http://opengameart.org/node/10187 under Public Domain license on 8 June 2016
		terrainObject = GameObject.Find ("Terrain");
		terrain = (Terrain)terrainObject.GetComponent ("Terrain");
		terrainSize = terrain.terrainData.size;
//		startPos = new Vector3 (0, 0, 0);
//		endPos = new Vector3 (1000, 0, 0);
//		setStart();
//		setEnd ();
//		adjustWall();

		startPos = new Vector3 (terrainSize.x, 30, terrainSize.z);
		endPos = new Vector3 (terrainSize.x, 30, terrainSize.z - 1000);
		setStart();
		setEnd ();
		adjustWall();
		wall.GetComponent<Renderer> ().material.mainTexture = texture;

		startPos = new Vector3 (terrainSize.x, 30, terrainSize.z-1000);
		endPos = new Vector3 (terrainSize.x-1000, 30, terrainSize.z - 1000);
		setStart();
		setEnd ();
		adjustWall();
		wall.GetComponent<Renderer> ().material.mainTexture = texture;

		startPos = new Vector3 (terrainSize.x-1000, 30, terrainSize.z - 1000);
		endPos = new Vector3 (terrainSize.x-1000, 30, terrainSize.z);
		setStart();
		setEnd ();
		adjustWall();
		wall.GetComponent<Renderer> ().material.mainTexture = texture;

		startPos = new Vector3 (terrainSize.x-1000, 30, terrainSize.z);
		endPos = new Vector3 (terrainSize.x, 30, terrainSize.z);
		setStart();
		setEnd ();
		adjustWall();
		wall.GetComponent<Renderer> ().material.mainTexture = texture;
	}
	
	// Update is called once per frame
	void Update () {
		//getInput ();

	}

	void setStart(){
		start.transform.position = startPos;
		wall = (GameObject)Instantiate (wallPrefab, start.transform.position, Quaternion.identity);
	}

	void setEnd(){
		end.transform.position = endPos;
	}

	void adjustWall(){
		start.transform.LookAt (end.transform.position);
		end.transform.LookAt (start.transform.position);
		float distance = Vector3.Distance (start.transform.position, end.transform.position);
		wall.transform.position = start.transform.position + distance / 2 * start.transform.forward;
		wall.transform.rotation = start.transform.rotation;
		wall.transform.localScale = new Vector3 (wall.transform.localScale.x, wall.transform.localScale.y, distance);
	}

}
