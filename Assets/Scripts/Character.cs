using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {

public Animator MyAnimation { get; private set; }

    [SerializeField]
    private float movementSpeed;



	// Use this for initialization
	public virtual void Start () {
        MyAnimation = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
	
	}

    public abstract IEnumerator TakeDamage();
}
