using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building
{
    // Constructor
    public Building() { }

    public Building(int f, List<Floor> floors)
    {
        m_NumFloor = f;
        m_Floors = floors;
    }
    
    // Properties
    private int m_NumFloor;
    private List<Floor> m_Floors;
    
    // Getters
    public int NumFloor
    {
        get => m_NumFloor;
        set => m_NumFloor = value;
    }

    public List<Floor> Floors
    {
        get => m_Floors;
        set => m_Floors = value;
    }
}
