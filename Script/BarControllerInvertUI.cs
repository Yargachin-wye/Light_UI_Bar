using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace BarShadersUI.Script
{
    public class BarControllerInvertUI : MonoBehaviour
    {
        [Tooltip("Для пред просмотра")] [SerializeField, Range(0, 1f)]
        private float FilledTest = 0;

        [SerializeField] private Color fillerColor;
        [SerializeField] private Color BGcolor;
        [SerializeField, Range(0, 1f)] private float divisionSize;
        [SerializeField, Range(0, 100)] private int divisionCount;

        [Tooltip("Угол наклона делений")] [SerializeField, Range(-30, 30)]
        private float tiltAngle;

        [Tooltip("Отступы по краям")] [SerializeField, Range(0, 0.5f)]
        private float margin;

        [SerializeField] private Image filledImage;
        [SerializeField] private BarMaterialUI barMaterialUI;
        [SerializeField] private BarMaterialUI barBgMaterialUI;

        private void Awake()
        {
            Init();
        }

        private void OnValidate()
        {
            Validate();
            SetFilled(FilledTest); //for preview
        }

        [ContextMenu("<-> Validate")]
        private void Validate()
        {
            barMaterialUI.Validate();
            barBgMaterialUI.Validate();
            Init();
        }

        private void Init()
        {
            barMaterialUI.SetValues(fillerColor, divisionSize, divisionCount, tiltAngle, margin);
            barBgMaterialUI.SetValues(BGcolor, divisionSize, divisionCount, tiltAngle, margin);
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