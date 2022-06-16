using Abstractions.Commands.CommandsInterfaces;
using Zenject;
using UnityEngine;
using Utils;

namespace UserControlSystem
{
    public sealed class UIModelInstaller : MonoInstaller
    {
        [SerializeField] private AssetsContext _LegacyContext;
        [SerializeField] private Vector3Value _vector3Value;
        public override void InstallBindings()
        {
            Container.Bind<CommandCreatorBase<IProduceUnitCommand>>()
                .To<ProduceUnitCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IAttackCommand>>()
                .To<AttackCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IMoveCommand>>()
                .To<MoveCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IPatrolCommand>>()
                .To<PatrolCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IStopCommand>>()
                .To<StopCommandCommandCreator>().AsTransient();

            Container.Bind<CommandButtonsModel>().AsSingle();
        }
    }
}