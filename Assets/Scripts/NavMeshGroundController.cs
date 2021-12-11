using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshGroundController : MonoBehaviour
{
    [SerializeField] private NavMeshSurface surface;

    public void RefreshNavMesh()
    {
        surface.BuildNavMesh();
    }
}
