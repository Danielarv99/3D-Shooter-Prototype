using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   private Rigidbody bulletRb;
    private float bulletSpeed = 40;
    private float xMax = 85;
    private float zMax = 85;
    public Enemy enemy;


    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime, Space.Self);
        enemy = GetComponent<Enemy>();
        OutOfBound();
    }

    void OutOfBound()
    {
        if (transform.position.x > xMax || transform.position.x < -xMax)
        {
            Destroy(gameObject);

        } else if (transform.position.z > zMax || transform.position.z < -zMax){
            Destroy(gameObject);

        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log ("asd");
            Destroy(gameObject);

        }
    }
}

