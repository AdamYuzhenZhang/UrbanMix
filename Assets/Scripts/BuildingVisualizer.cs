using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingVisualizer : MonoBehaviour
{
    [SerializeField] private BuildingManager m_BuildingManager;
    private Building m_Building;
    private List<List<List<GameObject>>> m_BuildingBlocks = new List<List<List<GameObject>>>();
    
    // Visualizer Properties
    [SerializeField] private GameObject m_BlockPrefab;
    [SerializeField] private Material m_DefaultMat;
    [SerializeField] private Material m_RenovatingMat;
    [SerializeField] private Material m_RentingMat;
    [SerializeField] private Material m_CompletedMat;

    [SerializeField] private GameObject m_FloorPrefab;
    private List<GameObject> m_BuildingFloors = new List<GameObject>();

    private void Start()
    {
        //StartCoroutine(GenerateBuildingAfterDelay());
    }

    IEnumerator GenerateBuildingAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        UpdateVisualization();
    }

    private void GenerateBuilding()
    {
        // Every Floor
        for (int f = 0; f < m_Building.NumFloor; f++)
        {
            int xUnit = m_Building.Floors[f].XUnits;
            int yUnit = m_Building.Floors[f].YUnits;
            List<Room> rooms = m_Building.Floors[f].Rooms;
            List<List<GameObject>> blocks2D = new List<List<GameObject>>();
            for (int y = 0; y < yUnit; y++)
            {
                List<GameObject> blocks1D = new List<GameObject>();
                for (int x = 0; x < xUnit; x++)
                {
                    // Every Block
                    // Create new block at location
                    GameObject block = Instantiate(m_BlockPrefab, transform.position + new Vector3(x, f, y), transform.rotation);
                    block.transform.parent = transform;
                    // Set block properties
                    //Debug.Log("Create Block");
                    //Debug.Log(x);
                    //Debug.Log(y);
                    block.GetComponent<MeshRenderer>().material = GetBlockMaterial(rooms[x+y*yUnit].RoomState);
                    blocks1D.Add(block);
                }
                blocks2D.Add(blocks1D);
            }
            m_BuildingBlocks.Add(blocks2D);
        }
    }
    
    // Generate building based on floor prefab
    private void GeneratePrefabBuilding()
    {
        // every floor
        for (int f = 0; f < m_Building.NumFloor; f++)
        {
            GameObject floor = Instantiate(m_FloorPrefab, transform.position + new Vector3(0f, f, 0f),
                transform.rotation);
            FloorPrefabController floorController = floor.GetComponent<FloorPrefabController>();
            floorController.Floor = m_Building.Floors[f];
            UpdateUnitColorsInFloorPrefab(floorController.Floor, floorController.Rooms);
            floor.transform.parent = transform;
            m_BuildingFloors.Add(floor);
        }
    }
    
    // update unit colors for floor prefabs
    private void UpdateUnitColorsInFloorPrefab(Floor floor, List<GameObject> units)
    {
        List<Room> rooms = floor.Rooms;
        for (int i = 0; i < units.Count; i++)
        {
            units[i].GetComponent<MeshRenderer>().material = GetBlockMaterial(rooms[i].RoomState);
        }
    }

    private Material GetBlockMaterial(RoomState state)
    {
        switch (state)
        {
            case RoomState.None:
                return m_DefaultMat;
                break;
            case RoomState.Completed:
                return m_CompletedMat;
                break;
            case RoomState.Renovating:
                return m_RenovatingMat;
                break;
            case RoomState.Renting:
                return m_RentingMat;
                break;
        }
        return m_DefaultMat;
    }

    public void UpdateVisualization()
    {
        // Clear Building
        DestroyBuilding();
        m_BuildingBlocks = new List<List<List<GameObject>>>();
        // Get Building
        m_Building = m_BuildingManager.Building;
        // Generate Building
        GenerateBuilding();
    }

    public void UpdateVisualizationWithFloorPrefab()
    {
        DestroyPrefabBuilding();
        m_Building = m_BuildingManager.Building;
        GeneratePrefabBuilding();
    }

    private void DestroyBuilding()
    {
        foreach (List<List<GameObject>> blocks2D in m_BuildingBlocks)
        {
            foreach (List<GameObject> blocks1D in blocks2D)
            {
                foreach (GameObject block in blocks1D)
                {
                    Destroy(block);
                }
            }
        }
    }

    private void DestroyPrefabBuilding()
    {
        foreach (GameObject floor in m_BuildingFloors)
        {
            Destroy(floor);
        }
    }
    
    
}
