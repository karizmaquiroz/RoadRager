using UnityEngine;
using System.Collections.Generic;


public class Truck : MonoBehaviour
{
    public List<Transform> trashSpawnPts;
    public List<Transform> carSpawnPts;
    public GameObject trashPrefab;
    public GameObject carPrefab;
    Queue<GameObject> trashCollection = new Queue<GameObject>();
    Queue<GameObject> carCollection = new Queue<GameObject>();
    int spawnInt = 0; //temp var, figure out how to use clock later
    int spawnIntLim = 100;
    int maxTrash = 5;
    int maxCars = 3;
    float trashSpd = 300f;

    void Start()
    {
        for (int i = 0; i < maxTrash; i++)
        {
            trashCollection.Enqueue(Instantiate(trashPrefab, trashSpawnPts[Random.Range(0, trashSpawnPts.Count)].position, Quaternion.identity));
        }
        for (int i = 0; i < maxCars; i++)
        {
            carCollection.Enqueue(Instantiate(carPrefab, carSpawnPts[Random.Range(0, carSpawnPts.Count)].position, Quaternion.identity));
        }
    }

    void FixedUpdate()
    {
        if (spawnInt >= spawnIntLim)
        {
            SpawnTrash();
            SpawnCar(); //putting in same counter fn
            spawnInt = 0;
        }
        spawnInt++;
    }

    void SpawnTrash()
    {
        if (trashCollection.Count > 0)
        {
            GameObject currentTrash = trashCollection.Dequeue();
            currentTrash.transform.position = trashSpawnPts[Random.Range(0, trashSpawnPts.Count)].position;
            currentTrash.SetActive(true);
            currentTrash.GetComponent<Rigidbody>().AddForce(transform.forward * trashSpd * Time.fixedDeltaTime, ForceMode.Impulse);
        }
    }

    void SpawnCar()
    {
        if (carCollection.Count > 0)
        {
            GameObject currentCar = carCollection.Dequeue();
            currentCar.transform.position = carSpawnPts[Random.Range(0, carSpawnPts.Count)].position;
            currentCar.SetActive(true);
            currentCar.GetComponent<Rigidbody>().AddForce(transform.forward * trashSpd * Time.fixedDeltaTime, ForceMode.Impulse);
        }
    }

    void ReAddTrash(GameObject trash)
    {
        trashCollection.Enqueue(trash);
    }
}
