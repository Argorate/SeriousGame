using UnityEngine;
using System.Collections;
using System;





public class CameraScript : MonoBehaviour {
	
	public GameObject world;
	public float distanceMax;
	public float distanceMin;
	public float distanceInit;
	public float speed;

	//Coordonnées sphériques
	private float r;
	private float theta;
	private float phi;

	
	// Use this for initialization
	void Start () 
	{
		Debug.Log("camera chargée");
		theta =  0.0f;
		phi =  0.0f;
		r = world.transform.localScale.y / 2.0f + distanceInit;
		
		transform.position = Spherical(r,theta,phi);
		transform.LookAt(world.transform);
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		
		float horizontalAxis = Input.GetAxis("Horizontal");
		float verticalAxis = Input.GetAxis("Vertical");
		float zAxis = Input.GetAxis("Mouse ScrollWheel");
		
		theta += verticalAxis;
		phi += horizontalAxis;
		r -= zAxis * speed;
		
		if (r > (world.transform.localScale.x / 2.0f) + distanceMax){
			r = (world.transform.localScale.x / 2.0f) + distanceMax;	
		}
		
		if (r < (world.transform.localScale.x / 2.0f) + distanceMin){
			r = (world.transform.localScale.x / 2.0f) + distanceMin;	
		}
		
		transform.position = Spherical(r,theta,phi);
		transform.LookAt(world.transform);


		
	}
			
	//Conversion de coordonnées sphériques en cartésiennes
	public Vector3 Spherical(float r, float theta, float phi) 
	{
	    float snt = (float)Math.Sin(theta * Math.PI / 180); 
	    float cnt = (float)Math.Cos(theta * Math.PI / 180); 
	    float snp = (float)Math.Sin(phi * Math.PI / 180); 
	    float cnp = (float)Math.Cos(phi * Math.PI / 180); 
	    return new Vector3(r * snt * cnp,r * cnt,-r * snt * snp); 
	} 
	
	
}
			
			
