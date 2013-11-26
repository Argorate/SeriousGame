using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class ScriptShowComparaison : MonoBehaviour {

	private float sliderValue = 1.0f;
	private float maxSliderValue = 10.0f;
	public Jauge j;

	public float largeur = 200;
	public float hauteur = 95;
	public float incHauteur = 30;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		GUI.Box(new Rect (0,0,largeur,hauteur + (incHauteur * Partie.getJoueurs().Length)) , "");
		GUILayout.BeginArea (new Rect (0,0,largeur,hauteur + (incHauteur * Partie.getJoueurs().Length)));
		GUILayout.BeginVertical();
		GUILayout.Label("Sommet international de : " + j.ToString());

		// Begin the singular Horizontal Group
		GUILayout.BeginHorizontal();


			GUILayout.BeginVertical();

				for (int i = 0 ; i < Partie.getJoueurs().Length ; i++) {
					GUILayout.Label(Pays.allPays[i].indexPays.ToString());
				}
			GUILayout.EndVertical();

		
		// Arrange two more Controls vertically beside the Button
			GUILayout.BeginVertical();
				for (int i = 0 ; i < Partie.getJoueurs().Length ; i++) {
					GUILayout.Label(Pays.allPays[i].getJauges()[(int)j].ToString());
				};
		
		// End the Groups and Area
			GUILayout.EndVertical();
		GUILayout.EndHorizontal();

		if (GUILayout.RepeatButton ("Fermer"))
		{
			Destroy(gameObject);
		}
		
		GUILayout.EndVertical();
		GUILayout.EndArea();
	}
}
