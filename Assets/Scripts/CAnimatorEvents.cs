using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAnimatorEvents : MonoBehaviour
{
    public void  UnlockSwiping()
    {
        CWorld.Instance.Player.CanSwipe = true;
    }
    public void OnPlayerHit()
    {
        CWorld.Instance.Player.Animator.SetTrigger("OnHit");
        CWorld.Instance.SceneManager.StartLoad(true, false);
    }
    public void OnEnemyHit()
    {
        CWorld.Instance.Player.CurrentEnemy.Animator.SetTrigger("OnHit");
        CWorld.Instance.Player.CanMove = true;

        CWorld.Instance.Player.DefeatedEnemyCount++;
        CWorld.Instance.Player.Level += CWorld.Instance.Player.CurrentEnemy.Level;
        CManager_UI.Instance.SetCollectableCount(CWorld.Instance.Player.Level   );
        CWorld.Instance.Player.UpdateLevelText();
    }
    public void LoadLevel()
    {
        if(CWorld.Instance.TargetCollectableCount > CWorld.Instance.Player.Level) CWorld.Instance.SceneManager.StartLoad(true);
        else CWorld.Instance.SceneManager.StartLoad();
    }
}
