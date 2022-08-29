using System;
using UnityEngine;

public class MainCubeMoving : MonoBehaviour
{
    public int direction = 1;
    private Rigidbody _rigidbody;
    public float speedForward;
    public float speedSide;
    
    private Vector3 lastMousePos;
    private Vector3 curMousePos;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = Input.mousePosition;
            mousePos.z = 10;
            lastMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        }

        if (Input.GetMouseButton(0))
        {
            var mousePos = Input.mousePosition;
            mousePos.z = 10;
            curMousePos = Camera.main.ScreenToWorldPoint(mousePos);
            float diff = (curMousePos.x - lastMousePos.x) * 0.6f;
            transform.Translate(diff, 0, 0);
            lastMousePos = curMousePos;
        }
        float xDiff = Input.GetAxis("Horizontal") * speedSide * Time.deltaTime; 
        transform.Translate(xDiff, 0, 0);
    }
    
    private void FixedUpdate()
    {
        var velocity = direction == 1 ? speedForward * Vector3.forward : Vector3.zero;
        velocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = velocity;
    }
}