namespace RoutinePanel.State
{
    internal class StateManager<T>
    {
        private List<Observer<T>> observers;
        private T value;

        public StateManager(List<Observer<T>> observers, T defaultData)
        {
            this.observers = observers;
            Update(defaultData);
        }

        public void Observe(Action<T> OnUpdate)
        {
            observers.Add(new Observer<T>(OnUpdate));
        }

        public void Update(T newData)
        {
            value = newData;
            foreach(Observer<T> observer in observers)
            {
                observer.Update(value);
            }
        }

        public T GetValue()
        {
            return value;
        }
    }

    internal class Observer<T>
    {
        private Action<T> OnUpdate;

        public Observer(Action<T> onUpdate)
        {
            OnUpdate = onUpdate;
        }

        public void Update(T newData)
        {
            OnUpdate(newData);
        }
    }
}
