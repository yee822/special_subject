using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    //Door
    public List<Door> DoorList;
    public Compilation player;
    void Start()
    {
        DoorController();
    }

    void DoorController()//door
    {
        string eid = GameData.PrevEntranceId;
        Door door = GetDoorByID(eid);

        if (door)
        {
            Vector3 pos = door.GetFrontPosition();
            player.transform.position = pos;
        }
        Door GetDoorByID(string eid)
        {
            foreach (Door door in DoorList)
            {
                if (door.id == eid)
                {
                    return door;
                }
            }
            return null;
        }
    }
}
