using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrator : MonoBehaviour {

    private float noiseTime = 0.0f;
    [SerializeField] private float noiseScale = 0.5f;
    [SerializeField] private float noiseSpeed = 0.5f;

    public Vector3 originalScale;


    private void Start()
    {
        if (originalScale == Vector3.zero) originalScale = transform.localScale;
    }


    void Update ()
    {
        transform.localScale = new Vector3(
            originalScale.x + MyMath.Map(Mathf.PerlinNoise(noiseTime, 0), 0, 1, -noiseScale, noiseScale),
            originalScale.y + MyMath.Map(Mathf.PerlinNoise(0, noiseTime), 0, 1, -noiseScale, noiseScale),
            originalScale.z
        );

        noiseTime += noiseSpeed;
    }
}
