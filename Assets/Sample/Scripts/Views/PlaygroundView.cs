using FreeView.Bindings;
using FreeView.Views;
using FreeView.Views.Attributes;
using Sample.Scripts.ViewModels;
using TMPro;
using UnityEngine.UI;

namespace Sample.Scripts.Views
{
    [ViewPresentation(CanvasContainerName = "MainCanvas")]
    public class PlaygroundView : BaseView<PlaygroundViewModel>
    {
        private Button _toggleDoorButton;
        private TextMeshProUGUI _doorStateText;
        
        private bool _isDoorOpened;

        public bool IsDoorOpened
        {
            get => _isDoorOpened;
            set
            {
                _isDoorOpened = value;
                _doorStateText.text = $"Door is " + (value ? "opened" : "closed");
            }
        }

        protected override void OnViewAwake()
        {
            base.OnViewAwake();

            _toggleDoorButton = GetElementComponent<Button>("_toggleDoorButton");
            _doorStateText = GetElementComponent<TextMeshProUGUI>("_doorStateText");
        }

        protected override void OnViewStart()
        {
            base.OnViewStart();
        
            var set = this.CreateBindingSet<PlaygroundView, PlaygroundViewModel>();
            set.Bind(this).For(v => v.IsDoorOpened).To(vm => vm.IsDoorOpened);
            set.Apply();
        }

        protected override void OnViewEnable()
        {
            base.OnViewEnable();
            _toggleDoorButton?.onClick.AddListener(OnToggleDoorClicked);
        }

        protected override void OnViewDisable()
        {
            _toggleDoorButton?.onClick.RemoveListener(OnToggleDoorClicked);
            base.OnViewDisable();
        }

        private void OnToggleDoorClicked()
        {
            ViewModel.ToggleDoor();
        }
    }
}