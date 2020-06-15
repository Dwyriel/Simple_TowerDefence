using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private const int gridSize = 10;
    public bool isExplored = false, isPlaceable = true;
    public Waypoint exploredFrom;
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
            print(gameObject.name + "is clicked");
        } else if (Input.GetMouseButtonDown(0) && !isPlaceable)
        {
            print("Not placeable here");
        }
    }
}