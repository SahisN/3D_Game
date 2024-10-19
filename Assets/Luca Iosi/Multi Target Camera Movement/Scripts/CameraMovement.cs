using System.Collections.Generic;
using UnityEngine;

namespace MultiTargetCameraMovement
{
    [RequireComponent(typeof(Camera))]
    public class CameraMovement : MonoBehaviour
    {
        public List<Transform> targetList;

        [Header("Position")]
        public Vector3 offset;
        
        [Header("Zoom")]
        public float smoothTime = 0.5f;
        public float minZoom = 40;
        public float maxZoom = 80;
        public float zoomLimiter = 50f;

        [Header("Rotation")]
        public bool automaticallyLookAtCenter = false;
        [HideInInspector]
        public float Pitch = 50;
        [HideInInspector]
        public float Yaw;
        [HideInInspector]
        public float Roll;
        
        private Vector3 velocity;
        private Camera camera;

        private void Start()
        {
            camera = GetComponent<Camera>();
        }

        //updates Camera movement and zoom after Player input and so on
        private void LateUpdate()
        {
            if (targetList.Count == 0)
                return;
            MoveAndRotate();
            Zoom();
        }

        // moves to center between Players
        void MoveAndRotate()
        {
            Vector3 centerPoint = GetCenterPoint();
            transform.position = Vector3.SmoothDamp(transform.position, centerPoint + offset, ref velocity, smoothTime);

            if (automaticallyLookAtCenter)
            {
                camera.transform.LookAt(new Vector3(camera.transform.position.x, centerPoint.y,centerPoint.z));
            }
            else
            {
                var rotation = Quaternion.Euler(Pitch, Yaw, Roll);
                camera.transform.rotation = rotation;                
            }
        }
        
        // zooms depending on distance of targets
        void Zoom()
        {
            float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, newZoom, Time.deltaTime);
        }
        
        // check the width of bound to check furthest apart targets
        float GetGreatestDistance()
        {
            var bounds = new Bounds(targetList[0].position, Vector3.zero);
            for (int i = 0; i < targetList.Count; i++)
            {
                bounds.Encapsulate(targetList[i].position);
            }

            return bounds.size.x;
        }

        // create bound around targets to get the center
        Vector3 GetCenterPoint()
        {
            if (targetList.Count == 1)
            {
                return targetList[0].position;
            }

            var bounds = new Bounds(targetList[0].position, Vector3.zero);
            for (int i = 0; i < targetList.Count; i++)
            {
                bounds.Encapsulate(targetList[i].position);
            }

            return bounds.center;
        }

        //adds target to list when called
        public void AddTarget(Transform target)
        {
            targetList.Add(target);
        }

        //removes target from list when called
        public void RemoveTarget(Transform target)
        {
            targetList.Remove(target);
        }

        private void ResetTargets()
        {
            targetList = new List<Transform>();
        }
    }
}
