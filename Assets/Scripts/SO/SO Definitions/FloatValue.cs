using UnityEngine;

[CreateAssetMenu(fileName = "floatVal", menuName = "Values/Float")]
public class FloatValue : ScriptableObject
{
    public float DefaultValue;
    public float value;
    public float GetValue()
    {
        return value;
    }
    public void SetValue(float _value)
    {
        value = _value;
    }
}
