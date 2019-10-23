using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraP : MonoBehaviour
{
    public Transform target;
    Vector3 pos;
    [SerializeField]
    float first_x;
    float first_y;
    private void Awake()
    {
        pos = target.position;
        first_x = pos.x;
        first_y = pos.y;
    }


    void Update()
    {

        pos = target.position;
        pos.z = -10f;
        if (pos.x < first_x)
            pos.x = first_x;
        if (pos.y < first_y)
            pos.y = first_y;
        transform.position = Vector3.Lerp(transform.position, pos, 2f * Time.deltaTime);
    }
}
