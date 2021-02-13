using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    public float x1 = -5.4f;
    public float x2 = 5.4f;
    private float y1;
    public float y2 = 9f;
    public Camera _camera;

    public EventSystem uiEventSystem;

    private bool pressed = false;

    bool betw(float val, float lb, float rb)
    {
        return val >= lb && val <= rb;
    }

    private void Start()
    {
        y1 = -_camera.orthographicSize + _camera.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            if (uiEventSystem.IsPointerOverGameObject())
                return;

            if (Input.GetMouseButton(0))
                pressed = true;
            else
                pressed = false;
        }

        if(SystemInfo.deviceType == DeviceType.Handheld)
        {
            if (Input.touchCount == 0)
                pressed = false;
            else if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (!uiEventSystem.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    pressed = true;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                pressed = false;
        }

        if (pressed)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.y += 2f;
            if (betw(pos.x, x1, x2) && betw(pos.y, y1, y2))
                transform.position = pos;
        }
    }
}
