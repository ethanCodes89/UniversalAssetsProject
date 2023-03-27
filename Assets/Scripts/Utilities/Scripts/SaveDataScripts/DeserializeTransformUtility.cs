using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DeserializeTransformUtility
{
    public static Transform DeserializeTransform(Transform transform, SerializeTransform serializedTransform)
    {
        transform.position.Set(serializedTransform.position[0], serializedTransform.position[1], serializedTransform.position[2]);
        transform.rotation.Set(serializedTransform.rotation[0], serializedTransform.rotation[1], serializedTransform.rotation[2], serializedTransform.rotation[3]);
        transform.localScale.Set(serializedTransform.scale[0], serializedTransform.scale[1], serializedTransform.scale[2]);
        return transform;
    }
}
