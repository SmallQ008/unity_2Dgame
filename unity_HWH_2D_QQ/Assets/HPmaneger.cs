
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class HPmaneger : MonoBehaviour
{
    [Header("血條")]
    public Image bar;
    [Header("傷害數值")]
    public RectTransform rectDamage;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Hp">當前血量</param>
    /// <param name="HpMax">血量最大值</param>

   public void UpdateHpBar (float Hp,float HpMax)
    {
        bar.fillAmount = Hp / HpMax;
    }
    public IEnumerator ShowDamage()
    {

    }
}
