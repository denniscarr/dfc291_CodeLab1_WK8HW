using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RW_ConstantStep : RandomWalker {

    public override Vector3 Step(Vector3 input)
    {
        input += new Vector3(
                stepSize * Random.Range(-1, 2),
                stepSize * Random.Range(-1, 2),
                stepSize * Random.Range(-1, 2)
            );

        return base.Step(input);
    }
}
