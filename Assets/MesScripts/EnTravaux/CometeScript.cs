using UnityEngine;
using System;
using AssemblyCSharp;

public class CometeScript : MonoBehaviour {
	
	public float rSpeed;
	public float thetaSpeed;
	public float phiSpeed;

	public float r;
	public float theta;
	public float phi;

	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
			float rS = Data.scriptSatellite.r;
			float thetaS = Data.scriptSatellite.theta;
			float phiS = Data.scriptSatellite.phi;
			//Debug.Log (rS + " " + thetaS + " " + phiS);

			if (rS > r) r -= rSpeed;
			else if (rS < r) r += rSpeed;	
		
			if (thetaS < theta) theta -= thetaSpeed;
			else if (thetaS > theta) theta += thetaSpeed;
		
			phi += distanceAngles(phi,phiS,180) * phiSpeed;

		
			if (phi > 180) phi -= 360;
			if (phi < -180) phi += 360;

		
			transform.position = Spherical (r , theta , phi);   
		 
		/*
				transform.position = Vector3.Scale(Vector3.MoveTowards(
			transform.localPosition,
			Data.monde.transform.localPosition,
			speed*Time.deltaTime) , new Vector3(-1,-1,-1));	
		 */
	}
	
	/* retourne -1 si il diminiuer le premier angle rapproche plus de second, 1 sinon*/
	private int distanceAngles (float a , float b, float limite) {
		
		float distP, distM;
		
		if (a<b) {
			distP = b - a;
			distM = (limite + a) + (limite - b);
		}
		else if (a>b){
			distP = a - b;
			distM = (limite + b) + (limite - a);
		} else {
			return 0;	
		}
		
		if (distP > distM) {
			return -1;	
		} else {
			return +1;
		}	
		
	}
	
	
	public void colorier (int i) {
		
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
