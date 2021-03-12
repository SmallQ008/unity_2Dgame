
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("等級")]
   public int lv=1;
    [Header ("移動速度"), Range (0 , 300)]
    public float speed = 10.5f;
    public bool isDead = false;
    [Tooltip("這是角色的名稱")]
    public string cName = "貓咪";

}
