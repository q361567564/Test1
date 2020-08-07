using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnStartGame()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    public void OnExitGame()
    {
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;

        Debug.Log("编辑状态游戏退出");

#else

            Application.Quit();

            Debug.Log ("游戏退出"):

#endif
    }
}
