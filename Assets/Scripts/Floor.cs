using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor
{
    // Constructor
    public Floor() { }

    public Floor(int x, int y, List<Room> rooms)
    {
        m_XUnits = x;
        m_YUnits = y;
        m_Rooms = rooms;
    }
    
    // Properties
    private int m_XUnits;
    private int m_YUnits;
    private List<Room> m_Rooms;
    
    // Getters
    public int XUnits
    {
        get => m_XUnits;
        set => m_XUnits = value;
    }

    public int YUnits
    {
        get => m_YUnits;
        set => m_YUnits = value;
    }

    public List<Room> Rooms
    {
        get => m_Rooms;
        set => m_Rooms = value;
    }
}
