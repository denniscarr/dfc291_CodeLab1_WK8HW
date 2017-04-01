using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RandomWalker {

    public enum StepType {Constant, Variable, Weighted};
    public StepType stepType = StepType.Constant;

    public float stepSize = 0.1f;
    public float stepFrequency = 0.1f;

    //public bool twoDimensional = false;

    float timeSinceLastStep = 0.0f;

    [HideInInspector] public Vector3 walkerPosition;


    public RandomWalker(Vector3 _currentPosition)
    {
        walkerPosition = _currentPosition;
    }


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


	Vector3 Step(Vector3 originalVector)
    {
        Vector3 newVector = originalVector;

        if (stepType == StepType.Constant)
        {
            newVector += new Vector3(
                    stepSize * UnityEngine.Random.Range(-1, 2),
                    stepSize * UnityEngine.Random.Range(-1, 2),
                    stepSize * UnityEngine.Random.Range(-1, 2)
                );
        }

        else if (stepType == StepType.Variable)
        {
            newVector += new Vector3(
                    UnityEngine.Random.Range(-stepSize, stepSize),
                    UnityEngine.Random.Range(-stepSize, stepSize),
                    UnityEngine.Random.Range(-stepSize, stepSize)
                );
        }

        return newVector;
    }

    //Vector2 Step(Vector2 originalPosition)
    //{
    //    return new Vector2(Step(originalPosition).x, Step(originalPosition).y);
    //}
}
