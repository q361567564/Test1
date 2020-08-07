using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guai_Creat : MonoBehaviour
{
    public  Bo[] bo;
    public Transform STATR;
    private float meibotime=5;
    private Coroutine coroutine;
    public static int guaiAlive=0;
    public static int guaiBo = 0;
    private void Start()
    {
        guaiAlive = (bo.Length ) * 5;
        Debug.Log("怪物总数" + guaiAlive);
        coroutine = StartCoroutine(SpawnGuai());
        
       
    }
   public void Stop()
    {
        StopCoroutine(coroutine);
    }
    IEnumerator SpawnGuai()
    {
        foreach (Bo item in bo)
        {
            //guaiBo++;
            Debug.Log("当前波数" + Guai_Creat.guaiBo);
            for (int i = 0; i < item.count; i++)
            {
                //每隔多少时间创建一个怪物
                yield return new WaitForSeconds(item.rate);
                //guaiAlive++;
                //创建怪物
                GameObject.Instantiate(item.guaiPrefab, STATR.position, Quaternion.identity);
                
            }
            //每创建一波敌人等待时间
            yield return new WaitForSeconds(meibotime);
        }
     
    }
}
