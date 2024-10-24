using UnityEngine;
using UnityEngine.UI;

namespace BarShadersUI.Script
{
    public class BarBgMaterialUI : MonoBehaviour
    {
        [SerializeField, HideInInspector] private Image image;
        [SerializeField] private Material material;

        public void Validate()
        {
            image = GetComponent<Image>();
            image.material = new Material(material);
        }

        public void SetValues(Color color, float tiltAngle, float margin)
        {
            image.material.SetColor("_Color", color);
            image.material.SetFloat("_TiltAngle", tiltAngle);
            image.material.SetFloat("_Margin", margin);
            image.SetMaterialDirty();
        }
    }
}