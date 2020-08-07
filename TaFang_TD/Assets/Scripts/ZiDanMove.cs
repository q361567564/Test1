using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ZiDanMove : MonoBehaviour
{
    //伤害值
    public int shangHai = 50;
    public float speed = 20;
    public GameObject BaoZhaTX;
    private Transform target;
    //得到怪物的坐标
    public void SetTarget(Transform transform)
    {
        this.target = transform;
    }
    //子弹飞向怪物
    // Update is called once per frame
    void FixedUpdate()
    {

        if (target != null)
        {
            transform.LookAt(target.position);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else
        {
            Destroy(this.gameObject);
        }
        // transform.Translate(gongJi.WuQiWZ.position - gongJi.guai[0].transform.position.normalized * Time.deltaTime * speed);

       // WuQi.transform.Translate(WuQiWZ.position-guai[0].transform.position.normalized*Time.deltaTime*speed);
    }
    //当子弹与怪物接触时销毁子弹
    private void OnTriggerEnter(Collider col)
    {
        //扣血
        if(col.tag=="Guai")
        {
            col.GetComponent<Guai_1>().BeiDa(shangHai);
            //rotation 当前旋转
            Die();

        }
    }
    void Die()
    {
        GameObject TX = GameObject.Instantiate(BaoZhaTX, transform.position, transform.rotation);
        Destroy(this.gameObject, 0.2f);
        Destroy(TX,0.2f);
    }
}
