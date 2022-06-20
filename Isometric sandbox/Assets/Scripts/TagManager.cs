using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TagManager : MonoBehaviour
{
    public static GameObject[] ListOfAllies;
    public Camera cam;
    RaycastHit hit;
    //public static event Action<GameObject> TestActionAddingDamage; // TO BE REMOVED AFTER TESTS!!!

    string _SelectedSpell;

    //// CAMERAS SWTICH
    //public GameObject _VCAMFollow;
    //public GameObject _VCAMFree;

    // Start is called before the first frame update
    void Start()
    {
       ListOfAllies = GameObject.FindGameObjectsWithTag("Ally");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q)) // TO BE REMOVED AFTER TESTS!!!
        {
            _SelectedSpell = "Q";


            Ray ray = cam.ScreenPointToRay(Input.mousePosition); // TO BE REMOVED AFTER TESTS!!!
            if (Physics.Raycast(ray, out hit)) // TO BE REMOVED AFTER TESTS!!!
            {
                Debug.Log(hit.point);

                //TestActionAddingDamage?.Invoke(hit.collider.gameObject); // TO BE REMOVED AFTER TESTS!!!
            }
        }

        if (_SelectedSpell == "Q")
        {

        }

        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    if (_VCAMFollow.activeInHierarchy == true)
        //    {
        //        _VCAMFollow.SetActive(false);
        //        _VCAMFree.SetActive(true);
        //    }
        //    else
        //    {
        //        _VCAMFollow.SetActive(true);
        //        _VCAMFree.SetActive(false);
        //    }
        //}
    }
}
