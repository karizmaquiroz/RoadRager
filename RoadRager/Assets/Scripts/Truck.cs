using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;


public class Truck : MonoBehaviour
{
    public List<GameObject> spawnPts;
    public GameObject trashPrefab;
    int spawnInt = 0; //temp var, figure out how to use clock later

    void Update()
    {
        if (spawnInt == 900)
        {
            Debug.Log("spawn trash");
            Instantiate(trashPrefab, spawnPts[Random.Range(0, spawnPts.Count)].transform.position, Quaternion.identity);
            spawnInt = 0;
        }
        spawnInt++;
    }
}
