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
    float trashSpawnTimeMax = 3f;
    float carSpawnTimeMax = 7f;
    float trashSpawnTime = 0f;
    float carSpawnTime = 0f;
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
        SpawnTrash();
        SpawnCar();
    }

    void SpawnTrash()
    {
        if (trashCollection.Count > 0 && trashSpawnTime > trashSpawnTimeMax)
        {
            GameObject currentTrash = trashCollection.Dequeue();
            currentTrash.transform.position = trashSpawnPts[Random.Range(0, trashSpawnPts.Count)].position;
            currentTrash.SetActive(true);
            currentTrash.GetComponent<Rigidbody>().AddForce(transform.forward * trashSpd * Time.fixedDeltaTime, ForceMode.Impulse);
            trashSpawnTime = 0f;
        }
        else
        {
            trashSpawnTime += Time.fixedDeltaTime;
        }
    }

    void SpawnCar()
    {
        if (carCollection.Count > 0 && carSpawnTime > carSpawnTimeMax) //note: mb make it so 2 cars can't spawn in same lane? Or higher time lim or lower spawn lim
        {
            GameObject currentCar = carCollection.Dequeue();
            currentCar.transform.position = carSpawnPts[Random.Range(0, carSpawnPts.Count)].position;
            currentCar.SetActive(true);
            currentCar.GetComponent<EnemyCar>().movingForward = true;
            carSpawnTime = 0f;
        }
        else
        {
            carSpawnTime += Time.fixedDeltaTime;
        }
    }

    void ReAddTrash(GameObject trash)
    {
        trashCollection.Enqueue(trash);
    }
    void ReAddCar(GameObject trash)
    {
        carCollection.Enqueue(trash);
    }
}
