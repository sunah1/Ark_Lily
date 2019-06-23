using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardingObject_Base : MonoBehaviour
{
    [Tooltip("비어있을 경우 Main Camera 이용")]
    public Transform Target;
    public bool ReverseX = false;
    public bool DisableX = false;


    private void Awake()
    {
        if (!Target)
            Target = Camera.main.transform;
    }

    private void LateUpdate()
    {
        Vector3 OrigRot = transform.localRotation.eulerAngles;
        transform.LookAt(Target);
        Vector3 ChgRot = transform.localRotation.eulerAngles;
        if (DisableX)
            ChgRot.x = 0;
        if (ReverseX)
            ChgRot.y += 180;
        transform.localRotation = Quaternion.Euler(ChgRot.x, ChgRot.y, ChgRot.z);
    }
}
