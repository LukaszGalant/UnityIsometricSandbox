using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public float _ScrollSpeed = 20;
    public float _TopBarrier = 0.97f;
    public float _BottomBarrier = 0.03f;
    public float _LeftBarrier = 0.97f;
    public float _RightBarrier = 0.03f;


    // Update is called once per frame
    void Update()
    {
        
        if(Input.mousePosition.y >= Screen.height * _TopBarrier)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _ScrollSpeed, Space.World);
        }

        if (Input.mousePosition.y <= Screen.height * _BottomBarrier)
        {
            transform.Translate(Vector3.back * Time.deltaTime * _ScrollSpeed, Space.World);
        }

        if (Input.mousePosition.x >= Screen.width * _RightBarrier)
        {
            transform.Translate(Vector3.right * Time.deltaTime * _ScrollSpeed, Space.World);
        }

        if (Input.mousePosition.x <= Screen.width * _LeftBarrier)
        {
            transform.Translate(Vector3.left * Time.deltaTime * _ScrollSpeed, Space.World);
        }

    }
}
