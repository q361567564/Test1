using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PaoTaiData 
{
    public GameObject PaoTaiPrefab;
    public int cost;
    public GameObject PaoTaiUpPrefab;
    public int costUp;
    public PaoTaiType type; 
}
public enum PaoTaiType
{
    LaserPao,
    MissilePao,
    StandardPao
}
