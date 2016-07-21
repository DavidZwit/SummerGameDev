#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections;

[ExecuteInEditMode]
public class CameraSync : MonoBehaviour
{
    public bool on = true;
    public bool inGame = true;
    public Camera designCam;
    private Camera currentView;

    public void OnDrawGizmos()
    {
        Synchornize();
    }

    void Synchornize()
    {
        if (on && SceneView.lastActiveSceneView.camera != null)
        {
            Camera lastView = SceneView.lastActiveSceneView.camera;
            currentView = SceneView.lastActiveSceneView.camera;
            designCam.transform.position = currentView.transform.position;
            designCam.transform.rotation = currentView.transform.rotation;
        }
    }


}
#endif