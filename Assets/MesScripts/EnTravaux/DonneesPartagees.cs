using UnityEngine;
using System.Collections;
using AssemblyCSharp;


namespace AssemblyCSharp
{
	public class DonneesPartagees
	{
		public Pays[] pays;
		public static DonneesPartagees donnesPartagees;
		
		public DonneesPartagees (Pays[] pays)
		{
			this.pays = pays;
			donnesPartagees = this;
		}
	}
}

