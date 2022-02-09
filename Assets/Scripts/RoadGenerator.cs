using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{

    public GameObject roadPrefab;
    public Vector3 lastPos;

    public float offset = 0.7071068f;

    private int roadCount = 0;



    public void StartBuilding()
    {
        InvokeRepeating("CreateNewRoadPart", 0f, 0.2f);
    }

    public void CreateNewRoadPart()
    {
        Vector3 spawnPos = Vector3.zero;

        float chance = Random.Range(0, 100);
        if (chance < 50)
        {
            spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
        }

        else
        {
            spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);
        }

        GameObject newRoad = Instantiate(roadPrefab, spawnPos, Quaternion.Euler(0, 45, 0));

        lastPos = newRoad.transform.position;
        roadCount++;

        if (roadCount % 5 == 0)
        {
            newRoad.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

}
