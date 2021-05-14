
using UnityEngine;

[CreateAssetMenu(fileName = "經驗值資料",menuName = "Smallq/經驗值資料")]
public class ExpData : ScriptableObject
{
    [Header("每個等級經驗值需求，從一等開始")]
    public float [] exp;
}