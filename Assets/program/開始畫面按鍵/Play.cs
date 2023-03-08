using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Play : MonoBehaviour
{
    public int scene;
    public GameObject MenuUI , PlayUI,PlayerButtom,BGMButtom,SettingButtom;
    // Start is called before the first frame update
    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(PlayerButtom);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(scene);
    }


    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();

    }
    public void Setting()
    {
        MenuUI.SetActive(true);
        PlayUI.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(BGMButtom);

    }
    public void Back()
    {
        MenuUI.SetActive(false);
        PlayUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(SettingButtom);
    }
}
