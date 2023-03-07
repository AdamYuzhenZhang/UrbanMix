using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorController : MonoBehaviour
{
    [SerializeField] private float m_PercentageCompleted;
    [SerializeField] private GameObject m_IndicatorRoot;
    [SerializeField] private GameObject m_InvalidRoot;
    [SerializeField] private GameObject m_IndicatorCube;

    private void Update()
    {
        UpdateIndicatorScale();
    }

    private void UpdateIndicatorScale()
    {
        m_IndicatorRoot.transform.localScale = new Vector3(m_PercentageCompleted, 1f, 1f);
        m_InvalidRoot.transform.localScale = new Vector3(1 - m_PercentageCompleted, 1f, 1f);
        m_IndicatorCube.GetComponent<MeshRenderer>().material.color = new Color(1f, m_PercentageCompleted * 0.9f, 1f);
    }
}
