using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotater : MonoBehaviour
{
    [Tooltip("Set X rotation speed for the attached item")]
    public float XSpeed = 0.0f;
    [Tooltip("Set Y rotation speed for the attached item")]
    public float YSpeed = 0.1f;
    [Tooltip("Set Z rotation speed for the attached item")]
    public float ZSpeed = 0.0f;
    [Tooltip("GameObject that will be impacted by this script")]
    public Transform item;

    // Update is called once per frame
    void Update()
    {
        item.transform.Rotate(XSpeed, YSpeed, ZSpeed, Space.Self);
    }
}
