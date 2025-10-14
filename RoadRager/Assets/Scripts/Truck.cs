using UnityEngine;
using System.Collections.Generic;


public class Truck : MonoBehaviour
{
    public List<Transform> spawnPts;
    public GameObject trashPrefab;
    Queue<GameObject> trashCollection = new Queue<GameObject>();
    int spawnInt = 0; //temp var, figure out how to use clock later
    public int spawnIntLim;
    public int maxTrash;
    public float trashSpd;

    void Start()
    {
        for (int i = 0; i < maxTrash; i++)
        {
            trashCollection.Enqueue(Instantiate(trashPrefab, spawnPts[Random.Range(0, spawnPts.Count)].position, Quaternion.identity));
        }
    }

    void FixedUpdate()
    {
        if (spawnInt >= spawnIntLim && trashCollection.Count > 0)
        {
            GameObject currentTrash = trashCollection.Dequeue();
            currentTrash.transform.position = spawnPts[Random.Range(0, spawnPts.Count)].position;
            currentTrash.SetActive(true);
            currentTrash.GetComponent<Rigidbody>().AddForce(transform.forward * trashSpd * Time.fixedDeltaTime, ForceMode.Impulse);
            spawnInt = 0;
        }
        spawnInt++;
    }

    void ReAddTrash(GameObject trash)
    {
        trashCollection.Enqueue(trash);
    }
}
