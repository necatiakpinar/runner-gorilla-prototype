using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CWorld : MonoBehaviour
{
    public CController_Player Player;
    public CManager_UI UIManager;
    public CManager_Timeline TimelineManager;
    public CManager_Scene SceneManager;
    public int TargetCollectableCount;




    public static CWorld Instance;
    private void Awake()
    {
        Instance = this;
    }

}
