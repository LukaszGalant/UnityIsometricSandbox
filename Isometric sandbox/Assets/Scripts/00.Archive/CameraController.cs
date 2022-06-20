using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{

    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;
    public GameObject Camera4;
    public bool _IsAvailable = true;
    public float _CooldownDuration = 1.1f;


    private void Start()
    {
        Camera1.SetActive(true);
        Camera2.SetActive(false);
        Camera3.SetActive(false);
        Camera4.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && _IsAvailable == true)
        {
            if (Camera1.activeInHierarchy == true)
            {
                Camera1.SetActive(false);
                Camera2.SetActive(true);
                StartCoroutine(WaitCoroutine());
            }

            else if (Camera2.activeInHierarchy == true)
            {
                Camera2.SetActive(false);
                Camera3.SetActive(true);
                StartCoroutine(WaitCoroutine());
            }

            else if (Camera3.activeInHierarchy == true)
            {
                Camera3.SetActive(false);
                Camera4.SetActive(true);
                StartCoroutine(WaitCoroutine()); ;
            }

            else if (Camera4.activeInHierarchy == true)
            {
                Camera1.SetActive(true);
                Camera4.SetActive(false);
                StartCoroutine(WaitCoroutine());
            }
        }

        if (Input.GetKeyDown(KeyCode.O) && _IsAvailable == true)
        {
            if (Camera1.activeInHierarchy == true)
            {
                Camera1.SetActive(false);
                Camera4.SetActive(true);
                StartCoroutine(WaitCoroutine());
            }

            else if (Camera2.activeInHierarchy == true)
            {
                Camera1.SetActive(true);
                Camera2.SetActive(false);
                StartCoroutine(WaitCoroutine());
            }

            else if (Camera3.activeInHierarchy == true)
            {
                Camera2.SetActive(true);
                Camera3.SetActive(false);
                StartCoroutine(WaitCoroutine());
            }

            else if (Camera4.activeInHierarchy == true)
            {
                Camera3.SetActive(true);
                Camera4.SetActive(false);
                StartCoroutine(WaitCoroutine());
            }
        }            
    }

    IEnumerator WaitCoroutine()
    {
        _IsAvailable = false;
        yield return new WaitForSeconds(_CooldownDuration);
        _IsAvailable = true;
    }


}
