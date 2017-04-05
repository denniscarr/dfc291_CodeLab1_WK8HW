using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RW_VariableStep : RandomWalker {

    public override Vector3 Step(Vector3 input)
    {
        input += new Vector3(
                Random.Range(-stepSize, stepSize),
                Random.Range(-stepSize, stepSize),
                Random.Range(-stepSize, stepSize)
            );

        return base.Step(input);
    }
}
