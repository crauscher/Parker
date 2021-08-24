using UnityEngine;

[CreateAssetMenu(fileName = "objVal", menuName = "Values/GameObject")]
public class ObjectValue : ScriptableObject
{
    public GameObject DefaultValue;
    public GameObject value;
    public GameObject GetValue()
    {
        return value;
    }
    public void SetValue(GameObject _value)
    {
        value = _value;
    }
}

