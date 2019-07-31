using UnityEngine;
using System.Collections;

namespace ThirdPersonCamera
{
    public interface ICameraFollow
    {
        // //public Variables

        // Vector3 offset; 

        // float pitch ;
        // float zoomSpeed ;
        // float minZoom ;
        // float maxZoomf ;
        // float yawSpeed ;

        // //Private Variables

        // float currentYaw ;
        // float currentZoom ;

        // Transform target;
        
       // void Start();
            //locate the Player object and set target to its transform
        

        //void Update();
            //update camera position based off mouse wheel to control zoom
            //rotate camera around player based off horizontal axis (mouse) input
        

       // void LateUpdate();
            // Smoothly interpolate between the camera's current position 
            //and it's target position.
        
    }
}