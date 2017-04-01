using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RandomWalker))]
public class RandomWalkerEditor : Editor {
	
    public override void OnInspectorGUI ()
    {
        var myScript = target;


	}
}
