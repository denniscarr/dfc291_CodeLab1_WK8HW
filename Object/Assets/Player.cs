using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private float movementSpeed = 1f;

    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        // MOVEMENT //
        Vector2 newPosition = transform.position;
        newPosition.x += Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime;
        newPosition.y += Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime;

        transform.position = newPosition;
    }
}
