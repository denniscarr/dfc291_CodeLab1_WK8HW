using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RandomWalker : MonoBehaviour {

    public float stepSize = 0.1f;
    public float stepFrequency = 0.1f;

    float timeSinceLastStep = 0.0f;

    [SerializeField] bool is2D = false;

    [HideInInspector] public Vector3 walkerPosition;


    public void Walk()
    {
        // See if it's time to step.
        if (timeSinceLastStep < stepFrequency)
        {
            timeSinceLastStep += Time.deltaTime;
        }

        // Step.
        if (timeSinceLastStep >= stepFrequency)
        {
            walkerPosition = Step(walkerPosition);

            timeSinceLastStep = 0;
        }
    }


	public virtual Vector3 Step(Vector3 input)
    {
        if (is2D)
        {
            input.z = 0f;
        }

        return input;
    }
}
