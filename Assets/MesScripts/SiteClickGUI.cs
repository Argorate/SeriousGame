using UnityEngine;
using System.Collections;

public class SiteClickGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown () {
		networkView.RPC ("GrandirDemesurement", RPCMode.All);
	}
	
	[RPC]
	void GrandirDemesurement(){
		transform.localScale = new Vector3(100,100,100);
	}
}
