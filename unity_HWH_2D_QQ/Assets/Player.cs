
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("等級")]
   public int lv=1;
    [Header ("移動速度"), Range (0 , 300)]
    public float speed = 10.5f;
    [Header("角色是否死亡")]
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
    [Header("血量")]
    public float hp = 200;
    private float hpMax;
    [Header("血量系統")]
    public HPmaneger hpManager;
    [Header("攻擊力"), Range(0, 1000)]
    public float attack = 20;
    [Header("等級文字")]
    public Text textLv;
    

    private float HpMax;



    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.2f);
        Gizmos.DrawSphere(transform.position, rangeAttack);
    }
    private void Move()
    {
        if (isDead)return;
       // print("移動");
        float h = joystick.Horizontal;
        //print("水平:" + h);
        float v = joystick.Vertical;
        //print("垂直:" + v);

        tra.Translate(h*speed*Time.deltaTime, v*speed*Time.deltaTime, 0);
        ani.SetFloat("水平", h);
        ani.SetFloat("垂直", v);
    }
    public void Attack()
    {
        if (isDead) return;
        print("攻擊");
        //2D 物理圓形碰撞(中心點, 半徑,方向)
        RaycastHit2D hit =Physics2D.CircleCast(transform.position, rangeAttack, transform.up,0,1<<8 );
        print("碰到的物件:" + hit.collider.name);
        aud.PlayOneShot(soundAttack, 0.5f);

        if (hit && hit.collider.tag == "道具") hit.collider.GetComponent<item>().DropProp();
        if (hit && hit.collider.tag == "敵人") hit.collider.GetComponent<Enemy>().Hit(attack);
    }
    public void Hit(float damage)
    {
        hp -= damage;
        hpManager.UpdateHpBar(hp, hpMax);
        StartCoroutine(hpManager.ShowDamage(damage));
        if (hp <= 0) Dead();
    }
    private void Dead()
    {
        hp = 0;
        isDead = true;
        Invoke("Replay", 2);

    }
    private void Replay()
    {
        SceneManager.LoadScene("2Dqq");
    }
    private void Start()
    {
        hpMax = hp;
    }

    private float exp;
    public void Exp (float getExp)
    {
        exp += getExp;
        print("經驗值:" + exp);
    }

    private void Update()
    {
        Move();
    }
    [Header("吃金幣音效")]
    public AudioClip soundEat;
    [Header("金幣數量")]
    public Text textCoin;

    private int coin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "金條")
        {
            coin++;
            aud.PlayOneShot(soundEat);
            Destroy(collision.gameObject);
            textCoin.text = "金幣:" + coin;
        }
    }
    

}
