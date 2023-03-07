using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoomType {None, Studio, _1B1B};
public enum RoomState {None, Renovating, Renting, Completed};

public class Room
{
    // Constructor
    public Room() { }

    public Room(RoomType type, RoomState state)
    {
        m_RoomType = type;
        m_RoomState = state;
    }
    
    // Properties
    private RoomType m_RoomType;
    private RoomState m_RoomState;
    
    // Json Properties
    public string UnitStatus;
    public string UnitType;
    public int NumBeds;
    public int NumBaths;
    public string UnitID;
    public float UnitSF;
    public float CurrentRent;
    public float PSF;

    // Getters
    public RoomType RoomType
    {
        get => m_RoomType;
        set => m_RoomType = value;
    }

    public RoomState RoomState
    {
        get => m_RoomState;
        set => m_RoomState = value;
    }
}
