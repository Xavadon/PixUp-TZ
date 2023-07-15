public interface IGameStateCommandsListener<TCommand> where TCommand : IGameStateCommand
{
    void ReactCommand(TCommand command);
}
