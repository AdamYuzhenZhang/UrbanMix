using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // Parameters
    private int m_XUnits;
    private int m_YUnits;
    private int m_NumFloor;
    
    // Get data
    public Building GetBuilding()
    {
        Building building = new Building();
        return building;
    }
    
    public Floor GetFloor()
    {
        Floor floor = new Floor();
        return floor;
    }
    
    private Room GetRoom()
    {
        Room room = new Room(RoomType.Studio, RoomState.Completed);
        return room;
    }
}
