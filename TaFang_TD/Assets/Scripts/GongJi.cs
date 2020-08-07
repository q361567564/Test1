using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class GongJi : MonoBehaviour
{
    public List<GameObject> guai = new List<GameObject>();
    //进入触发器 加入集合
    private void OnTriggerEnter(Collider col)
    {
        //判断带是不是有Guai标签的怪物
        if (col.tag == "Guai")
        {
            //是的话加入集合
            guai.Add(col.gameObject);
        }

    }

    //离开触发器 删除集合
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Guai")
        {
            guai.Remove(col.gameObject);
        }
    }
    //攻击速度
    public int GongJiRate = 1;
    private float timer = 1;
    //子弹初始位置
    public Transform WuQiWZ;
    //子弹
    public GameObject WuQi;
    //炮头
    public Transform Tou;

    public bool useLaser = false;
    //激光伤害
    public float shanghai = 80;

    public LineRenderer laserRender;
    List<int> kong = new List<int>();
    private void FixedUpdate()
    {

        //清楚不在射程范围之内的怪物
        if (guai.Count > 0)
        {
            //让炮台对准怪物
            if (guai[0] != null)
            {
                Vector3 targetPosition = guai[0].transform.position;
                targetPosition.y = Tou.position.y;
                Tou.LookAt(targetPosition);
            }
            UpdateGuai();

        }
        //不是激光炮台选择这种攻击方式
        if (useLaser == false)
        {
            timer += Time.deltaTime;
            if (guai.Count > 0 && timer >= GongJiRate)
            {
                
                timer = 0;
                GJ();
            }
        }
        //激光炮台的攻击方式
        else if (guai.Count > 0&&useLaser==true)
        {
            if (laserRender.enabled == false)
                laserRender.enabled = true;
            //if (guai[0] == null)
            //{
            //    UpdateGuai();
            //}
            if (guai.Count > 0)
            {
                //UpdateGuai();
                laserRender.SetPositions(new Vector3[] { WuQiWZ.position, guai[0].transform.position });
                guai[0].GetComponent<Guai_1>().BeiDa(shanghai * Time.deltaTime);
            }

        }
        //不攻击时
        else
        {
            laserRender.enabled = false;
        }
    }
    //攻击方法
    void GJ()
    {
        //if (guai[0] == null)
        //{
        //    UpdateGuai();
        //}
        //                                            让子弹旋转的位置跟武器位置一致
        GameObject ZiDan = GameObject.Instantiate(WuQi, WuQiWZ.position, WuQiWZ.rotation);
        //传入怪物位置
        ZiDan.GetComponent<ZiDanMove>().SetTarget(guai[0].transform);
        // s.SetTarget(guai[0].transform);
        // WuQi.transform.Translate(WuQiWZ.position-guai[0].transform.position.normalized*Time.deltaTime*speed);

    }
    private void UpdateGuai()
    {
        for (int i = 0; i < guai.Count; i++)
        {
            if (guai[i] == null)
            {
                kong.Add(i);
            }

        }
        for (int i = 0; i < kong.Count; i++)
        {
            guai.RemoveAt(kong[0]);
            kong.RemoveAt(0);

        }
    }

}
