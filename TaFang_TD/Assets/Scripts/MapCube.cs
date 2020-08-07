using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    [HideInInspector]//使下面语句不在inspector面板显示
    public GameObject PaoTai;//保存当前cube身上的炮台
    [HideInInspector ]
    public  PaoTaiData paotaidata;
    [HideInInspector]
    public bool isUpgraded = false;//判断炮台是否升级
    public GameObject buildTeXiao;
    //创建炮台
    public void BuildPaoTai(PaoTaiData PaoTaiPrefab)
    {
        this.paotaidata = PaoTaiPrefab;
        isUpgraded = false;
         PaoTai = GameObject.Instantiate(PaoTaiPrefab.PaoTaiPrefab, transform.position, Quaternion.identity);
        GameObject teXiao = GameObject.Instantiate(buildTeXiao, transform.position, Quaternion.identity);
        Destroy(teXiao, 1.5f); 
    }
    //升级炮台
    public void UpgradePaoTai()
    {
        if (isUpgraded == true) return;
        Destroy(PaoTai);
        isUpgraded = true;
        PaoTai = GameObject.Instantiate(paotaidata.PaoTaiUpPrefab , transform.position, Quaternion.identity);
        GameObject teXiao = GameObject.Instantiate(buildTeXiao, transform.position, Quaternion.identity);
        Destroy(teXiao, 1.5f);

    }
    public void DestroyPaoTai()
    {
        Destroy(PaoTai);
        isUpgraded = false;
        PaoTai = null;
        paotaidata = null;
        GameObject teXiao = GameObject.Instantiate(buildTeXiao, transform.position, Quaternion.identity);
        Destroy(teXiao, 1.5f);
    }
    private void OnMouseEnter()
    {
        if(PaoTai==null && EventSystem.current.IsPointerOverGameObject()==false)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
    private void OnMouseExit()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
