using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class ScriptJauge : MonoBehaviour {
	
	public GameObject progression;
	private bool mainJauge = false; //Concerne les jauges indicatrices de pays, et pas celles qui servent à illustrer les
	public Pays paysAssocie; //Le pays associe si c'est une jauge indicatrice
	public Jauge typeDeJauge; //Le type de jauge suivie
	
	void Start () {
	
	}
	
	void Update () {
		//gestion de la taille de la jauge
		if (mainJauge) {
			float val = (float)paysAssocie.getJauges()[(int)typeDeJauge];
			ajusterTaille(val , 1 , false);
		}		
	}
	
	public void ajusterTaille(float taille , float echelle, bool isOnCard) {
			if (isOnCard) taille *= -1;
			progression.transform.localScale = new Vector3(progression.transform.localScale.x,progression.transform.localScale.y,Mathf.Abs(taille)/100*0.2f*echelle);
			
			
			MeshFilter mf = progression.GetComponent(typeof(MeshFilter)) as MeshFilter;
			Mesh mesh = mf.sharedMesh;
			Vector3 size = mesh.bounds.size;
			Vector3 scale = progression.transform.localScale;
			
			progression.transform.localPosition = new Vector3(progression.transform.localPosition.x , Mathf.Sign(taille)*(scale.z*size.z)/2.0f , progression.transform.localPosition.z);		
	}
	
	public void setMainJauge(bool b) {
		mainJauge = b;
	}
	
	public bool isMainJauge() {
		return mainJauge;	
	}
}
