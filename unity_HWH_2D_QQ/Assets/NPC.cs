
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("商店介面")]
    public GameObject objShop;
    /// <summary>
    /// 1長劍
    /// 2弓箭
    /// 3斧頭
    /// </summary>
    public int indexWeapon;

    public GameObject[] objWeapon;

    private int[] priceWeapon = { 1, 2, 3 };
    private float[] attackWeapon = { 30, 50, 100 };

    private Player player;

    private void Start()
    {
        player = GameObject.Find("玩家").GetComponent<Player>();
    }

    public void OpenShop()
    {
        objShop.SetActive(true);
    }
    public void CloseShop()
    {
        objShop.SetActive(false);
    }


    public void ChooseWeapon (int choose)
    {
        indexWeapon = choose;
    }


    public void Buy()
    {
        if (player.coin >= priceWeapon [indexWeapon])
        {
            player.coin -= priceWeapon[indexWeapon];
            player.textCoin.text = "金幣:" + player.coin;

            player.attackWeapon = attackWeapon[indexWeapon];



            for (int i = 0; i < objWeapon.Length; i++)
            {
                objWeapon[i].SetActive(false);
            }

            objWeapon[indexWeapon].SetActive(true);
        }
    }

}
