using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBaker : MonoBehaviour
{
    [SerializeField]
    NavMeshSurface[] navMeshSurfaces;
    
    void Start(){
         for(int i = 0; i < navMeshSurfaces.Length; i++){
            navMeshSurfaces[i].BuildNavMesh();
        }
    }
    void Update()
    {
        for(int i = 0; i < navMeshSurfaces.Length; i++){
            navMeshSurfaces[i].BuildNavMesh();
            Debug.Log(navMeshSurfaces[i].navMeshData.position);
            Debug.Log(navMeshSurfaces[i].navMeshData.rotation);
            Debug.Log(navMeshSurfaces[i].navMeshData.sourceBounds);
        }
        
    }
}
