using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralMapGeneration : MonoBehaviour
{
    // Config
    [SerializeField] GameObject[] maps;
    [SerializeField] BoxCollider2D limitCollider;

    // Initialize Variables
    Vector2 rightSide = new Vector2(1, 0);
    Vector2 leftSide = new Vector2(-1, 0);
    Vector2 upSide = new Vector2(0, 1);
    Vector2 downSide = new Vector2(0, -1);
    GameObject mapCloneCorners;

    // Public Variables
    public GameObject mapsParent;
    public int mapXSize;
    public int mapYSize;
    public Vector3 currentStandingMap;

    // Start is called before the first frame update
    void Start()
    {
        mapsParent = new GameObject("mapsParent");
        currentStandingMap = transform.position;

        rightSide = new Vector2(1, 0)* mapXSize;
        leftSide = new Vector2(-1, 0) * mapXSize;
        upSide = new Vector2(0, 1) * mapYSize;
        downSide = new Vector2(0, -1) * mapYSize;

        CreateInitialMap();
    }

    private void CreateInitialMap()
    {
        Vector2[] sides = { rightSide, leftSide, upSide, downSide };
        foreach(Vector2 side in sides)
        {
            GameObject mapClone = Instantiate(maps[Random.Range(0, maps.Length)], (Vector3)side, Quaternion.identity);
            mapClone.transform.parent = mapsParent.transform;
        }

        mapCloneCorners = Instantiate(maps[Random.Range(0, maps.Length)], (Vector3)rightSide + (Vector3)upSide, Quaternion.identity);
        mapCloneCorners.transform.parent = mapsParent.transform;
        mapCloneCorners = Instantiate(maps[Random.Range(0, maps.Length)], (Vector3)rightSide + (Vector3)downSide, Quaternion.identity);
        mapCloneCorners.transform.parent = mapsParent.transform;
        mapCloneCorners = Instantiate(maps[Random.Range(0, maps.Length)], (Vector3)leftSide + (Vector3)upSide, Quaternion.identity);
        mapCloneCorners.transform.parent = mapsParent.transform;
        mapCloneCorners = Instantiate(maps[Random.Range(0, maps.Length)], (Vector3)leftSide + (Vector3)downSide, Quaternion.identity);
        mapCloneCorners.transform.parent = mapsParent.transform;
    }

    public void GenerateUpMap()
    {
        if (Mathf.Abs((currentStandingMap + (Vector3)upSide).y) < limitCollider.size.y-18)
        {
            GameObject mapClone = Instantiate(maps[Random.Range(0, maps.Length)], currentStandingMap + (Vector3)upSide, Quaternion.identity);
            mapClone.transform.parent = mapsParent.transform;
        }
    }

    public void GenerateDownMap()
    {
        if (Mathf.Abs((currentStandingMap + (Vector3)downSide).y) < limitCollider.size.y-18)
        {
            GameObject mapClone = Instantiate(maps[Random.Range(0, maps.Length)], currentStandingMap + (Vector3)downSide, Quaternion.identity);
            mapClone.transform.parent = mapsParent.transform;
        }
    }

    public void GenerateLeftMap()
    {
        if (Mathf.Abs((currentStandingMap + (Vector3)leftSide).x) < limitCollider.size.x-23)
        {
            GameObject mapClone = Instantiate(maps[Random.Range(0, maps.Length)], currentStandingMap + (Vector3)leftSide, Quaternion.identity);
            mapClone.transform.parent = mapsParent.transform;
        }
    }

    public void GenerateRightMap()
    {
        if (Mathf.Abs((currentStandingMap + (Vector3)rightSide).x) < limitCollider.size.x-23)
        {
            GameObject mapClone = Instantiate(maps[Random.Range(0, maps.Length)], currentStandingMap + (Vector3)rightSide, Quaternion.identity);
            mapClone.transform.parent = mapsParent.transform;
        }
    }
}
