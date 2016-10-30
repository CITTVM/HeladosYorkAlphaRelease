using UnityEngine;
using System.Collections;
using System;

public class Player : Character {


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override IEnumerator TakeDamage()
    {
        yield return null;
    }
}
