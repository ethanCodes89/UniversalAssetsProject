using System;
using UnityEngine;

[Serializable]
public class SerializeTransform
{
    public float[] position = new float[3];
    public float[] rotation = new float[4];
    public float[] scale = new float[3];

    public SerializeTransform(Transform transform)
    {
        position[0] = transform.localPosition.x;
        position[1] = transform.localPosition.y;
        position[2] = transform.localPosition.z;

        rotation[0] = transform.localRotation.w;
        rotation[1] = transform.localRotation.x;
        rotation[2] = transform.localRotation.y;
        rotation[3] = transform.localRotation.z;

        scale[0] = transform.localScale.x;
        scale[1] = transform.localScale.y;
        scale[2] = transform.localScale.z;
    }
}
