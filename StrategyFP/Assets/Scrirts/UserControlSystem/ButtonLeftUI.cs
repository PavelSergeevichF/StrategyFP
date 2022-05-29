using Abstractions;
using UnityEngine;
using UnityEngine.UI;

namespace UserControlSystem
{
    public class ButtonLeftUI : MonoBehaviour
    {
        [SerializeField] private Image _selectedImage;
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private Text _text;
        [SerializeField] private Image _sliderBeckground;
        [SerializeField] private Image _sliderFillImage;
        [SerializeField] private SelectableValue _selectableValue;

        void Start()
        {
            _selectableValue.OnSelected += ONSelected;
            ONSelected(_selectableValue.CurrentValue);
        }
        private void ONSelected(ISelectable selected)
        {
            _selectedImage.enabled = selected != null;
            _healthSlider.gameObject.SetActive(selected!= null);
            _text.enabled = selected != null;

            if(selected != null)
            {
                _selectedImage.sprite = selected.Icon;
                _text.text = $"{selected.Health}/{selected.MaxHealth}";
                _healthSlider.minValue = 0;
                _healthSlider.minValue = selected.MaxHealth;
                _healthSlider.value = selected.Health;
                var color = Color.Lerp(Color.red, Color.green, selected.Health / selected.MaxHealth);
                _sliderBeckground.color = color * 0.5f;
                _sliderFillImage.color = color;
            }
        }
    }
}