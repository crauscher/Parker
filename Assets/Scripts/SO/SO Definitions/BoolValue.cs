using UnityEngine;

[CreateAssetMenu(fileName = "boolVal", menuName = "Values/Boolean")]
public class BoolValue : ScriptableObject
{
    public bool DefaultValue;
    public bool value;
    public bool GetValue()
    {
        return value;
    }
    public void SetValue(bool _value)
    {
        value = _value;
    }
}
