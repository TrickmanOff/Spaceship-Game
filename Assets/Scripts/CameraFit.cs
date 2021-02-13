using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFit : MonoBehaviour
{
    public int targetHeight;
    public int targetWidth;
    public int unitsInSceneHeight;
    //size of scene
    public float x1, x2, y1, y2;

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        //portrait resolution by default
        float targetRatio = targetHeight / targetWidth;
        float curRatio = (float)Screen.height / Screen.width;

        if (curRatio > targetRatio)
        {
            float unitsInWidth = (float)targetWidth / targetHeight * unitsInSceneHeight;
            float unitsInHeight = Screen.height / (Screen.width / unitsInWidth);
            _camera.orthographicSize = unitsInHeight / 2;


            float moveDown = (unitsInHeight - unitsInSceneHeight) / 2;
            float posY = _camera.transform.position.y - moveDown;
            _camera.transform.position = new Vector3(_camera.transform.position.x, posY, _camera.transform.position.z);
        }

        y1 = -_camera.orthographicSize + _camera.transform.position.y;
        y2 = _camera.orthographicSize + _camera.transform.position.y;
        x1 = -(float)Screen.width / Screen.height * _camera.orthographicSize;
        x2 = -x1;
        Debug.Log("y1 = " + y1 + " y2 = " + y2 + " x1 = " + x1 + " x2 = " + x2);
    }

    private void Start()
    {
        
    }
}
