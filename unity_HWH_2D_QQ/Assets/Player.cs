
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
    [Header("虛擬搖桿")]
    public FixedJoystick joystick;
    public Transform tra;
    public Animator ani;
    [Header("偵測範圍")]
        public float rangeAttack = 2.5f;
    [Header("音效來源")]
    public AudioSource aud;
    [Header("攻擊音效")]
    public AudioClip soundAttack;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.2f);
        Gizmos.DrawSphere(transform.position, rangeAttack);
    }
    private void Move()
    {
        print("移動");
        float h = joystick.Horizontal;
        print("水平:" + h);
        float v = joystick.Vertical;
        print("垂直:" + v);

        tra.Translate(h*speed*Time.deltaTime, v*speed*Time.deltaTime, 0);
        ani.SetFloat("水平", h);
        ani.SetFloat("垂直", v);
    }
    public void Attack()
    {
        print("攻擊");
        //2D 物理圓形碰撞(中心點, 半徑,方向)
        RaycastHit2D hit =Physics2D.CircleCast(transform.position, rangeAttack, transform.up,0,1<<8 );
        print("碰到的物件:" + hit.collider.name);
        aud.PlayOneShot(soundAttack, 0.5f);

        if (hit.collider.tag == "道具") Destroy(hit.collider.gameObject);
    }
    private void Hit()
    {

    }
    private void Dead()
    {

    }
    private void Start()
    {
        Move();
    }

    private void Update()
    {
        Move();
    }


}
