using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffect : MonoBehaviour {

    public ParticleSystem explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            Destroy(this.gameObject); //bullet
            Instantiate(explosion, transform.position, Quaternion.identity);
        }

    }
}
