using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToScreen : MonoBehaviour
{
    public void move(float X)
    {
        transform.position = new Vector3(X, 0, 0);
    }
}
