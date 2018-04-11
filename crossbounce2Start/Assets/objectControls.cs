using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectControls : MonoBehaviour {

    public void Move(Vector3 moveby)
    {
        transform.position += moveby;
    }
}
