using System.Collections.Generic;
using Entitas;

public sealed class GameLoadPlayerDataCompleteReactSystem : ReactiveSystem<GameEntity>
{
    private readonly LevelContext _levelContext;

    public GameLoadPlayerDataCompleteReactSystem(IContext<GameEntity> context, LevelContext levelContext) : base(context)
    {
        _levelContext = levelContext;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.LoadingDataSuccessful.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isUserData;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        _levelContext.CreateEntity().eventLoadNextGameLevel = true;
    }
}