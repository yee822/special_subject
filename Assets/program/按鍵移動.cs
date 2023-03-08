using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class 按鍵移動 : MonoBehaviour
{
    [SerializeField] private UnityEvent onStart;
    void Start()
    {
        this.onStart.Invoke();
    }
}
