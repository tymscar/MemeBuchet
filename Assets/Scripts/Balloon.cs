using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {

    public GameObject spawnzone;
    public GameObject powerup;
	// Use this for initialization
	void Start () {
        Instantiate(powerup,spawnzone.transform.position, spawnzone.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	    //move up and down
        
        //spawn random powerup

	}
}
