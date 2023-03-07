using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    // Parameters
    [SerializeField] private BuildingVisualizer m_Visualizer;
    
    [SerializeField] private int m_XUnits;
    [SerializeField] private int m_YUnits;
    [SerializeField] private int m_NumFloor;
    private RoomState[][] m_RoomStates;
    private RoomType[][] m_RoomTypes;
    private Building m_Building;
    [SerializeField] private RoomState[] m_RoomStateF1;
    [SerializeField] private RoomState[] m_RoomStateF2;
    [SerializeField] private RoomState[] m_RoomStateF3;
    [SerializeField] private RoomState[] m_RoomStateF4;
    [SerializeField] private RoomState[] m_RoomStateF5;
    [SerializeField] private RoomState[] m_RoomStateF6;
    [SerializeField] private RoomState[] m_RoomStateF7;
    [SerializeField] private RoomState[] m_RoomStateF8;

    [SerializeField] private RoomType[] m_RoomTypeF;

    [SerializeField] private Slider m_TimeSlider;

    // Getter and Setter
    public Building Building
    {
        get => m_Building;
        set => m_Building = value;
    }

    // Create data structure
    private Building CreateBuilding(int f, List<Floor> floors)
    {
        Building building = new Building(f, floors);
        return building;
    }
    
    private Floor CreateFloor(int x, int y, List<Room> rooms)
    {
        Floor floor = new Floor(x, y, rooms);
        return floor;
    }
    
    private Room CreateRoom(RoomType type, RoomState state)
    {
        Room room = new Room(type, state);
        return room;
    }
    
    // Create building
    private Floor GetAFloor(RoomType[] types, RoomState[] states)
    {
        List<Room> rooms = new List<Room>();
        for (int i = 0; i < states.Length; i++)
        {
            Room room = CreateRoom(types[i], states[i]);
            rooms.Add(room);
        }
        return CreateFloor(m_XUnits, m_YUnits, rooms);
    }

    private Building GetABuilding()
    {
        List<Floor> floors = new List<Floor>();
        for (int i = 0; i < m_NumFloor; i++)
        {
            floors.Add(GetAFloor(m_RoomTypes[i], m_RoomStates[i]));
        }
        return CreateBuilding(m_NumFloor, floors);
    }
    
    // Start
    private void Start()
    {
        // create building
        UpdateFloorPrefabs();
        //Debug.Log("Building");
        //Debug.Log(m_TheBuilding);
    }
    
    // Update floors for specific type of buildihng with floor prefabs
    public void UpdateFloorPrefabs()
    {
        int num = (int) m_TimeSlider.value;
        // Get types and states
        if (num == 0)
        {
            m_RoomStates = new RoomState[][]{m_RoomStateF1, m_RoomStateF2, m_RoomStateF2, m_RoomStateF1, m_RoomStateF2, m_RoomStateF2, m_RoomStateF1, m_RoomStateF1, m_RoomStateF2, m_RoomStateF2};
        }
        if (num == 1)
        {
            m_RoomStates = new RoomState[][]{m_RoomStateF4, m_RoomStateF3, m_RoomStateF3, m_RoomStateF4, m_RoomStateF3, m_RoomStateF3, m_RoomStateF3, m_RoomStateF4, m_RoomStateF3, m_RoomStateF4};
        }
        if (num == 2)
        {            
            m_RoomStates = new RoomState[][]{m_RoomStateF5, m_RoomStateF6, m_RoomStateF5, m_RoomStateF5, m_RoomStateF5, m_RoomStateF6, m_RoomStateF5, m_RoomStateF6, m_RoomStateF6, m_RoomStateF5};
        }
        if (num == 3)
        {
            m_RoomStates = new RoomState[][]{m_RoomStateF8, m_RoomStateF7, m_RoomStateF8, m_RoomStateF7, m_RoomStateF7, m_RoomStateF8, m_RoomStateF8, m_RoomStateF7, m_RoomStateF8, m_RoomStateF7};
        }
        m_RoomTypes = new RoomType[][]{m_RoomTypeF, m_RoomTypeF, m_RoomTypeF, m_RoomTypeF, m_RoomTypeF, m_RoomTypeF, m_RoomTypeF, m_RoomTypeF, m_RoomTypeF, m_RoomTypeF};
        
        m_Building = GetABuilding();
        m_Visualizer.UpdateVisualizationWithFloorPrefab();
    }
    
    // Update building from data
    public void UpdateBuilding()
    {
        // Get types and states
        m_RoomStates = new RoomState[][]{m_RoomStateF1, m_RoomStateF2, m_RoomStateF3, m_RoomStateF4};
        m_RoomTypes = new RoomType[][]{m_RoomTypeF, m_RoomTypeF, m_RoomTypeF, m_RoomTypeF};
        
        m_Building = GetABuilding();
        m_Visualizer.UpdateVisualization();
    }
    
    // Update building from data
    public void UpdateBuilding2()
    {
        int num = (int) m_TimeSlider.value;
        // Get types and states
        if (num == 0)
        {
            m_RoomStates = new RoomState[][]{m_RoomStateF1, m_RoomStateF2, m_RoomStateF3, m_RoomStateF4};
        }
        if (num == 1)
        {
            m_RoomStates = new RoomState[][]{m_RoomStateF3, m_RoomStateF2, m_RoomStateF2, m_RoomStateF4};
        }
        if (num == 2)
        {
            m_RoomStates = new RoomState[][]{m_RoomStateF2, m_RoomStateF4, m_RoomStateF3, m_RoomStateF3};
        }
        if (num == 3)
        {
            m_RoomStates = new RoomState[][]{m_RoomStateF2, m_RoomStateF3, m_RoomStateF4, m_RoomStateF1};
        }
        
        m_RoomTypes = new RoomType[][]{m_RoomTypeF, m_RoomTypeF, m_RoomTypeF, m_RoomTypeF};
        
        m_Building = GetABuilding();
        m_Visualizer.UpdateVisualization();
    }
}
