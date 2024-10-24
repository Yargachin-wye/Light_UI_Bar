using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace BarShadersUI.Script
{
    public class BarControllerUI : MonoBehaviour
    {
        [SerializeField, Range(0, 1f)] private float FilledTest = 0;
        [SerializeField] private Color frameColor;
        [SerializeField] private Color BGColor;
        [SerializeField] private Color filledColor;
        [SerializeField, Range(0, 1f)] private float divisionSize;
        [SerializeField, Range(0, 100)] private int divisionCount;
        [SerializeField, Range(-30, 30)] private float tiltAngle;
        [SerializeField, Range(0, 0.5f)] private float margin;
        [SerializeField] private Image filledImage;

        [SerializeField] private BarBgMaterialUI barBgMaterialUI;
        [SerializeField] private BarBgMaterialUI barFilledMaterialUI;
        [SerializeField] private BarMaterialUI barMaterialUI;

        private void OnValidate()
        {
            Validate();
            SetFilled(FilledTest);
        }

        [ContextMenu("<-> Validate")]
        private void Validate()
        {
            barMaterialUI.Validate();
            barBgMaterialUI.Validate();
            barFilledMaterialUI.Validate();
            Init();
        }

        private void Init()
        {
            barMaterialUI.SetValues(frameColor, divisionSize, divisionCount, tiltAngle, margin);
            barBgMaterialUI.SetValues(BGColor, tiltAngle, margin);
            barFilledMaterialUI.SetValues(filledColor, tiltAngle, margin);
        }
        /// <summary>
        /// Устанавливает уровень заполнения изображения на основе переданного значения.
        /// </summary>
        /// <param name="val">Значение, определяющее уровень заполнения изображения. Должно быть в диапазоне от 0 до 1.</param>
        public void SetFilled(float val)
        {
            float divSize = (divisionSize * 0.001f);
            filledImage.fillAmount = margin + divSize + val * (1 - (margin + divSize) * 2);
        }
    }
}