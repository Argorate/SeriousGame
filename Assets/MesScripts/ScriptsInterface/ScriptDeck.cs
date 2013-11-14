using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class ScriptDeck : MonoBehaviour {
	
	public Deck deck;
	public GameObject titre;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown () {
		piocher();	
	}
	
	void piocher() {
		Debug.Log ("Pioche");
		
		//TODO : gerer le coût en science
		if (true /*Cout en Science*/ && Partie.cartesEnMain.Count < Carte.limiteDeCartes) {
			

			GameObject objCarte = (GameObject) Instantiate(MultiplayerScript.multi.carte , Vector3.zero , Quaternion.identity);
			objCarte.transform.parent = Camera.main.transform;
			objCarte.transform.localPosition = new Vector3 (-8 + Partie.cartesEnMain.Count*3,-4,10);
			objCarte.transform.localRotation = Quaternion.identity;
			objCarte.transform.Rotate(270,0,0);

			ScriptCartes sc = (ScriptCartes) (objCarte.GetComponent("ScriptCartes"));
			sc.carte = deck.piocher();
			TextMesh tm = sc.titre.GetComponent<TextMesh>();  //On recupere le mesh de texte
			tm.text = sc.carte.getNom();
			Partie.cartesEnMain.Add(sc.carte);
			
			/* Affichage des jauges de variations */
			
			for (int i = 0 ; i < sc.carte.getVariations().Count ; i++) {

				Vector3 taille = collider.bounds.size;
				GameObject j = (GameObject) Instantiate(MultiplayerScript.multi.jauge , Vector3.zero , Quaternion.identity);
				Vector3 tailleJ = j.collider.bounds.size;

				j.transform.parent = sc.transform;
				Debug.Log("tailles : " + taille.x + "   " + tailleJ.x);
				j.transform.localPosition = new Vector3 (-(taille.x) + ((i*tailleJ.x)*2.85f),0.1f,0);
				j.transform.localRotation = Quaternion.identity;
				j.transform.Rotate(270,0,0);
				ScriptJauge sj = (ScriptJauge) (j.GetComponent("ScriptJauge"));
				sj.progression.renderer.material = MultiplayerScript.multi.materiauxJauges[(int)sc.carte.getJaugesCibles()[i]];
				sj.ajusterTaille((float)sc.carte.getVariations()[i] , 2f , true);
			}
			
		}
		
		
	}
}
