
using UnityEngine;
using UnityEngine.UI;

public class HPmaneger : MonoBehaviour
{
    [Header("血條")]
    public Image bar;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Hp">當前血量</param>
    /// <param name="HpMax">血量最大值</param>

   public void UpdateHpBar (float Hp,float HpMax)
    {
        bar.fillAmount = Hp / HpMax;
    }
}
