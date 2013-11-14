using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Partie {
	
	
	static Joueur[] joueurs;
	public static int myPlayerID;
	public static Pays monPays;
	public static ArrayList cartesEnMain = new ArrayList();
	public static GameObject[] mesJauges = new GameObject[10];
	
	
	public static void setJoueurs (Joueur[] j){
		joueurs = j;
	}
	
	public static Joueur[] getJoueurs (){
		return joueurs;
	}
	
	/*Retourne l'objet joueur associé au joueur actuel*/
	public static Joueur getMyself (){
		return joueurs[myPlayerID];
	}
	
}

