using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour
{
    public Camera _Cam;
    RaycastHit _Hit;
    private NavMeshAgent _NavMeshAgent;
    public Interaction _CurrentFocus;
    Interaction _TargetToFollow;

    private void Awake()
    {
        _NavMeshAgent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        if(_TargetToFollow != null)
        {
            _NavMeshAgent.SetDestination(_TargetToFollow.transform.position);

            //face target only when you are close to your target-destination
            float _Distance = Vector3.Distance(_TargetToFollow.transform.position, transform.position);
            if (_Distance <= _TargetToFollow._Radius)
            {
                FaceTarget();
            }
        }



        if (Input.GetMouseButtonDown(0))
        {
            Ray Ray = _Cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(Ray, out _Hit))
            {

                Interaction _Interactable = _Hit.collider.GetComponent<Interaction>();
                if (_Interactable != null) //did we hit interactable?
                {
                    SetFocus(_Interactable);
                }
                else
                {
                    _NavMeshAgent.SetDestination(_Hit.point);
                    RemoveFocus();
                }
            }
        }
    }

    void SetFocus(Interaction _NewFocus)
    {
        if(_NewFocus != _CurrentFocus)
        {
            if(_CurrentFocus != null)
            {
                _CurrentFocus.NoLongerFocusedBy(); //if i had focused other object, inform it that I No Longer Focus it
            }
            _CurrentFocus = _NewFocus;
            FollowTarget(_CurrentFocus);
        }
        _NewFocus.WhoFocusedMe(transform); //inform the other side who is going to interact with it
    }

    void RemoveFocus()
    {
        if (_CurrentFocus != null)
        {
            _CurrentFocus.NoLongerFocusedBy(); //if i had focused other object, inform it that I No Longer Focus it
        }
        _CurrentFocus = null;
        StopFollowingTarget();
    }

    void FollowTarget(Interaction _NewTarget)
    {
        _NavMeshAgent.stoppingDistance = _NewTarget._Radius * 0.8f;
        _TargetToFollow = _NewTarget;
    }

    void StopFollowingTarget()
    {
        _NavMeshAgent.stoppingDistance = 0.05f;
        _TargetToFollow = null;
    }

    void FaceTarget()
    {
        Vector3 _Direction = (_TargetToFollow.transform.position - transform.position).normalized;
        Quaternion _LookRotation = Quaternion.LookRotation(new Vector3(_Direction.x, 0f, _Direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, _LookRotation, Time.deltaTime * 5f);
    }

}
