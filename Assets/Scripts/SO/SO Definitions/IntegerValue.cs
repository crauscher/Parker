using UnityEngine;

[CreateAssetMenu(fileName = "intVal", menuName = "Values/Integer")]
public class IntegerValue : ScriptableObject
{
    public int DefaultValue;
    public int value;
    public int GetValue()
    {
        return value;
    }
    public void SetValue(int _value)
    {
        value = _value;
    }
}
