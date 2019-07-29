using UnityEngine;
using System.Collections;

namespace ThirdPersonCamera
{
    public class CameraFollow : MonoBehaviour, ICameraFollow
    {
        public Vector3 offset;  

        public float pitch = 2f;
        public float zoomSpeed = 4f;
        public float minZoom = 4f;
        public float maxZoom = 15f;
        public float yawSpeed = 10f;

        private float currentYaw = 0f;
        private float currentZoom = 2f;

        private Transform target;

        void Start()
        {
            //Find the target/ player
            target = GameObject.FindWithTag("Player").transform;
        }

        void Update()
        {
            if(!target){
                target = GameObject.FindWithTag("Player").transform;
            }
            currentZoom  -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

            currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
        }

        void LateUpdate()
        {
            // Smoothly interpolate between the camera's current position and it's target position.
            transform.position = target.position - offset * currentZoom;

            transform.RotateAround(target.position, Vector3.up, currentYaw);
            transform.LookAt(target.position + Vector3.up * pitch);
        }
    }
}
