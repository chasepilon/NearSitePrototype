using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitchLock : MonoBehaviour
{
    public bool setAllSwitches;
    public GameObject door;
    public SwitchController[] switches;
    
    void Update()
    {
        door.SetActive(!AreAllSwitchesActive());

        if(setAllSwitches)
        {
            foreach (var doorSwitch in switches)
            {
                doorSwitch.SetSwitchStatus(setAllSwitches);
            }
        }
    }

    bool AreAllSwitchesActive()
    {
        foreach (var doorSwitch in switches)
        {
            if (doorSwitch.GetSwitchStatus()) continue;
            else return false;
        }

        return true;
    }
}
