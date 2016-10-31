using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

    public short speed;

	// Use this for initialization
	void Start () {
	    //pick a random powerup

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.velocity = collision.rigidbody.velocity * speed;
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider collision)
    {
        collision.GetComponent<Rigidbody>().velocity = collision.GetComponent<Rigidbody>().velocity * speed;
        Destroy(this.gameObject);
    }
}
