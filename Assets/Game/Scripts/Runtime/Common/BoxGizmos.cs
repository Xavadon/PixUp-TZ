using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoxGizmos : MonoBehaviour
{
    [SerializeField] private Color _color;
    [SerializeField] private BoxCollider _boxCollider;

    public void OnDrawGizmos()
    {
        if (_boxCollider == null)
            return;

        Gizmos.color = _color;
        Gizmos.DrawCube(transform.position + _boxCollider.center, _boxCollider.size);
    }
}
