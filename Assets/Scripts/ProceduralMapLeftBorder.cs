using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralMapLeftBorder : MonoBehaviour
{
    // Initialize Variables
    ProceduralMapGeneration mapGen;
    GameObject mapReference;
    Vector2 rightSide = new Vector2(1, 0);   
    Vector2 upSide = new Vector2(0, 1);
    Vector2 downSide = new Vector2(0, -1);
    //Vector2 leftSide = new Vector2(-1, 0);
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

            // Down Side
            hit = Physics2D.Raycast(mapGen.currentStandingMap, downSide, mapGen.mapYSize);
            if (hit.transform == null)
            {
                mapGen.GenerateDownMap();
            }

            // Up Side
            hit = Physics2D.Raycast(mapGen.currentStandingMap, upSide, mapGen.mapYSize);
            if (hit.transform == null)
            {
                mapGen.GenerateUpMap();
            }

            mapReference.SetActive(true);
        }
    }
}
