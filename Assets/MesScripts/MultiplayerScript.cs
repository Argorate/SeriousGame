using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System;


public class MultiplayerScript : MonoBehaviour {
	
	//Variables Start___________________________________
	
	public static MultiplayerScript multi;
	
	private string titleMessage = "Serious Game";
	private string connectToIP = "127.0.0.1";
	private int connectionPort = 26500;
	private bool useNAT = false;
	private string ipAddress;
	private string port;
	private int numberOfPlayers = 10;
	public string playerName;
	public string serverName;
	public string serverNameForClient;
	private bool iWantToSetupAServer = false;
	private bool iWantToConnectToAServer = false;
	private bool afficherFenetreDeMiseEnPlace = false;
	public GameObject monde ;
	public GameObject cam;
	public GameObject carte;   //Le prefab des cartes
	public GameObject deck;    //Le prefab des decks
	public GameObject jauge;   //etc...
	public DonneesPartagees donneePartagees;
	public Material[] materiauxJauges = new Material[10];
	GameObject mondeInstance;
	public NetworkView networkView;
	
	//These variables are used to define the main
	//window.
	
	private Rect connectionWindowRect;
	private Rect fenetreDeMiseEnPlace;

	private int connectionWindowWidth = 400;
	
	private int connectionWindowHeight = 280;
	
	private int buttonHeight = 60;
	
	private int leftIndent;
	
	private int topIndent;
	
	
	//These variables are used to define the server
	//shutdown window.
	
	private Rect serverDisWindowRect;
	
	private int serverDisWindowWidth = 300;
	
	private int serverDisWindowHeight = 150;
	
	private int serverDisWindowLeftIndent = 10;
	
	private int serverDisWindowTopIndent = 10;
	
	
	//These variables are used to define the client
	//disconnect window.
	
	private Rect clientDisWindowRect;
	
	private int clientDisWindowWidth = 300;
	
	private int clientDisWIndowHeight = 170;
	
	public bool showDisconnectWindow = false;
	
	
	//These are used in setting the winning score.
	
	public int winningScore = 20;
	
	private int scoreButtonWdith = 40;
	
	private GUIStyle plainStyle = new GUIStyle();
	
	//Variables End_____________________________________
	
	
	// Use this for initialization
	void Start () 
	{	
		multi = this;
		Carte.initCartes();
		serverName = PlayerPrefs.GetString("serverName");
		
		if(serverName == "")
		{
			serverName = "Serveur";	
		}
		
		playerName = PlayerPrefs.GetString("playerName");
		
		if(playerName == "")
		{
			playerName = "Anonyme";	
		}
				
		plainStyle.alignment = TextAnchor.MiddleLeft;
		
		plainStyle.normal.textColor = Color.white;
	}

	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			showDisconnectWindow = !showDisconnectWindow;	
		}
		if (Network.peerType == NetworkPeerType.Server) {
			winningScore++;	
		}
	}
	/*
    void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
		Debug.Log("serial");
        if (stream.isWriting) {
            stream.Serialize(ref winningScore);
        } else {
            int win = 0;
            stream.Serialize(ref win);
            winningScore = win;
        }
    }*/
	
	
	void ConnectWindow(int windowID)
	{

		GUILayout.Space(15); 
		
		if(iWantToSetupAServer == false && iWantToConnectToAServer == false)
		{
			if(GUILayout.Button("Setup a server", GUILayout.Height(buttonHeight)))
			{
				iWantToSetupAServer = true;
			}
			
			GUILayout.Space(10);
			
			if(GUILayout.Button("Connect to a server", GUILayout.Height(buttonHeight)))
			{
				iWantToConnectToAServer = true;
			}
			
			GUILayout.Space(10);
			
			if(Application.isWebPlayer == false && Application.isEditor == false)
			{
				if(GUILayout.Button("Exit Prototype", GUILayout.Height(buttonHeight)))
				{
					Application.Quit();	
				}
			}
		}
		
		
		if(iWantToSetupAServer == true)
		{

			GUILayout.Label("Entrez le nom du serveur");
			
			serverName = GUILayout.TextField(serverName);
			
			GUILayout.Space(5);
			GUILayout.Label("Port : ");
			
			connectionPort = int.Parse(GUILayout.TextField(connectionPort.ToString()));
			
			
			GUILayout.Space(10);
			
			if(GUILayout.Button("Demarrage du serveur", GUILayout.Height(30)))
			{
				Network.InitializeServer(numberOfPlayers, connectionPort, useNAT);
				
				PlayerPrefs.SetString("serverName", serverName);
							
				iWantToSetupAServer = false;
				afficherFenetreDeMiseEnPlace = true;

			}
			
			if(GUILayout.Button("Go Back", GUILayout.Height(30)))
			{
				iWantToSetupAServer = false;	
			}
		}
		
		
		if(iWantToConnectToAServer == true)
		{
			GUILayout.Label("Entrez votre nom : ");			
			playerName = GUILayout.TextField(playerName);
			
			GUILayout.Space(5);
			
			GUILayout.Label("IP du serveur : ");
			connectToIP = GUILayout.TextField(connectToIP);
			
			GUILayout.Space(5);
			
			GUILayout.Label("Port : ");	
			connectionPort = int.Parse(GUILayout.TextField(connectionPort.ToString()));	
			
			GUILayout.Space(5);
			
			if(GUILayout.Button("Connection", GUILayout.Height(25)))
			{
				if(playerName == "")
				{
					playerName = "Anonyme";	
				}

				Network.Connect(connectToIP, connectionPort);
				afficherFenetreDeMiseEnPlace = true;  // Affiche le "salon" de création de la partie
				PlayerPrefs.SetString("Player Name", playerName);
				
			}
			
			
			GUILayout.Space(5);
			
			if(GUILayout.Button("Annuler", GUILayout.Height(25)))
			{
				iWantToConnectToAServer = false;
			}
		}
	}
	
	
	void ServerDisconnectWindow(int windowID)
	{
		GUILayout.Label("Server name: " + serverName);
		GUILayout.Label("Number of players connected: " + Network.connections.Length);
		
		if(Network.connections.Length >= 1)
		{
			GUILayout.Label("Ping: " + Network.GetAveragePing(Network.connections[0]));	
		}
		
		if(GUILayout.Button("Shutdown server"))
		{
			Network.Disconnect();	
		}
	}
	
	
	
	void ClientDisconnectWindow(int windowID)
	{
		GUILayout.Label("Connected to server: " + serverName);	
		GUILayout.Label("Ping; " + Network.GetAveragePing(Network.connections[0]));
		GUILayout.Space(7);

		if(GUILayout.Button("Disconnect", GUILayout.Height(25)))
		{
			Network.Disconnect();	
		}
		
		GUILayout.Space(5);
	}
	
	
	//Les joueurs y choisissent leurs pays et règles les paramètres de la partie
	void FenetreDeMiseEnPlace(int windowID){
		
		GUILayout.Label("Mise en place");
		
		if (Network.peerType == NetworkPeerType.Server) //Ce bouton n'est disponible que pour le créateur de la partie
		{
			if(GUILayout.Button("Demarrer la partie", GUILayout.Height(30)))
			{

				
				networkView.RPC("lancerLaPartie" , RPCMode.AllBuffered);	
				mondeInstance = (GameObject) Network.Instantiate(monde, transform.position, transform.rotation, 0);
				networkView.RPC("setupCamera" , RPCMode.AllBuffered);	
				//networkView.RPC("SetupTheWorld" , RPCMode.AllBuffered);	
			}
		}
	}
	
	
	/* La gestion de la déconnection des joueurs est à réfléchir…*/
	void OnDisconnectedFromServer()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
	
	
	void OnPlayerDisconnected(NetworkPlayer networkPlayer)
	{
		Network.RemoveRPCs(networkPlayer);	
		Network.DestroyPlayerObjects(networkPlayer);	
	}
	
	
	void OnPlayerConnected(NetworkPlayer networkPlayer)
	{
		networkView.RPC("TellPlayerServerName", networkPlayer, serverName);	
		networkView.RPC("TellEveryoneWinningCriteria", networkPlayer, winningScore);
		Debug.Log ("Un mec se connecte!");
	}
	
	
	
	void OnGUI()
	{
		//If the player is disconnected then run the ConnectWindow function.
		
		if(afficherFenetreDeMiseEnPlace == true) {
			
			Rect windowRect = new Rect (20, 20, 120, 50);
			Debug.Log("Player ID is " + Network.player.ToString());

			fenetreDeMiseEnPlace = GUILayout.Window(5, windowRect, FenetreDeMiseEnPlace, "Mise en place");
		}
		else
		{
			if(Network.peerType == NetworkPeerType.Disconnected)
			{
			
				leftIndent = Screen.width / 2 - connectionWindowWidth / 2;				
				topIndent = Screen.height / 2 - connectionWindowHeight / 2;
				
				connectionWindowRect = new Rect(leftIndent, topIndent, connectionWindowWidth,
				                                connectionWindowHeight);
				
				connectionWindowRect = GUILayout.Window(0, connectionWindowRect, ConnectWindow,
				                                        titleMessage);
			}
			
			
			//If the game is running as a server then run the ServerDisconnectWindow
			//function.
			
			if(Network.peerType == NetworkPeerType.Server)
			{	
			
			//If the connection type is a client (a player) then show a window that allows
			//them to disconnect from the server.
			
			if(Network.peerType == NetworkPeerType.Client && showDisconnectWindow == true)
			{
				clientDisWindowRect = new Rect(Screen.width / 2 - clientDisWindowWidth / 2,
				                               Screen.height / 2 - clientDisWIndowHeight / 2,
				                               clientDisWindowWidth, clientDisWIndowHeight);
				
				clientDisWindowRect = GUILayout.Window(1, clientDisWindowRect, ClientDisconnectWindow, "");
			}
		}
		}
	}

		
		
			
	
	
	
	//Used to tell the MultiplayerScript in connected players the serverName. Otherwise
	//players connecting wouldn't be able to see the name of the server.
	
	[RPC]
	void TellPlayerServerName (string servername)
	{
		Debug.Log ("Serveur name :" + servername);
		serverName = servername;	
	}
	
	
	//This RPC is sent to all players from the server to tell them of the new winning
	//score criteria.
	
	[RPC]
	void TellEveryoneWinningCriteria (int winScore)
	{
	//	GameObject gameManager = GameObject.Find("GameManager");
		
	//	ScoreTable scoreScript = gameManager.GetComponent<ScoreTable>();
		
	//	scoreScript.winningScore = winScore;
	}
	
	[RPC]
	void lancerLaPartie(){
		

		int joueursConnectes = Network.connections.Length + 1;
		
		Debug.Log ("PARTIE LANCEE! avec :" + joueursConnectes + " joueurs");
		
		//Creation des pays
		Pays[] p = new Pays[Network.connections.Length +1];
		for (int i = 0 ; i < Network.connections.Length + 1 ; i++) {
			p[i] = new Pays(i);
			p[i].initPays();
		}
		Pays.allPays = p;
		
		Joueur[] joueurs = new Joueur[joueursConnectes]; 	
		for (int i = 0 ; i < joueursConnectes ; i++) {
			joueurs[i] = new Joueur();
		}
		Partie.setJoueurs(joueurs);
		Partie.myPlayerID = int.Parse(Network.player.ToString());
		Partie.monPays = p[Partie.myPlayerID];

		Debug.Log ("Player ID enregistré :" + Partie.myPlayerID);

		afficherFenetreDeMiseEnPlace = false;


		
		//Mise en place de l'interface
		
		//Mise en place des decks
		Deck[] d = new Deck[Deck.nomDesDecks.Length];
		for (int i = 0 ; i < Deck.nomDesDecks.Length ; i++) {
			Debug.Log ("For" +i);
			d[i] = new Deck(i);
			d[i].composerDeck(Partie.monPays);
			GameObject objDeck = (GameObject) Instantiate(deck , Vector3.zero , Quaternion.identity);
			objDeck.transform.Rotate(270,0,0);
			objDeck.transform.localPosition = new Vector3 (i*2,4,10);
			objDeck.transform.parent = Camera.main.transform;
			ScriptDeck sd = (ScriptDeck) (objDeck.GetComponent("ScriptDeck"));
			sd.deck = d[i];
			TextMesh tm = sd.titre.GetComponent<TextMesh>();
			tm.text = Deck.nomDesDecks[d[i].getTypeDeDeck()];
		}
		Deck.mesDecks = d;
		
		//Mise en place des jauges
		GameObject[] mesJauges = new GameObject[10];
		foreach (Jauge e in (Jauge[]) Enum.GetValues(typeof(Jauge))) {

				GameObject j = (GameObject) Instantiate(jauge , Vector3.zero , Quaternion.identity);
				Vector3 tailleJ = j.collider.bounds.size;

				j.transform.parent = Camera.main.transform;
				j.transform.localPosition = new Vector3 (-5,4 - (tailleJ.x * 2.4f * (int)e),10);
				//j.transform.localScale.Scale(new Vector3(0.1f , 0.1f , 0.1f));
				j.transform.localRotation = Quaternion.identity;
				j.transform.Rotate(0,180,90);
				ScriptJauge sj = (ScriptJauge) (j.GetComponent("ScriptJauge"));
				sj.progression.renderer.material = MultiplayerScript.multi.materiauxJauges[(int)e];
				sj.setMainJauge(true);
				sj.paysAssocie = Partie.monPays;
				sj.typeDeJauge = e;
		}
		Partie.mesJauges = mesJauges;
		
		Partie.cartesEnMain = new ArrayList();
		
	}
	
	[RPC]
	void setupCamera () {
		((CameraScript) (cam.GetComponent("CameraScript"))).world = GameObject.FindWithTag("Monde");
	}
	
	//RPC qui modifie une jauge d'un pays
	[RPC]
	void changeJauge(int pays , int jauge , float v) {
		Pays.allPays[pays].getJauges()[jauge] += v;
	}
	
	
}