using FreeView.Views;
using FreeView.Views.Attributes;
using Sample.Scripts.ViewModels;
using UnityEngine.UI;

namespace Sample.Scripts.Views
{
    [ViewPresentation(CanvasContainerName = "MainCanvas")]
    public class WinScreenView : BaseView<WinScreenViewModel>
    {
        private Button _resetButton;
        
        protected override void OnViewAwake()
        {
            base.OnViewAwake();

            _resetButton = GetElementComponent<Button>("_resetButton");
        }

        protected override void OnViewEnable()
        {
            base.OnViewEnable();
            _resetButton?.onClick.AddListener(OnResetClicked);
        }
        
        protected override void OnViewDisable()
        {
            _resetButton?.onClick.RemoveListener(OnResetClicked);
            base.OnViewDisable();
        }
        
        private void OnResetClicked()
        {
            ViewModel.Reset();
        }
    }
}