using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float _Radius = 3f;
    bool _IsFocused = false;
    Transform _WhoFocusedMe;
    bool _HasInteracted = false;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _Radius);
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    private void Update()
    {
        if(_IsFocused && !_HasInteracted)
        {
            float _Distance = Vector3.Distance(_WhoFocusedMe.position, transform.position);

            if(_Distance <= _Radius)
            {
                Interact();
                _HasInteracted = true;
            }
        }
    }

    public void WhoFocusedMe(Transform _PlayerTransform)
    {
        _IsFocused = true; //someone has focused on me
        _WhoFocusedMe = _PlayerTransform;
        _HasInteracted = false;
    }

    public void NoLongerFocusedBy()
    {
        _IsFocused = false; //someone has lost it's interest in me
        _WhoFocusedMe = null;
        _HasInteracted = false;
    }

}
