using UnityEngine;
using System;
using AssemblyCSharp;

public class GestionDuMonde : MonoBehaviour {
	
	/* Le méridien de Greenchiwh doit être orienté suivant X! */
	
	public Pays[] pays ;
	public GameObject greenwich;
	public GameObject objetSite;
	public GameObject objetSatellite;
	public int distanceSatellite = 200;

	
	// Use this for initialization
	void Start () {
			Data.monde = this.gameObject;
	}
	
	
	[RPC]
	void SetupTheWorld(){
		
		Debug.Log ("Setup the world");

		//pays = new Pays[1];
		//pays[0] = new NOMO_Angleterre();
		
		/*for (int i = 0; i < pays.Length; i++){
			setupPays(pays[i]);
		}*/
		
		/* Pour peut être la gestion des spheres, à voir…*/
		/*GameObject satelliteSymphonique = (GameObject)Network.Instantiate (objetSatellite, 
			Spherical((transform.localScale.x / 2.0f)+distanceSatellite,90.0f,0),
			Quaternion.identity);
		
		Data.satellite = satelliteSymphonique;
		
		Satellite sat = satelliteSymphonique.GetComponent(typeof(Satellite)) as Satellite;
		Debug.Log ("SAT : " + sat == null);
		sat.r = (transform.localScale.x / 2.0f);
		sat.phi = 0;
		sat.theta = 90.0f;
		*/
		
	}
	
	
	
	// Update is called once per frame
	void Update () {
	
		
		
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
	
	//Met en place les éléments d'un pays
	private void setupPays(Pays p){
		NOMO_Site c = p.getCapitale();
		Debug.Log ("NAME OF SITE : " + c.nom);
		setupSite(c , p);	
	}
	
	//Met en place un site
	private void setupSite(NOMO_Site s , Pays p){
		
		Debug.Log ("Mise en place d'un site");
		Debug.Log (Quaternion.LookRotation(Vector3.zero , Spherical((transform.localScale.x / 2.0f)+0.15f,s.lat + 90.0f,s.lon)));
		
/*var iblxPrefab : GameObject;
 
function Start() {
    var oneBlox : GameObject;
    oneBlox = Instantiate (iblxPrefab, xfrm.position, transform.rotation);
 
    var bloxScript = oneBlox.GetComponent("blxScript"); // name of script without the ".js" at the end.
    bloxScript.theBlockType = ii;                       // name of variable in script.
}*/
		
			GameObject nouveauSite;
		
			nouveauSite = (GameObject)/*Network.*/Instantiate (objetSite, 
			Spherical((transform.localScale.x / 2.0f)+0.15f,s.lat + 90.0f,s.lon),
			Quaternion.LookRotation(Spherical((transform.localScale.x / 2.0f)+0.15f,s.lat + 90.0f,s.lon), new Vector3 (0.0f , 1.0f , 0.0f ))/*,
			0*/);
		
		
			((Site) nouveauSite.GetComponent("Site")).setPays(p);
		
			((Site) nouveauSite.GetComponent("Site")).r = (transform.localScale.x / 2.0f);
			((Site) nouveauSite.GetComponent("Site")).theta = s.lat + 90.0f;
			((Site) nouveauSite.GetComponent("Site")).phi = s.lon;

		
			((Site) nouveauSite.GetComponent("Site")).site = s;
		
			GameObject go = GameObject.Find("Drapeau");
			Debug.Log ("DRAPEAU : " + go.ToString());
		
		
			go.renderer.material.mainTexture = null;

		
			//nouveauSite.transform.LookAt(this.gameObject.transform);
	}
	
}
