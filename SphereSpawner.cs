using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
   public GameObject spherePrefab;

    private void Start()
    {
        // Spawn 20 spheres
        for (int i = 0; i < 20; i++)
        {   
            Debug.Log("Aphere Spawned");
            Vector3 spawnPosition = new Vector3(Random.Range(1929f, -2071f), Random.Range(0f, 700f), Random.Range(1962f, -2038f));
            Instantiate(spherePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
