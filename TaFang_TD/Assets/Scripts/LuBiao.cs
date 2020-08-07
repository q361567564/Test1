using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LuBiao : MonoBehaviour
{
    public static Transform[] positions;
    private void Awake()
    {
        positions = new Transform[transform.childCount];
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = transform.GetChild(i);
        }
    }
}
    