using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float forceAmount = 75.0f;
void Start()
{
    // Generate a random position within a range
    Vector3 spawnPosition = new Vector3(Random.Range(1929f, -2071f), Random.Range(500f, 700f), Random.Range(1962f, -2038f));

    // Instantiate the object at the random position

    GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    Debug.Log("Flight is up and Flying");
    // Get a reference to the spawned object's rigidbody component
    Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
    // Generate a random direction for the force
    Vector3 forceDirection = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
    // Apply the force to the spawned object's rigidbody component
    rb.AddForce(forceDirection * forceAmount, ForceMode.Impulse);
}

}

