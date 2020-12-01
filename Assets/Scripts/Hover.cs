using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    [SerializeField] float hoverSpeed = 1f;
    float _yPos = 0;

    private void Start() => _yPos = transform.position.y;

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos = new Vector3(pos.x, _yPos + Mathf.Sin(Time.time * hoverSpeed) * 0.5f, pos.z);
        transform.position = pos;
    }
}
