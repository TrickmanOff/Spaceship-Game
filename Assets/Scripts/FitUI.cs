using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FitUI : MonoBehaviour
{
    public CameraFit _camera;
    private float targetRatio = 1920f / 1080;

    void fitObjects()
    {
        RectTransform cur = GetComponentInChildren<Image>().GetComponent<RectTransform>();
        cur.position = new Vector2(_camera.x1 + 0.7f, _camera.y1 + 0.7f);

        cur = GetComponentInChildren<Text>().GetComponent<RectTransform>();
        cur.position = new Vector2(_camera.x1 + 1.5f, _camera.y1 + 0.7f);
    }

    private void Start()
    {
        if (Screen.height / Screen.width > targetRatio)
            fitObjects();
    }
}
