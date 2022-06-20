using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    private void Start()
    {
        Interaction_ButtonPress.OnPressed += ChangeScene;
    }

    // Update is called once per frame
    void ChangeScene(int triggerID)
    {


        switch (triggerID)
        {
            case 10:
                Debug.Log("Changing scenes");
                SceneManager.LoadScene(0);
                break;

            case 20:
                Debug.Log("Changing scenes");
                SceneManager.LoadScene(1);
                break;
        }


    }
}
