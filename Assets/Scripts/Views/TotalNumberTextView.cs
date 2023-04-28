using UnityEngine;
using UnityEngine.UI;

namespace SCA
{
    // View
    // View can depend on the Presenter through its interface
    // View canÅft depend on another View.
    // View can't depend on Use Case, Gateway
    // View can inherit Monobehaviour
    public class TotalNumberTextView : MonoBehaviour
    {
        private ICountPresenter _presenter;
        private Text _text;

        private void Start()
        {
            _text = GetComponent<Text>();

            _presenter = PresenterDI.CountPresenter;
            _presenter.AddListnerOnCountChanged(OnCountChanged);
        }

        private void UpdateCount()
        {
            var a = _presenter.GetCount(CountType.A);
            var b = _presenter.GetCount(CountType.B);
            var total = a + b;
            _text.text = string.Format("Total = {0}", total);
        }

        void OnCountChanged(int count, CountType type)
        {
            UpdateCount();
        }
    }
}