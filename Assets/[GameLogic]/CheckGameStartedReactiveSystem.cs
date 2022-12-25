using Entitas;
using System.Collections.Generic;

public class CheckGameStartedReactiveSystem : ReactiveSystem<StateEntity>
{
    private Contexts _contexts;

    public CheckGameStartedReactiveSystem(Contexts contexts) : base(contexts.state)
    {
        _contexts = contexts;
    }

    protected override ICollector<StateEntity> GetTrigger(IContext<StateEntity> context)
    {
        return context.CreateCollector(
            StateMatcher.Loading.Added(),
            StateMatcher.MainMenu.Added(),
            StateMatcher.Game.Added(),
            StateMatcher.Victory.Added(),
            StateMatcher.Defeat.Added(),
            StateMatcher.Restart.Added(),
            StateMatcher.CompleteLevel.Added());
    }

    protected override bool Filter(StateEntity entity)
    {
        return true;
    }

    protected override void Execute(List<StateEntity> entities)
    {
        foreach (var entity in entities)
        {
            _contexts.game.currentGameEntity.isGameStarted = entity.transitionGame;
        }
    }
}