using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;


public class Truck : MonoBehaviour
{
    public List<GameObject> spawnPts;
    public GameObject trashPrefab;
    int spawnInt = 0; //temp var, figure out how to use clock later
    public int spawnIntLim;

    void Update()
    {
        if (spawnInt == spawnIntLim)
        {
            Instantiate(trashPrefab, spawnPts[Random.Range(0, spawnPts.Count)].transform.position, Quaternion.identity);
            spawnInt = 0;
        }
        spawnInt++;
    }
}
