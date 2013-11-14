using UnityEngine;
using System.Collections;
using AssemblyCSharp;


public class Site : MonoBehaviour {
	
	
	public EnumTypeDeSite typeDeSite;
	
	private bool selected;
	private float[] dT = new float[3];
	private Pays pays;
	
	public NOMO_Site site;
	public GameObject comete;
	public float tempsEntreCometes;
	
	public float r;
	public float theta;
	public float phi;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < dT.Length ; i++) {
			dT[i] = 0.0f;	
		}
		
	}
	
	// Update is called once per frame
	private void Update(){
		
		/*
		Debug.Log("SITE NAME: " + site.nom);
		Debug.Log("TYPE : " + site.type);

		Debug.Log ("Capital ? : " + site.type.isCapital());
		if (site.type.isCapital()){
			
			for (int i = 0 ; i < 3 ; i++) {
				dT[i] += Time.deltaTime;
				//Debug.Log ("I"+ i + " : " + dT[i]);
				if (dT[i] > tempsEntreCometes / pays.getJauges()[i]) {
					dT[i] -= tempsEntreCometes / pays.getJauges()[i];
					
					GameObject nouvelleComete = (GameObject)Instantiate (comete, 
						transform.position,
						Quaternion.identity);
				}
			((CometeScript) comete.GetComponent("CometeScript")).colorier(i);
			
			((CometeScript) comete.GetComponent("CometeScript")).r = r;
			((CometeScript) comete.GetComponent("CometeScript")).theta = theta;
			((CometeScript) comete.GetComponent("CometeScript")).phi = phi;
			}
		}*/
	}
			


	
	void OnMouseDown(){	
		if (!Partie.getMyself().isSelecting){
			Debug.Log ("Selection d'un site");
			AnimerLaSelection();
			selected = true;
			Partie.getMyself().isSelecting = true;
		}

		
	}
	
	void OnMouseEnter(){
		Debug.Log("ENTER!!");	
	}
	
	void OnGUI(){
		if (selected){
			Rect windowRect = new Rect (20, 20, 300, 50);
			windowRect = GUILayout.Window (10, windowRect, DrawWindow, site.nom);
		}
	}
	



	private void DrawWindow (int windowID) {
		
		if (GUILayout.Button ("Fermer")){
			selected = false;
			Partie.getMyself().isSelecting = false;
		}
		
		GUI.DragWindow (new Rect (0,0,10000,10000));
	}
	
	//Pour animer le click de la souris
	IEnumerator AnimerLaSelection()
	{
		for (float f = 1f; f <= 0; f -= 0.1f) {
			Debug.Log ("Animation de la sélection");
			yield return new WaitForSeconds(.1f);
		}
	}
	
	
	public void setPays (Pays p) {
		pays = p;
	}
}




public enum EnumTypeDeSite
    {
    Mine, Centrale, SiteNaturel
    }
     
