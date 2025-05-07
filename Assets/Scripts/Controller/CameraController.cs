using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera _camera;

    [SerializeField] Transform target;

    float speed = 5f;
    float offsetX,offsetY;
    [SerializeField] float minBoundsX, maxBoundsX;
    [SerializeField] float minBoundsY, maxBoundsY;
    
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        offsetX = _camera.transform.position.x - target.position.x;
        offsetY = _camera.transform.position.y - target.position.y;
        minBoundsX = -8.24f;
        maxBoundsX = 10.28f;
        minBoundsY = -5.94f;
        maxBoundsY = 6.0f;
    }

    public void FollowTarget()
    {
        transform.position = new Vector3(Mathf.Clamp(Mathf.Lerp(transform.position.x, target.position.x + offsetX, speed * Time.deltaTime), minBoundsX, maxBoundsX), Mathf.Clamp(Mathf.Lerp(transform.position.y, target.position.y + offsetY, speed * Time.deltaTime), minBoundsY, maxBoundsY), transform.position.z);

    }

   

    // Update is called once per frame
    void LateUpdate()
    {
        FollowTarget();
    }
}
