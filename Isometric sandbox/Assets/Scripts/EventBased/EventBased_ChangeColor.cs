using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBased_ChangeColor : MonoBehaviour
{

    public int targetID;

    private void Start()
    {
        Interaction_ButtonPress.OnPressed += ChangeColours;
    }

    // Update is called once per frame
    void ChangeColours(int triggerID)
    {
        if (triggerID == targetID)
        {

            Color newColour = new Color
                (
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
                );

            GetComponent<Renderer>().material.color = newColour;
        }
    }
}