using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public  class  Game_Manager : MonoBehaviour
{
    //结束界面
    public GameObject endUI;

    public  Text endMessage;
    public static Game_Manager instance;
    private Guai_Creat guai_Creat;
    
    private void Awake()
    {
        instance = this;
        guai_Creat = GetComponent<Guai_Creat>();
    }
    public void Win()
    {
        endUI.SetActive(true);
        endMessage.text = "胜     利";
    }
    public void Failed()
    {
        guai_Creat.Stop();
        endUI.SetActive(true);
        endMessage.text = "失     败";
        
    }
    //重新开始
    public void onButtonRetry()
    {
        //重新加载当前场景
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //返回菜单
    public void onButtonCaiDan()
    {
        SceneManager.LoadScene(0);
    }
}
