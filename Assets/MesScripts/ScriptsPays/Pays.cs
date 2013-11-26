using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Pays{
	
	public static Pays[] allPays;
	
	protected NOMO_Site capitale;
	protected Texture flag;
	protected double[] jauges = new double[10];
	protected double[] dJauges = new double[10];
	public EnumPays indexPays;
	
	
	public virtual Texture getFlag(){
		return flag;	
	}
	
	public NOMO_Site getCapitale(){
		return capitale;
	}
	
	public double[] getJauges() {
		return jauges;	
	}
	
	public Pays (int indexPays) {
		this.indexPays = (EnumPays) indexPays;
		Debug.Log("Initialisation du pays : " + indexPays);
	}
	
	public void initPays() {
		
		switch (indexPays) {
		
		case EnumPays.USA:
			jauges[(int) Jauge.argent] = 20.0f;
			jauges[(int) Jauge.science] = 100.0f;
			jauges[(int) Jauge.carburants] = 20.0f;
			jauges[(int) Jauge.eau] = 20.0f;
			jauges[(int) Jauge.ecologie] = -30.0f;
			jauges[(int) Jauge.energie] = 10.0f;
			jauges[(int) Jauge.niveauDeVie] = 30.0f;
			jauges[(int) Jauge.nourriture] = 30.0f;
			jauges[(int) Jauge.opinion] = 20.0f;
			jauges[(int) Jauge.societe] = -10.0f;
			break;
			
		case EnumPays.France:
			jauges[(int) Jauge.argent] = 20.0f;
			jauges[(int) Jauge.science] = 100.0f;
			jauges[(int) Jauge.carburants] = 20.0f;
			jauges[(int) Jauge.eau] = 20.0f;
			jauges[(int) Jauge.ecologie] = 0.0f;
			jauges[(int) Jauge.energie] = 10.0f;
			jauges[(int) Jauge.niveauDeVie] = 30.0f;
			jauges[(int) Jauge.nourriture] = 30.0f;
			jauges[(int) Jauge.opinion] = 20.0f;
			jauges[(int) Jauge.societe] = 0.0f;
			break;
		
		default:
			jauges[(int) Jauge.argent] = 20.0f;
			jauges[(int) Jauge.science] = 100.0f;
			jauges[(int) Jauge.carburants] = 20.0f;
			jauges[(int) Jauge.eau] = 20.0f;
			jauges[(int) Jauge.ecologie] = 0.0f;
			jauges[(int) Jauge.energie] = 10.0f;
			jauges[(int) Jauge.niveauDeVie] = 30.0f;
			jauges[(int) Jauge.nourriture] = 30.0f;
			jauges[(int) Jauge.opinion] = 20.0f;
			jauges[(int) Jauge.societe] = 0.0f;
			break;
		}
		
	}
	
	public ArrayList createDeck(int typeDeDeck) {
		
		/* Mecanisme simple mais un peu barbare...
		 * Mais qui evite de parser des fichiers : c'est du prototypage rapide :p
		 */
		Debug.Log ("getDeck + " + typeDeDeck);
		
		ArrayList cartes = new ArrayList();
		
		
		switch (indexPays) {
		
		case EnumPays.USA:
					
			if (typeDeDeck == 0) { 

				// USA + Science
				cartes.Add(new Carte(CartesEnum.ConstruireDesEoliennes));
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));
				cartes.Add(new Carte(CartesEnum.ConstruireDesEoliennes));
				cartes.Add(new Carte(CartesEnum.ConstruireDesEoliennes));
				cartes.Add(new Carte(CartesEnum.ConstruireDesEoliennes));

			} else if (typeDeDeck == 1) {

				// USA + Legislation 
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));	
				
			} else if (typeDeDeck == 2) {

				// USA + International
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));
				
			} else if (typeDeDeck == 3) {
				
				// USA + Economie
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));
			
			} else if (typeDeDeck == 4) {
				
				// USA + Ecologie 
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));
				
			}
			
			break;
			
		case EnumPays.France:
					
			if (typeDeDeck == 0) { 

				// France + Science
				cartes.Add(new Carte(CartesEnum.ConstruireDesEoliennes));
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));
				cartes.Add(new Carte(CartesEnum.ConstruireDesEoliennes));
				cartes.Add(new Carte(CartesEnum.ConstruireDesEoliennes));
				cartes.Add(new Carte(CartesEnum.ConstruireDesEoliennes));

			} else if (typeDeDeck == 1) {

				// France + Legislation 
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));	
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));	
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));	

				
			} else if (typeDeDeck == 2) {

				// France + International
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));
				
			} else if (typeDeDeck == 3) {
				
				// France + Economie
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));
			
			} else if (typeDeDeck == 4) {
				
				// France + Ecologie 
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));
				
			}
			
			break;


		case EnumPays.Russie:
			
			if (typeDeDeck == 0) { 
				
				// France + Science
				cartes.Add(new Carte(CartesEnum.ConstruireDesEoliennes));
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));
				cartes.Add(new Carte(CartesEnum.ConstruireDesEoliennes));
				cartes.Add(new Carte(CartesEnum.ConstruireDesEoliennes));
				cartes.Add(new Carte(CartesEnum.ConstruireDesEoliennes));
				
			} else if (typeDeDeck == 1) {
				
				// France + Legislation 
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));	
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));	
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));	
				
				
			} else if (typeDeDeck == 2) {
				
				// France + International
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));
				
			} else if (typeDeDeck == 3) {
				
				// France + Economie
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));
				
			} else if (typeDeDeck == 4) {
				
				// France + Ecologie 
				cartes.Add(new Carte(CartesEnum.ConstruireDesCentralesNucleaire));
				
			}
			
			break;
		
		default: 
			break;
		}
		
		return cartes;
		
		
		
		}
	
		
	
	
	}	
	