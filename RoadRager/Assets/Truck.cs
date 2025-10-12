using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;


public class Truck : MonoBehaviour
{
    public List<GameObject> spawnPts;
    public GameObject trashPrefab;
    Queue<GameObject> trashCollection;
    int spawnInt = 0; //temp var, figure out how to use clock later
    public int spawnIntLim;
    bool setup = true;

    void Update()
    {
        if (setup)
        {
            for (int i = 0; i < 5; i++) //getting a null reference error
            {
                trashCollection.Enqueue(Instantiate(trashPrefab, spawnPts[Random.Range(0, spawnPts.Count)].transform.position, Quaternion.identity));
            }
            setup = false;
        }
        if (spawnInt == spawnIntLim)
        {
            GameObject currentTrash = trashCollection.Dequeue();
            currentTrash.GetComponent<MeshRenderer>().enabled = true;
            currentTrash.GetComponent<TrashScript>().Move();
            trashCollection.Enqueue(currentTrash);
            spawnInt = 0;
        }
        spawnInt++;
    }
}
