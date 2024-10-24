using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace BarShadersUI.Script
{
    public class BarControllerInvertUI : MonoBehaviour
    {
        [SerializeField, Range(0, 1f)] private float FilledTest = 0;
        [SerializeField] private Color color;
        [SerializeField] private Color colorBG;
        [SerializeField,Range(0, 1f)] private float divisionSize;
        [SerializeField, Range(0, 100)] private int divisionCount;
        [SerializeField, Range(-30, 30)] private float tiltAngle;
        [SerializeField, Range(0, 0.5f)] private float margin;
        [SerializeField] private Image filledImage;
        [FormerlySerializedAs("barMaterialUIController")] [SerializeField] private BarMaterialUI barMaterialUI;
        [FormerlySerializedAs("barBgMaterialUIController")] [SerializeField] private BarMaterialUI barBgMaterialUI;

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
            Init();
        }

        private void Init()
        {
            barMaterialUI.SetValues(color, divisionSize, divisionCount, tiltAngle, margin);
            barBgMaterialUI.SetValues(colorBG, divisionSize, divisionCount, tiltAngle, margin);
        }

        public void SetFilled(float val)
        {
            float rad = tiltAngle * Mathf.Deg2Rad;
            float divSize = (divisionSize * 0.001f);
            filledImage.fillAmount = margin + divSize + val * (1 - (margin + divSize) * 2);
        }
    }
}