using UnityEngine;
using System;
using AssemblyCSharp;
using System.Collections;

namespace AssemblyCSharp
{
	//Pour creer une carte --> la declarer dans CartesEnum et initialiser ici dans le switch
	
	
	public class Carte
	{		
		public static int limiteDeCartes = 6;
		public static string[] nomDesCartes;
		public static double[] coutArgent;
		public static double[] coutScience;
		public static ArrayList[] variations;
		public static ArrayList[] jaugesCibles;
		public static ArrayList[] effets;
			// 0 : normal
			// 1 : altère la variation et non le capital
			//
		public static int nombreDeCartesDifferentes;
		public CartesEnum typeDeCarte;

		public Carte (CartesEnum typeDeCarte)
		{
			this.typeDeCarte = typeDeCarte;	
		}
		
		public static void initCartes () {
			
			nombreDeCartesDifferentes = Enum.GetNames(typeof(CartesEnum)).Length;
			nomDesCartes = new string[nombreDeCartesDifferentes];
			coutArgent = new double[nombreDeCartesDifferentes];
			coutScience = new double[nombreDeCartesDifferentes];
			variations = new ArrayList[nombreDeCartesDifferentes];
			jaugesCibles = new ArrayList[nombreDeCartesDifferentes];
	
			foreach (CartesEnum e in (CartesEnum[]) Enum.GetValues(typeof(CartesEnum))) {
				variations[(int)e] = new ArrayList();
				jaugesCibles[(int)e] = new ArrayList();
			}


			foreach (CartesEnum e in (CartesEnum[]) Enum.GetValues(typeof(CartesEnum)))
				{
				
				switch (e) {
					
				case CartesEnum.ConstruireDesCentralesNucleaire:
					nomDesCartes[(int)e] = "Construire des centrales nucleaires";
					coutArgent[(int)e] = 70.0;
					coutScience[(int)e] = 45.0;
					Carte.impact(e,Jauge.energie,40.0f);
					Carte.impact(e,Jauge.opinion,-10.0f);
					Carte.impact(e,Jauge.ecologie,-5.0f);
					break;
					
				case CartesEnum.ConstruireDesEoliennes:
					nomDesCartes[(int)e] = "Construire des eoliennes";
					coutArgent[(int)e] = 55.0;
					coutScience[(int)e] = 5.0;
					Carte.impact(e,Jauge.energie,10.0f);
					Carte.impact(e,Jauge.opinion,5.0f);
					break;
					
					
					
				default:
					break;
				}
				
			}
		}
		
		public string getNom() {
			return Carte.nomDesCartes[(int)this.typeDeCarte];	
		}
		
		public double getCoutArgent() {
			return Carte.coutArgent[(int)this.typeDeCarte];	
		}
		
		public double getCoutScience() {
			return Carte.coutScience[(int)this.typeDeCarte];	
		}
		
		public ArrayList getVariations() {
			return Carte.variations[(int)this.typeDeCarte];
		}
		
		public ArrayList getJaugesCibles() {
			return Carte.jaugesCibles[(int)this.typeDeCarte];
		}
		
		static private void impact (CartesEnum e , Jauge j , float v , Effet ef) {
			variations[(int)e].Add(v);
			jaugesCibles[(int)e].Add(j);
			effets[(int)e].Add(ef);

		}

		static private void impact (CartesEnum e , Jauge j , float v) {
			variations[(int)e].Add(v);
			jaugesCibles[(int)e].Add(j);
			effets[(int)e].Add(Effet.total);			
		}

		/* Active la carte et fait un effet en fonction de son type*/
		public void activer () {
			
			for (int i = 0 ; i < variations[(int)typeDeCarte].Count ; i++) {
				MultiplayerScript.multi.networkView.RPC(
					"changeJauge" ,
					RPCMode.AllBuffered ,
					(int)(Partie.monPays.indexPays) ,
					(int)(jaugesCibles[(int)typeDeCarte][i]),
					(float)(variations[(int)typeDeCarte][i]));
			}
		}
	}
}

public enum Effet
{
	/*----------------Les effets des cartes----------------*/
	
	total, //Altere le total
	derivee, //Altere la derivee de la jauge
	
	/*---------------------------------------*/
}
