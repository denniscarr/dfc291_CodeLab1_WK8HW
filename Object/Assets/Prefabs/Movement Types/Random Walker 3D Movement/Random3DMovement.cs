using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random3DMovement : MonoBehaviour {

    [SerializeField] private RandomWalker randomWalker;

    [SerializeField] bool applyToRigidbody;

    private void Start()
    {
        randomWalker.walkerPosition = transform.parent.position;
    }


	void Update ()
    {
        randomWalker.Walk();

        // See if our walker has moved.
        if (randomWalker.walkerPosition != transform.parent.localPosition)
        {
            transform.parent.localPosition = randomWalker.walkerPosition;
        }
	}
}
