using UnityEditor;

namespace MultiTargetCameraMovement
{
    [CustomEditor(typeof(CameraMovement))]
    public class CameraMovementEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var cameraMovement = target as CameraMovement;
            
            DrawDefaultInspector();

            if (!cameraMovement.automaticallyLookAtCenter)
            {
                cameraMovement.Pitch = EditorGUILayout.FloatField("Pitch", cameraMovement.Pitch);
                cameraMovement.Yaw = EditorGUILayout.FloatField("Yaw", cameraMovement.Yaw);
                cameraMovement.Roll = EditorGUILayout.FloatField("Roll", cameraMovement.Roll);
            }

        }
    }
}


