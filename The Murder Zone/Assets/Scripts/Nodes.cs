﻿using UnityEngine;

public class Nodes : MonoBehaviour
{
    public static Transform[] nodes;

    void Awake()
    {
        nodes = new Transform[transform.childCount];
        for (int i = 0; i < nodes.Length; i++)
        {
            nodes[i] = transform.GetChild(i);
        }
    }
}
