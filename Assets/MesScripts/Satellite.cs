using UnityEngine;
using System.Collections;
using System;
using AssemblyCSharp;

public class Satellite : MonoBehaviour {
	
	//Coordonnées sphériques
	public float r;
	public float theta;
	public float phi;
	
	public float vitesseAngulaire = 0.03f;
	
	
	// Use this for initialization
	void Start () {
		Data.scriptSatellite = this;
	
	}
	
	// Update is called once per frame
	void Update () {
		phi += vitesseAngulaire * Time.deltaTime;
		
		if (phi > 180.0f ) phi -= 360.0f;

		
		transform.localPosition = this.Spherical(r, theta, phi);
		//transform.Translate(new Vector3(0,0,0) * Time.deltaTime);
	}
	
	
	//Conversion de coordonnées sphériques en cartésiennes
	private Vector3 Spherical(float r, float theta, float phi) 
	{
	    float snt = (float)Math.Sin(theta * Math.PI / 180); 
	    float cnt = (float)Math.Cos(theta * Math.PI / 180); 
	    float snp = (float)Math.Sin(phi * Math.PI / 180); 
	    float cnp = (float)Math.Cos(phi * Math.PI / 180); 
	    return new Vector3(r * snt * cnp,r * cnt,-r * snt * snp); 
	} 
	
}
