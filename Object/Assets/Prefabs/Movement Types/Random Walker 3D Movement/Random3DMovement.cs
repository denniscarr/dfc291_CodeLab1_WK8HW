using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (RandomWalker))]
public class Random3DMovement : MonoBehaviour {

    RandomWalker randomWalker;

    [SerializeField] bool applyToRigidbody;

    private void Start()
    {
        randomWalker = GetComponent<RandomWalker>();
        randomWalker.walkerPosition = transform.parent.position;
    }


	void Update ()
    {
        randomWalker.Walk();

        // See if our walker has moved.
        if (randomWalker.walkerPosition != transform.parent.localPosition)
        {
            if (applyToRigidbody) GetComponent<Rigidbody>().MovePosition(randomWalker.walkerPosition);
            else transform.parent.localPosition = randomWalker.walkerPosition;
        }
	}
}
