using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[ExecuteInEditMode][SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    TextMesh textMesh;
    Waypoint waypoint;
    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
        textMesh = GetComponentInChildren<TextMesh>();
    }


    void Update()
    {
        SnapToGrid();
        UpdateLabel();

    }

    private void SnapToGrid()
    {
        transform.position = new Vector3(waypoint.GetGridPos().x * waypoint.GetGridSize(), 0f, waypoint.GetGridPos().y * waypoint.GetGridSize());
    }

    private void UpdateLabel()
    {
        string labelTxt = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
        textMesh.text = labelTxt;
        gameObject.name = labelTxt;
    }
}
