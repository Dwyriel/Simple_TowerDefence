using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private const int gridSize = 10;
    public bool isExplored = false, isPlaceable = true;
    public Waypoint exploredFrom;
    [SerializeField] GameObject towerPrefab;
    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / gridSize), Mathf.RoundToInt(transform.position.z / gridSize));
    }
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && isPlaceable)
        {
            Instantiate(towerPrefab, this.transform.position, Quaternion.identity);
            isPlaceable = false;
        } else if (Input.GetMouseButtonDown(0) && !isPlaceable)
        {
            print("Not placeable here");
        }
    }
}