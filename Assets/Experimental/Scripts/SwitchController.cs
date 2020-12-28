using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public GameObject player;

    bool isActive;
    AudioSource flipSwitchSound;

    private void Awake()
    {
        isActive = false;
        flipSwitchSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isActive = !isActive;
            flipSwitchSound.Play();
        }
    }

    public bool GetSwitchStatus()
    {
        return isActive;
    }

    public void SetSwitchStatus(bool status)
    {
        isActive = status;
    }
}
