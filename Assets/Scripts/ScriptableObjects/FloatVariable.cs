using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFloatVariable", menuName = "Variables/Float", order = 0)]
public class FloatVariable : ScriptableObject
{

    public float Value;
    [SerializeField] float initValue;

    private void OnEnable()
    {
        Value = initValue;
    }

    public void SetValue(float f)
    {
        Value = f;
    }

    public void AddValue(float f)
    {
        Value += f; 
    }


}
