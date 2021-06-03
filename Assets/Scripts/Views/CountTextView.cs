using UnityEngine;
using UnityEngine.UI;

namespace SCA
{
    // View
    // View can depend on the Presenter through its interface
    // View canÅft depend on another View.
    // View can't depend on Use Case, Gateway
    // View can inherit Monobehaviour
    public class CountTextView : MonoBehaviour
    {
        public CountType Type;

        private ICountPresenter _presenter;
        private Text _text;

        private void Start()
        {
            _text = GetComponent<Text>();

            _presenter = PresenterDI.CountPresenter;
            _presenter.AddListnerOnCountChanged(OnCountChanged);

            UpdateText(0); // Initialize
        }

        private void UpdateText(int count)
        {
            _text.text = string.Format("Count {0} = {1}", Type.ToString(), count);
        }

        void OnCountChanged(int new_count)
        {
            UpdateText(new_count);
        }
    }
}