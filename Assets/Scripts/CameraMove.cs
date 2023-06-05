using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    [SerializeField] float zoomSpeed;
    [SerializeField] float scrollSpeed;
    [SerializeField] float padding;

    private Vector3 moveDir;
    private float zoomScroll;


    private void LateUpdate()
    {
        Zoom();
        Pointer();
    }

    private void Zoom()
    {
        transform.Translate(Vector3.forward * zoomScroll * zoomSpeed * Time.deltaTime , Space.Self);

    }

    private void OnZoom(InputValue value)
    {
        zoomScroll = value.Get<Vector2>().y;
    }

    private void Pointer()
    {
        transform.Translate(moveDir * scrollSpeed * Time.deltaTime, Space.World);
    }

    private void OnPointer(InputValue value)
    {
        Vector2 mousePos = value.Get<Vector2>();
        if (mousePos.x < padding)
            moveDir.x = -1;
        else if (mousePos.x > Screen.width - padding)
            moveDir.x = +1;
        else
            moveDir.x = 0;
        
        if (mousePos.y < padding)
            moveDir.z = -1;
        else if (mousePos.y > Screen.height - padding)
            moveDir.z = +1;
        else
            moveDir.z = 0;
    }
    
}
