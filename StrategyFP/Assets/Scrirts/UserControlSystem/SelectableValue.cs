using UnityEngine;
using Abstractions;
using System;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName =nameof(SelectableValue), menuName ="Strategy/"+nameof(SelectableValue), order =0)]
    public class SelectableValue : ScriptableObject
    { 
        public ISelectable CurrentValue { get; private set; }
        public event Action<ISelectable> OnSelected;
        public void SetValue(ISelectable value)
        {
            CurrentValue = value;
            OnSelected?.Invoke(value);
        }
    }
}