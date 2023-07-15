using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckDelta : MonoBehaviour, IDragHandler
{
    [SerializeField] private UnityEngine.EventSystems.StandaloneInputModule _input;

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log(eventData.delta);
    }

}
