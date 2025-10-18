using UnityEngine;
using System.Collections.Generic;


public class Truck : MonoBehaviour
{
    public List<Transform> trashSpawnPts;
    public GameObject trashPrefab;
    public GameObject carPrefab = null;
    Queue<GameObject> trashCollection = new Queue<GameObject>();
    Queue<GameObject> carCollection = new Queue<GameObject>();
    int spawnInt = 0; //temp var, figure out how to use clock later
    public int spawnIntLim;
    public int maxTrash;
    public int maxCars;
    public float trashSpd;

    void Start()
    {
        for (int i = 0; i < maxTrash; i++)
        {
            trashCollection.Enqueue(Instantiate(trashPrefab, trashSpawnPts[Random.Range(0, trashSpawnPts.Count)].position, Quaternion.identity));
        }
        for (int i = 0; i < maxCars; i++)
        {
            carCollection.Enqueue(Instantiate(carPrefab, trashSpawnPts[Random.Range(0, trashSpawnPts.Count)].position, Quaternion.identity));
        }
    }

    void FixedUpdate()
    {
        if (spawnInt >= spawnIntLim && trashCollection.Count > 0)
        {
            SpawnTrash();
            SpawnCar(); //putting in same counter fn
            spawnInt = 0;
        }
        spawnInt++;
    }

    void SpawnTrash()
    {
        GameObject currentTrash = trashCollection.Dequeue();
        currentTrash.transform.position = trashSpawnPts[Random.Range(0, trashSpawnPts.Count)].position;
        currentTrash.SetActive(true);
        currentTrash.GetComponent<Rigidbody>().AddForce(transform.forward * trashSpd * Time.fixedDeltaTime, ForceMode.Impulse);
    }

    void SpawnCar()
    {
        GameObject currentCar = carCollection.Dequeue();
        currentCar.transform.position = trashSpawnPts[Random.Range(0, trashSpawnPts.Count)].position;
        currentCar.SetActive(true);
        currentCar.GetComponent<Rigidbody>().AddForce(transform.forward * trashSpd * Time.fixedDeltaTime, ForceMode.Impulse);
    }

    void ReAddTrash(GameObject trash)
    {
        trashCollection.Enqueue(trash);
    }
}
