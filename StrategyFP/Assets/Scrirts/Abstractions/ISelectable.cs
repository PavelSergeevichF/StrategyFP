using UnityEngine;

namespace Abstractions
{
    public interface ISelectable
    {
        public float Health { get; }
        public float MaxHealth { get; }
        public Sprite Icon { get; }
    }
}