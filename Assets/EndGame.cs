using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public float displayThankyouSceneDelay = 1f;

    float m_Timer;

    void Update()
    {
        m_Timer += Time.deltaTime;

        if (m_Timer > displayThankyouSceneDelay)
        {
            Application.Quit();
        }
    }
}
