using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string id;
    public int scene;
    public bool chickTouch=false;
    void Update()
    {
        OpenDoor();
    }

     private void OnTriggerStay2D(Collider2D player)
     {
        chickTouch = true;
     }

    private void OnTriggerExit2D(Collider2D collision)
    {
        chickTouch = false;
    }




    void OpenDoor()
    {
        if (Input.GetKeyDown(KeyCode.A)&&chickTouch == true)
        {
            GameData.PrevEntranceId = id;
            SceneManager.LoadScene(scene);
            StartCoroutine("OpenDoorMusic");

        }
    }
    IEnumerator OpenDoorMusic()
    {
        yield return new WaitForSeconds(2f);
        SoundManger.soundIndtance.OpenDoorAudio();
    }

    public Vector3 GetFrontPosition()
    {
        return transform.GetChild(0).position;
    }
    

}
