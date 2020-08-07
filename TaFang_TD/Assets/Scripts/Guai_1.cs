using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guai_1 : MonoBehaviour
{
    //血条
    private Slider hpSlider;
    //移动速度
    public float speed = 15;
    //移动坐标
    private Transform[] GuaiMove;
    private int index = 0;
    //血量
    public float hp = 200;
    private float Zhp;
    //死亡特效
    public GameObject DieTX;



    void Start()
    {

        GuaiMove = LuBiao.positions;
        Zhp = hp;
        //获得子物体下的血条  该方法可以更加方便减少拖拽，但是消耗性能
        //获取子物体下第一个slider
        hpSlider = GetComponentInChildren<Slider>();
        hpSlider.transform.Rotate(new Vector3(10, 0, 0));
        //Canvas c = GetComponentInChildren<Canvas>();
        //c.transform.Rotate(new Vector3(10, 0, 0));

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

    }
    //怪物移动
    void Move()
    {

        if (index > GuaiMove.Length - 1)
        {
            return;
        }
        transform.Translate((GuaiMove[index].position - transform.position).normalized * Time.deltaTime * speed);
        if (Vector3.Distance(GuaiMove[index].position, transform.position) < 0.2f)
        {
            index++;
        }
        //当怪物移动到终点则销毁
        if (index > GuaiMove.Length - 1)
        {
            GameObject.Destroy(this.gameObject);
            Game_Manager.instance.Failed();

        }

    }
    //被攻击时的方法
    public void BeiDa(float Xue)
    {
        if (hp <= 0) return;
        hp -= Xue;
        hpSlider.value = hp / Zhp;
        //怪物死亡
        if (hp <= 0)
        {
            Die();

            //每杀死一个怪物，怪物总数减少
            Guai_Creat.guaiAlive--;
            Debug.Log("当前存活" + Guai_Creat.guaiAlive);
            //全部杀死游戏胜利
            if (Guai_Creat.guaiAlive == 0)
            {
                Game_Manager.instance.Win();
            }
        }
    }
    //当怪兽死亡时
    void Die()
    {
        GameObject dieTx = GameObject.Instantiate(DieTX, transform.position, transform.rotation);
        Destroy(this.gameObject);
        Destroy(dieTx, 1.5f);
    }
}
