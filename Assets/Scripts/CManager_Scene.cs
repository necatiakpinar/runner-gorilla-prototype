using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;


public class CManager_Scene : MonoBehaviour
{
    public float DefeatWaitTime = 5f;
    public float EndingWaitTime = 7f;

    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void StartNextLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
    public async void StartLoad(bool P_Restart = false, bool P_IsEnding = true)
    {
        if(P_IsEnding)
        {
            await Task.Delay((int)(1000 * EndingWaitTime));
            if(P_Restart) RestartLevel();
            else StartNextLevel();
        }
        else
        {
            await Task.Delay((int)(1000 * DefeatWaitTime));
            if(P_Restart) RestartLevel();
            else StartNextLevel();
        }
    }
}
