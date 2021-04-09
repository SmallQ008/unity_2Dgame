
using UnityEngine;

public class item : MonoBehaviour
{
    [Header("掉落物品")]
    public GameObject prop;
    [Header("掉落機率"), Range(0f, 1f)]
    public float percent = 0.7f;
public void DropProp()
    {
        float r = Random.Range(0f, 1f);
        //print("隨機值" + r);
        if (r <= percent)
        {
            Instantiate(prop,transform.position,transform.rotation);
        }
        Destroy(gameObject);
    }
}
