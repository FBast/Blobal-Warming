using UnityEngine;
using Architecture.Decouplage.SOReferences;
namespace Production.Plugins {
    /// <summary>
    /// Variable Class.
    /// </summary>
    public class Variable<T> : ScriptableObject
    {
        public T Value;

        public void SetValue(T value)
        {
            Value = value;
        }

        public void SetValue(Variable<T> value)
        {
            Value = value.Value;
        }
    }
}