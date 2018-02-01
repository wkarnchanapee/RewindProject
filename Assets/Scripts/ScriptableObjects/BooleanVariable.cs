using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBooleanVariable", menuName = "Variables/Boolean", order = 1)]
public class BooleanVariable : ScriptableObject {

    public bool Value;
    [SerializeField] bool initValue;

    private void OnEnable()
    {
        Value = initValue;
    }

    public void SetValue(bool v)
    {
        Value = v;
    }

    public void FlipValue()
    {
        Value = !Value;
    }

}
