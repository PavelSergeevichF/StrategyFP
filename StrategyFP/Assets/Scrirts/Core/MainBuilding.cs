using UnityEngine;
using Abstractions;
using UnityEngine.UI;

namespace UserControlSystem
{
    public sealed class MainBuilding : MonoBehaviour, IUnitProducer, ISelectable
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _health = 1000;
        [SerializeField] private Sprite _icon;
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
        [SerializeField] private GameObject _unitPrefab;
        [SerializeField] private Transform _unitsParent;
        [SerializeField] private SelectableValue _selectableValue;

        void Start()
        {
            _selectableValue.NewValue += ONSelected;
            ONSelected(_selectableValue.CurrentValue);
        }
        private void ONSelected(ISelectable selected)
        {
            ProduceUnit();
        }
        public void ProduceUnit()
        {
            Instantiate(_unitPrefab,
                new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)),
                Quaternion.identity, _unitsParent);
            //this.transform.gameObject.GetComponent<Outline>().Activity(true);
        }
    }
}