using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehavior : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("MouseDown");
        Camera.main.GetComponent<CameraController>().ToggleBuildingInfoCanvas(transform.position);
    }
}
