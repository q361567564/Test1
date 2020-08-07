using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public PaoTaiData laserData;//低级炮台
    public PaoTaiData missileData;//中级炮台
    public PaoTaiData standardData;//高级炮台

    private PaoTaiData selectedPaoTai;//选中的炮台(UI界面的炮台)

    private MapCube selectedMapCube;//选中的炮台(建造完成在场景里的炮台)

    public GameObject SJCanvas;
    public Button buttonUp;
    public Animator moneyAnimator;
    public Text monetText;

    private int money = 1000;

    void ChangeMoney(int change = 0)
    {
        money += change;
        monetText.text = "￥" + money;
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //当UI和Cube不重合时，进行建造
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                //开发炮台的建造
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("MapCube"));
                if (isCollider)
                {
                    MapCube mapCube = hit.collider.GetComponent<MapCube>();
                    //判断cube身上有没有炮台
                    if (selectedPaoTai != null && mapCube.PaoTai == null)
                    {
                        //可以创建   
                        if (money >= selectedPaoTai.cost)
                        {
                            ChangeMoney(-selectedPaoTai.cost);
                            mapCube.BuildPaoTai(selectedPaoTai);

                        }
                        else //提示钱不够
                        {
                            moneyAnimator.SetTrigger("ShanShuo");
                        }
                    }
                    //升级处理
                    else if (mapCube.PaoTai != null)
                    {

                        //show(mapCube.transform.position, mapCube.isUpgraded);

                                                        //表示升级UI是否显示出来
                        if (mapCube == selectedMapCube && SJCanvas.activeInHierarchy)
                        {
                            Hide();
                        }
                        else
                        {
                            show(mapCube.transform.position, mapCube.isUpgraded);
                        }
                        selectedMapCube  = mapCube;

                    }
                    //GameObject mapCube = hit.collider.gameObject;//得到点击的Cube
                    //if()
                }
            }
        }
    }

    public void OnLaserSelected(bool isON)
    {
        if (isON)
        {
            selectedPaoTai = laserData;
        }
        else selectedPaoTai = null;
    }
    public void OnMissileSelected(bool isON)
    {
        if (isON)
        {
            selectedPaoTai = missileData;
        }
        else selectedPaoTai = null;
    }
    public void OnStandardSelected(bool isON)
    {
        if (isON)
        {
            selectedPaoTai = standardData;
        }
        else selectedPaoTai = null;
    }

    void show(Vector3 pos, bool isDisable = false)
    {
        //true为显示画布
        SJCanvas.SetActive(true);
        //画布显示的位置
        SJCanvas.transform.position = pos;
        //
        buttonUp.interactable = !isDisable;
    }

    void Hide()
    {
        SJCanvas.SetActive(false);
    }
    //升级炮台
    public void OnUPButtonDown()
    {
        if (money >= selectedMapCube.paotaidata.costUp)
        {
            ChangeMoney(-selectedMapCube.paotaidata.costUp);
            selectedMapCube.UpgradePaoTai();
           
        }
        else
        {
            moneyAnimator.SetTrigger("ShanShuo");
        }
         Hide();
    }
    //出售炮台
    public void OnDesButtonDown()
    {
        selectedMapCube.DestroyPaoTai();
        Hide();

    }
}
