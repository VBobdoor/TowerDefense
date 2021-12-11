using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NavMeshGroundController))]
public class LevelBuilding : MonoBehaviour
{
    [SerializeField] private GameObject turretCell;
    [SerializeField] private GameObject groundCell;
    [SerializeField] private GameObject groundCellStart;
    [SerializeField] private GameObject groundCellEnd;

    [SerializeField] private GameObject allCellPoints;
    [SerializeField] private Transform cellPoint;

    private NavMeshGroundController navMeshGroundController;

    private float cellSizeX = 4.5f;
    private float cellSizeZ = 4.5f;

    private const int TURRET_CELL_NUMBER = 1;
    private const int GROUND_CELL_NUMBER = 0;
    private const int GROUND_START_CELL_NUMBER = 3;
    private const int GROUND_END_CELL_NUMBER = 4;



    private int[][] levelCell = new int[6][];

    private void Awake()
    {
        navMeshGroundController = GetComponent<NavMeshGroundController>();

        CreateStandartLevelCell();
        BuildLevel();
        navMeshGroundController.RefreshNavMesh();
    }

    //Building level with array, find all starts and give them endpoint
    private void BuildLevel()
    {
        Transform endPoint = null;
        List<SpawnPoint> startPoints = new List<SpawnPoint>();
        for(int i = 0; i < levelCell.Length; i++)
        {
            for(int j = 0; j < levelCell[i].Length; j++)
            {
                switch (levelCell[i][j])
                {
                    case GROUND_CELL_NUMBER:
                        {
                            Instantiate(groundCell, cellPoint.position, Quaternion.identity, allCellPoints.transform);
                            break;
                        }
                    case TURRET_CELL_NUMBER:
                        {
                            Instantiate(turretCell, cellPoint.position, Quaternion.identity, allCellPoints.transform);
                            break;
                        }
                    case GROUND_START_CELL_NUMBER:
                        {
                            GameObject startCell = Instantiate(groundCellStart, cellPoint.position, Quaternion.identity, allCellPoints.transform);
                            startPoints.Add(startCell.GetComponent<SpawnPoint>());
                            break;
                        }
                    case GROUND_END_CELL_NUMBER:
                        {
                            GameObject endCell = Instantiate(groundCellEnd, cellPoint.position, Quaternion.identity, allCellPoints.transform);
                            endPoint = endCell.transform;
                            break;
                        }

                }

                cellPoint.position = new Vector3(cellPoint.position.x + cellSizeX, cellPoint.position.y , cellPoint.position.z);
            }
            cellPoint.position = new Vector3(cellPoint.position.x - cellSizeX * levelCell[i].Length, cellPoint.position.y, cellPoint.position.z + cellSizeZ);
        }
        for(int i = 0; i < startPoints.Count; i++)
        {
            startPoints[i].TargetPoint = endPoint;
        }
        allCellPoints.SetActive(true);
    }

    private void CreateStandartLevelCell()
    {
        levelCell[0] = new int[] { 1, 1, 1, 4 };
        levelCell[1] = new int[] { 1, 0, 0, 0 };
        levelCell[2] = new int[] { 1, 0, 1, 1 };
        levelCell[3] = new int[] { 1, 0, 0, 1 };
        levelCell[4] = new int[] { 1, 1, 0, 1 };
        levelCell[5] = new int[] { 3, 0, 0, 1 };
    }
}
