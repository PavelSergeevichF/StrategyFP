using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem
{
    public sealed class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;

        [SerializeField] private Transform _unitsParent;
        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;
        [SerializeField] private IProduceUnitCommand _unitPrefab;
        [SerializeField] private GameObject _building;
        [SerializeField] private SelectableValue _selectableValue;

        private float _health = 1000;

        void Start()
        {
            _selectableValue.OnSelected += ONSelected;
            ONSelected(_selectableValue.CurrentValue);
        }
        private void ONSelected(ISelectable selected)
        {
            ExecuteSpecificCommand(_unitPrefab);
            _building.GetComponent<Outline>().Activity(true);
        }
        public override void ExecuteSpecificCommand(IProduceUnitCommand command)
            => Instantiate(command.UnitPrefab,
                new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)),
                Quaternion.identity,
                _unitsParent);
    }
}