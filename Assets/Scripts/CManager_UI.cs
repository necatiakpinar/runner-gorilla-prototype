using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CManager_UI : MonoBehaviour
{
    public static CManager_UI Instance;
    [SerializeField] private GameObject Panel_LevelEnding;
    [SerializeField] private TMP_Text Text_LevelEnding;

    [SerializeField] private TMP_Text Text_CollectableCount;

    private void Awake()
    {
        Instance = this;
    }
    public void ShowVictoryPanel()
    {
        Text_LevelEnding.text = "You won!";
        Panel_LevelEnding.SetActive(true);
    }
    public void ShowGameOverPanel()
    {
        Text_LevelEnding.text = "Game Over!";
        Panel_LevelEnding.SetActive(true);
    }
    public void SetCollectableCount(int P_Count)
    {
        Text_CollectableCount.text = $"{P_Count.ToString()} / {CWorld.Instance.TargetCollectableCount.ToString()}";
    }
    public void RestartLevel()
    {

    }
    public void GoToNextLevel()
    {
        
    }
}
