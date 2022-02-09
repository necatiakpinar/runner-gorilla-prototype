using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CManager_Enemy : MonoBehaviour
{
    public List<CController_Enemy> Enemies;

    private void Awake()
    {
        Enemies = new List<CController_Enemy>();
        foreach(Transform child in transform) Enemies.Add(child.GetComponent<CController_Enemy>());
    }
}
