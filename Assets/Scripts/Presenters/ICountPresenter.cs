using System;
namespace SCA
{
    // IPresenter
    // Interface for Presenter
    public interface ICountPresenter
    {
        void AddListnerOnCountChanged(Action<int, CountType> listener);
        int GetCount(CountType type);
        void IncrementCount(CountType type);
    }
}