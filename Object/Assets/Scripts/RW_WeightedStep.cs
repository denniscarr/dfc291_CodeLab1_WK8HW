using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RW_WeightedStep : RandomWalker {

    [SerializeField] private int moveUpPriority = 1;
    [SerializeField] private int moveDownPriority = 1;
    [SerializeField] private int moveLeftPriority = 1;
    [SerializeField] private int moveRightPriority = 1;
    [SerializeField] private int moveForwardPriority = 1;
    [SerializeField] private int moveBackwardPriority = 1;

    private List<Vector3> potentialMoves = new List<Vector3>();


    public override Vector3 Step(Vector3 input)
    {
        BuildPotentialMoveList();

        input += (potentialMoves[Random.Range(0, potentialMoves.Count)] * stepSize);

        return base.Step(input);
    }


    private void BuildPotentialMoveList()
    {
        potentialMoves.Clear();

        // Add move up options.
        for (int i = 0; i < moveUpPriority; i++)
        {
            potentialMoves.Add(Vector3.up);
        }

        // Add move down options.
        for (int i = 0; i < moveDownPriority; i++)
        {
            potentialMoves.Add(-Vector3.up);
        }

        // Add move left options.
        for (int i = 0; i < moveLeftPriority; i++)
        {
            potentialMoves.Add(-Vector3.right);
        }

        // Add move right options.
        for (int i = 0; i < moveRightPriority; i++)
        {
            potentialMoves.Add(Vector3.right);
        }

        // Add move forward options.
        for (int i = 0; i < moveForwardPriority; i++)
        {
            potentialMoves.Add(Vector3.forward);
        }

        // Add move backward options.
        for (int i = 0; i < moveBackwardPriority; i++)
        {
            potentialMoves.Add(-Vector3.forward);
        }
    }
}
