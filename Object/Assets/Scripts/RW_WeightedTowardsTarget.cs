using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RW_WeightedTowardsTarget : RandomWalker {

    [SerializeField] private Transform target;
    [SerializeField] private float chanceToApproachTarget = 0.75f;

    private RW_VariableStep randomWalker;

    void Start()
    {
        randomWalker = gameObject.AddComponent<RW_VariableStep>();
        randomWalker.walkerPosition = transform.localPosition;
        randomWalker.stepSize = stepSize;
    }

    public override Vector3 Step(Vector3 input)
    {
        if (Random.value <= chanceToApproachTarget)
        {
            Vector3 towardsTarget = target.position - transform.position;
            input += towardsTarget.normalized * stepSize;
        }

        else
        {
            input = randomWalker.Step(input);
        }

        return base.Step(input);
    }
}
