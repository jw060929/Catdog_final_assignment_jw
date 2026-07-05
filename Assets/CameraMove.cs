using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform mario;
    public float minX;
    public float maxX;
    public float fixedY;
    public float fixedZ = -10f;
    
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        float targetX = Mathf.Clamp(mario.position.x, minX, maxX);
        transform.position = new Vector3(targetX, fixedY, fixedZ);
    }
}