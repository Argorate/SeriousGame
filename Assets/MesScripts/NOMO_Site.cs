using System;

namespace AssemblyCSharp
{
	public class NOMO_Site
	{
		
		public float lat, lon;
		public TypeDeSite type;
		public String nom;
		
		
		
		public NOMO_Site (float lat , float lon, TypeDeSite type, String nom)
		{
			this.lat = lat; // Pour rentrer une latitute : - latitude Nord ou + latitude Sud
			this.lon = lon; // Latitude WEST > 0 , EAST < 0
			this.type = type;
			this.nom = nom;
		}
		
		
	}
}

