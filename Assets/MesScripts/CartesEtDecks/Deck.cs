using UnityEngine;
using System.Collections;
using AssemblyCSharp;

namespace AssemblyCSharp
{
	public class Deck
	{
		public static string[] nomDesDecks = { "Science" , "Legislation" , "International" , "Economie" , "Ecologie"};
		public static Deck[] mesDecks;
		int typeDeDeck;
		
		/*ça aurait pu être des piles... Mais on est pas à une chose pas optimisée prêt.*/
		ArrayList pioche = new ArrayList();
		ArrayList defausse = new ArrayList();

		public Deck (int typeDeDeck)
		{
			this.typeDeDeck = typeDeDeck;
		}
		
		static public Deck[] getMesDecks() {
			return mesDecks;	
		}
		
		public int getTypeDeDeck() {
			return typeDeDeck;	
		}
		
		public void composerDeck(Pays p) {
			pioche = p.createDeck(typeDeDeck);
			melanger();
		}
		
		public void melanger() {
			
			Debug.Log("mel");
			/* On commence par défausser la pioche */
			while (pioche.Count > 0) {
							Debug.Log("pio");

				defausse.Add (pioche[0]);
				pioche.RemoveAt(0);
			}
			
			/* Puis on re-compose la pioche en tirant des cartes au hasard de la defausse */
			while (defausse.Count > 0) {
							Debug.Log("def");

				int r = Random.Range(0 , defausse.Count);
				pioche.Add (defausse[r]);
				defausse.RemoveAt(r);
			}
			
		}
		
		public Carte piocher(){
			Carte c = (Carte) pioche[pioche.Count - 1];
			pioche.RemoveAt(pioche.Count - 1);

			Debug.Log("carte piochée : " + Carte.nomDesCartes[(int) c.typeDeCarte] + "il reste " + pioche.Count);
			return c;
		}
		
	}
	
	
	
	
	
}

