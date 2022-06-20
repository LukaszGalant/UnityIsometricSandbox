using UnityEngine;
using System;

public class Interaction_ButtonPress : Interaction
{

    public static event Action<int> OnPressed;
    public int id;


    public override void Interact()
    {
        OnPressed?.Invoke(id); //streaming
    }

}
