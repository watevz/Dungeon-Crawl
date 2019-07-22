using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static class NavigationBaker {

    public static NavMeshSurface[] surfaces;

    public static void GenerateNavMesh() 
    {
        FindSurfaces();

        for (int i = 0; i < surfaces.Length; i++) 
        {
            surfaces [i].BuildNavMesh();   
        }   
    }

    private static void FindSurfaces(){
       surfaces = GameObject.FindObjectsOfType<NavMeshSurface>();
    }

}
