using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralMapUpBorder : MonoBehaviour
{
    // Initialize Variables
    ProceduralMapGeneration mapGen;
    GameObject mapReference;
    Vector2 rightSide = new Vector2(1, 0);
    Vector2 leftSide = new Vector2(-1, 0);
    Vector2 downSide = new Vector2(0, -1);
    //Vector2 upSide = new Vector2(0, 1);
    RaycastHit2D hit;

    private void Start()
    {
        mapGen = FindObjectOfType<ProceduralMapGeneration>();
        mapReference = this.transform.parent.GetChild(8).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mapGen.currentStandingMap = transform.parent.position;
            mapReference.SetActive(false);

            // Right Side
            hit = Physics2D.Raycast(mapGen.currentStandingMap, rightSide, mapGen.mapXSize);
            if (hit.transform == null)
            {
                mapGen.GenerateRightMap();
            }

            // Left Side
            hit = Physics2D.Raycast(mapGen.currentStandingMap, leftSide, mapGen.mapXSize);
            if (hit.transform == null)
            {
                mapGen.GenerateLeftMap();
            }

            // Down Side
            hit = Physics2D.Raycast(mapGen.currentStandingMap, downSide, mapGen.mapYSize);
            if (hit.transform == null)
            {
                mapGen.GenerateDownMap();
            }

            hit = Physics2D.Raycast(mapGen.currentStandingMap, downSide, mapGen.mapYSize);
            mapGen.currentStandingMap = hit.transform.position;

            // Right Down Side
            hit = Physics2D.Raycast(mapGen.currentStandingMap + new Vector3(1,0,0), rightSide, mapGen.mapXSize - 1);
            if (hit.transform == null)
            {
                mapGen.GenerateRightMap();
            }

            // Left Down Side
            hit = Physics2D.Raycast(mapGen.currentStandingMap - new Vector3(1, 0, 0), leftSide, mapGen.mapXSize - 1);
            if (hit.transform == null)
            {
                mapGen.GenerateLeftMap();
            }

            mapReference.SetActive(true);
        }
    }
}
