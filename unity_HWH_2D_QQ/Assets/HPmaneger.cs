
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
    public IEnumerator ShowDamage(float damage)
    {
        RectTransform rect = Instantiate(rectDamage, transform);
        rect.anchoredPosition = new Vector2(0, 200);
        rect.GetComponent<Text>().text = damage.ToString();

        float y = rect.anchoredPosition.y;

        while (y<400)
        {
            y += 20;
            rect.anchoredPosition = new Vector2(0, y);
            yield return new WaitForSeconds(0.02f);
        }
        Destroy(rect.gameObject, 0.5f);
    }
}
