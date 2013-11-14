using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class ScriptCartes : MonoBehaviour {
	
	public Carte carte;
	public GameObject titre;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown () {
		Debug.Log ("Carte selectionnee : " + carte.getNom());
		carte.activer();
	}

}
