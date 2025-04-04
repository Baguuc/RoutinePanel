using RoutinePanel.Lib;

namespace RoutinePanel.State
{
    internal class StateManagers
    {
        public static StateManager<List<TaskModel>> TaskStateManager { get; } = new StateManager<List<TaskModel>>(
            new List<Observer<List<TaskModel>>>(),
            new List<TaskModel>()
        );
    }
}
