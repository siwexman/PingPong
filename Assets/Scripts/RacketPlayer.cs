using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketPlayer : MonoBehaviour
{
    public float speed;
    public string axisName;

    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw(axisName);

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
    }
}
