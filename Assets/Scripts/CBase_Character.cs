using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CBase_Character : MonoBehaviour
{
    public int Level = 1;
    public int AttackCount;
    public int AttackIndex { get { return Random.Range(0, AttackCount); } }
    public TMP_Text Text_Level;
    public Animator Animator;


    protected virtual void Awake()
    {
        UpdateLevelText();
        Animator = GetComponentInChildren<Animator>();
    }
    public virtual void UpdateLevelText()
    {
        Text_Level.text = "Level: " + Level.ToString();
    }
}
