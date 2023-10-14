using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider; // Referência ao Slider da barra de vida
    public Character character; // Referência ao componente Character do personagem
    public Image FillImage;
    private void Start()
    {
        // Defina o valor máximo do Slider com base no MaxLife do personagem
        healthSlider.maxValue = character.MaxLife;

        // Inicialize o valor atual do Slider com a vida inicial do personagem
        healthSlider.value = character.life;
    }

   

    private void Update()
    {
        if (healthSlider.value <= healthSlider.minValue)
        {
            FillImage.enabled = false;
        }
        if (healthSlider.value > healthSlider.minValue && !FillImage.enabled)
        {
            FillImage.enabled = false;
        }
        // Atualize o valor do Slider com a vida atual do personagem
        healthSlider.value = character.life;
    }
}
