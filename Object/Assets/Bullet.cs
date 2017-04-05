using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] private Transform target;
    private Vector2 direction;
    [SerializeField] float forwardSpeed = 1f;
    [SerializeField] float turnSpeed = 1f;
    [SerializeField] float maxSpeed = 4;

    Rigidbody2D rb;


    private void Start ()
    {
        rb = GetComponent<Rigidbody2D>();

        // Get a random direction.
        direction = Random.insideUnitCircle;
        rb.velocity = direction * forwardSpeed;
	}

	
	private void Update ()
    {
        // Get nearest enemy and set it as my target.
        if (target == null)
        {
            Vector3 nearestPos = Vector3.zero;
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (nearestPos == Vector3.zero || Vector3.Distance(transform.position, nearestPos) > Vector3.Distance(transform.position, go.transform.position))
                {
                    target = go.transform;
                    nearestPos = go.transform.position;
                }
            }
        }

        // Gradually accelerate towards target.
        Vector2 acceleration = (target.position - transform.position) * turnSpeed * Time.deltaTime;
        rb.velocity += acceleration;
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
