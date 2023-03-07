using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject m_BuildingInfoCanvas;
    [SerializeField] private GameObject m_CameraTarget;
    private Vector3 m_CameraTargetPos;

    private void Start()
    {
        m_CameraTargetPos = m_CameraTarget.transform.position;
    }

    public void ToggleBuildingInfoCanvas(Vector3 targetPos)
    {
        m_BuildingInfoCanvas.SetActive(true);
        Camera.main.orthographicSize = 2f;
        m_CameraTarget.transform.position = targetPos;
    }

    public void TurnOffBuildingInfoCanvas()
    {
        m_BuildingInfoCanvas.SetActive(false);
        Camera.main.orthographicSize = 5f;
        m_CameraTarget.transform.position = m_CameraTargetPos;
    }
}
