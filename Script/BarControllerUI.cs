using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace BarShadersUI.Script
{
    public class BarControllerUI : MonoBehaviour
    {
        [SerializeField, Range(0, 1f)] private float FilledTest = 0;
        [SerializeField] private Color color;
        [SerializeField] private Color colorBG;
        [SerializeField] private Color colorFilled;
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
            barMaterialUI.SetValues(color, divisionSize, divisionCount, tiltAngle, margin);
            barBgMaterialUI.SetValues(colorBG, tiltAngle, margin);
            barFilledMaterialUI.SetValues(colorFilled, tiltAngle, margin);
        }

        public void SetFilled(float val)
        {
            float divSize = (divisionSize * 0.001f);
            filledImage.fillAmount = margin + divSize + val * (1 - (margin + divSize) * 2);
        }
    }
}