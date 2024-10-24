using UnityEngine;
using UnityEngine.UI;

namespace BarShadersUI.Script
{
    public class BarMaterialUI : MonoBehaviour
    {
        [SerializeField, HideInInspector] private RectTransform rectTransform;
        [SerializeField, HideInInspector] private Image image;
        [SerializeField] private Material material;

        public void Validate()
        {
            rectTransform = GetComponent<RectTransform>();
            image = GetComponent<Image>();
            image.material = new Material(material);
        }

        public void SetValues(Color color, float divisionSize, int divisionCount, float tiltAngle, float margin)
        {
            image.material.SetColor("_Color", color);
            image.material.SetFloat("_DivisionCount", divisionCount);
            image.material.SetFloat("_FrameSizeX", rectTransform.rect.height * divisionSize * 0.001f);
            image.material.SetFloat("_FrameSizeY", rectTransform.rect.width * divisionSize * 0.002f);
            image.material.SetFloat("_TiltAngle", tiltAngle);
            image.material.SetFloat("_Margin", margin);

            image.SetMaterialDirty();
        }
    }
}