using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Camera))]
public class CameraControls : MonoBehaviour
{
    [SerializeField]
    private float ZoomVelocity = 1.5f;

    [SerializeField]
    private float MinZoomLevel = 1.5f;

    [SerializeField]
    private float MaxZoomLevel = 5f;

    private Camera Camera;

    private float ZoomDirection;

    public void Start()
    {
        Camera = GetComponent<Camera>();
    }

    public void Update()
    {
        if (ZoomDirection == 0f) return;

        Camera.orthographicSize = Mathf.Clamp(
            value: Camera.orthographicSize + ZoomDirection * ZoomVelocity * Time.deltaTime,
            MinZoomLevel,
            MaxZoomLevel);
    }

    public void OnZoom(InputValue value)
    {
        ZoomDirection = value.Get<float>();
    }
}
