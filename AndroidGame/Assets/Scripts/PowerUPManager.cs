using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUPManager : MonoBehaviour
{

    public GameObject[] PUPrefabs;

    private Transform playerTransform;

    private float spawnZ = 0.0f;

    private float PULength = 10.0f;

    private int amnPUOnScreen = 4;

    private float safeZone = 15.0f;

    private int lastPrefabIndex = 0;

    private List<GameObject> activePUs = new List<GameObject>();

    // Use this for initialization
    void Start()
    {

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amnPUOnScreen; i++)
        {

            if (i < 2)
                SpawnPU(0);

            else

                SpawnPU();

        }


    }

    // Update is called once per frame
    void Update()
    {

        if (playerTransform.position.z - safeZone > (spawnZ - amnPUOnScreen * PULength))
        {

            SpawnPU();
            DeletePU();

        }

    }

    private void SpawnPU(int prefabIndex = -1)
    {

        GameObject go;

        if (prefabIndex == -1)

            go = Instantiate(PUPrefabs[RandomPrefabIndex()]) as GameObject;

        else
            go = Instantiate(PUPrefabs[prefabIndex]) as GameObject;

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;

        spawnZ += PULength;

        activePUs.Add(go);

    }


    private void DeletePU()

    {
        Destroy(activePUs[0]);

        activePUs.RemoveAt(0);


    }

    private int RandomPrefabIndex()
    {


        if (PUPrefabs.Length <= 1)
        {
            return 0;
        }
        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, PUPrefabs.Length);

        }

        lastPrefabIndex = randomIndex;
        return randomIndex;

    }
}
