using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum EBuffType
{
    ADDITION,
    MULTIPLICATION
};
public class CBuffObject : MonoBehaviour
{
    public EBuffType BuffType;
    public int BuffAmount;
    public TMP_Text Text_Buff;

    private void Awake()
    {
        Text_Buff.text = (BuffType == EBuffType.MULTIPLICATION) ? "x" + BuffAmount.ToString() : "+" + BuffAmount.ToString();
    }
}
