using UnityEngine;

[CreateAssetMenu(fileName = "strVal", menuName = "Values/String")]
public class StringValue : ScriptableObject
{
    public string DefaultValue;
    public string value;
    public string GetValue()
    {
        return value;
    }
    public void SetValue(string _value)
    {
        value = _value;
    }
}
