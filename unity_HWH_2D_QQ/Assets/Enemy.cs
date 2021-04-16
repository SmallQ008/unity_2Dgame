﻿using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("追蹤範圍"), Range(0, 500)]
    public float rangeTrack = 2;

    private Transform player;

    private void Start()
    {
        player = GameObject.Find("玩家").transform;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1, 0.3f);
        Gizmos.DrawSphere(transform.position, rangeTrack);
    }
    private void Update()
    {
        Track();
    }
    private void Track()
    {
        float dis =Vector3.Distance(transform.position, player.position);

        print ("距離:" + dis);
        if (dis <= rangeTrack)
        {
            print("追蹤");
        }
    }
}