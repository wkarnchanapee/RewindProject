using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyPress : MonoBehaviour {

    [SerializeField] KeyCode key;
    public UnityEvent KeypressEvent;

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            KeypressEvent.Invoke();
        }
    }
}
