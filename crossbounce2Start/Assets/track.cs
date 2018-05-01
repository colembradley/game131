using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class track : MonoBehaviour {

    public bool useTrack = false;
    public float moveSpeed = 1.0f;

    public Transform startPoint;
    public Transform endPoint;

    private Vector3 startPointPos;

    public void Move(Vector3 moveby)
    {
        transform.position += moveby;
    }

    public void Rotate(float angle)
    {
        transform.rotation *= Quaternion.Euler(0f, 0f, angle);
    }

    public void Scale(Vector3 scale)
    {
        transform.localScale += scale;
    }
}
