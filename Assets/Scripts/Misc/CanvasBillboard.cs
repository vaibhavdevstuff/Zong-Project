using UnityEngine;

public class CanvasBillboard : MonoBehaviour
{

    Camera mainCamera;

    void Update()
    {
        if (mainCamera)
        {
            transform.LookAt(mainCamera.transform, Vector3.up);
            transform.Rotate(Vector3.up, 180f);
        }
        else
            mainCamera = Camera.main;
    
    }
}
