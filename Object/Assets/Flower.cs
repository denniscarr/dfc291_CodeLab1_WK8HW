using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour {

    [SerializeField] float shotFrequency = 0.5f;
    [SerializeField] float timeSinceLastShot = 0.0f;

    [SerializeField] GameObject bullet;

	void Start ()
    {
        // Get a random color.
        GetComponent<SpriteRenderer>().color = Random.ColorHSV(0, 1, 0.5f, 1, 1, 1);
	}
	
	void Update ()
    {
        // Run timer to check if time for shot
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot > shotFrequency)
        {
            Shoot();

            timeSinceLastShot = 0;
        }
	}

    void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
