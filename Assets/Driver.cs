using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 250f;
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] float slowSpeed = 8f;
    [SerializeField] float boostSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        float steerAmount = -steerSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float moveAmount = moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Rotate(0,0,steerAmount);
        transform.Translate(0,moveAmount,0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Driver.OnTriggerEnter2D: {other.gameObject.name}");

        if (other.tag == "Boost") {
            moveSpeed = boostSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log($"Driver.OnCollisionEnter2D: {other.gameObject.name}");
        moveSpeed = slowSpeed;
    }
}
