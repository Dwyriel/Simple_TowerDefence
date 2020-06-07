using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode][SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [Range(1f, 100f)] [SerializeField] int gridSize = 10;
    TextMesh textMesh;

    private void Start()
    {
        textMesh = GetComponentInChildren<TextMesh>();
    }


    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        textMesh.text = snapPos.x/gridSize + " - "+ snapPos.z/gridSize;
    }
}
