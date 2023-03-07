using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPrefabController : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_Rooms;
    private Floor m_Floor;

    public Floor Floor
    {
        get => m_Floor;
        set => m_Floor = value;
    }

    public List<GameObject> Rooms
    {
        get => m_Rooms;
        set => m_Rooms = value;
    }
}
