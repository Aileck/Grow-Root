using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularBehaivour : MonoBehaviour
{
    private float RotateSpeed = 2.0f;
    private float Radius = 4.0f;
    public Vector2 _centre;
    private float _angle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;
    }
}
