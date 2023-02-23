using System.Collections;
using UnityEngine;
using TMPro;

public class GridDebugObject : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMeshPro;
    private GridObject gridObject;
    public void SetGridObject(GridObject gridObject)
    {
        this.gridObject = gridObject;
        SetTextObject();
    }
    public  void SetTextObject()
    {
        textMeshPro.text = gridObject.ToString();
    }
    private void Update()
    {
        SetTextObject();
    }
}