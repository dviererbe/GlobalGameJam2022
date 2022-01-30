using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Camera))]
public class CameraControls : MonoBehaviour
{
    [SerializeField]
    private float MinZoomLevel = 10;

    [SerializeField]
    private float MaxZoomLevel = 10;

    private Camera Camera;

    public void Start()
    {
        Camera = GetComponent<Camera>();
    }

    public void Update()
    {
        
    }

    public void OnZoom(InputValue value)
    {
        Debug.Log($"Zoom {value.Get<float>()}");
    }
}
