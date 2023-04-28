using System;
using UnityEngine;

namespace SCA
{
    // Presenter
    // Presenter can depend on Usecase through its interface
    // Presenter canÅft dependent on View, Gateway
    // Presenter can inherit Monobehaviour
    public class CountPresenter : MonoBehaviour, ICountPresenter
    {
        public void AddListnerOnCountChanged(Action<int, CountType> listener)
        {
            // You may need to consider removing handler
            _usecase.OnCountChanged += new EventHandler<CounterEventArgs>(delegate (object sender, CounterEventArgs event_arg)
            {
                listener(event_arg.Count, event_arg.Type);
            });
        }

        private ICounterUsecase _usecase;

        void Awake()
        {
            _usecase = CounterDI.CounterUsecase;
        }

        public void IncrementCount(CountType type)
        {
            _usecase.IncrementCount(type);
        }

        public int GetCount(CountType type)
        {
            return _usecase.GetCount(type);
        }
    }
}