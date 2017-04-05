using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (RandomWalker))]
public class LineEnemy : MonoBehaviour {

    private Vector3 previousPosition;

    [SerializeField] private GameObject segment;
    private RandomWalker walker;


	void Start ()
    {
        walker = GetComponent<RandomWalker>();
        walker.walkerPosition = transform.position;
	}
	

	void Update ()
    {
        walker.Walk();

        if (walker.walkerPosition != transform.position)
        {
            transform.position = walker.walkerPosition;
            SpawnNewSegment(previousPosition, transform.position);
        }

        previousPosition = transform.position;
	}


    void SpawnNewSegment(Vector3 position1, Vector3 position2)
    {
        Vector3 segmentPosition = position1 + (position1 - position2) * 0.5f;
        float segmentLength = Vector3.Distance(position1, position2);
        Quaternion segmentRotation = Quaternion.LookRotation(position1 - position2, Vector3.forward);
        segmentRotation.x = 0;
        segmentRotation.y = 0;

        GameObject newSegment = Instantiate(segment);

        newSegment.transform.position = segmentPosition;
        newSegment.GetComponent<Vibrator>().originalScale = new Vector3(newSegment.transform.localScale.x, segmentLength, newSegment.transform.localScale.z);
        newSegment.transform.localScale = new Vector3(newSegment.transform.localScale.x, segmentLength, newSegment.transform.localScale.z);
        newSegment.transform.rotation = segmentRotation;
    }
}
