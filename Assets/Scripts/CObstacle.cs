using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObstacle : MonoBehaviour
{
    public int Type = 0;
    private Animator Animator;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        if(Animator == null) Animator = GetComponentInChildren<Animator>();
        
        if(Animator != null) Animator.SetInteger("Type", Type);        
    }
}
