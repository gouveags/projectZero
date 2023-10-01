using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int life;
    public int shieldLife;
    public bool shieldActive;
    public Transform Skin;
    public Transform Cam;
    public AudioSource audioSouce;
    public AudioClip groundedSound;
    public ItemDropManager itemDropManager; // Refer�ncia ao ItemDropManager.
    private GameObject droppedItem;
    private bool hasDroppedItem = false; // Vari�vel para controlar se o item j� foi dropado.

    void Start()
    {
        itemDropManager = FindObjectOfType<ItemDropManager>();
    }

    void Update()
    {
        if (life <= 0 && !hasDroppedItem)
        {
            DropRandomItem(); // Chama a fun��o de drop apenas se o item ainda n�o tiver sido dropado.
            hasDroppedItem = true; // Marca que o item j� foi dropado.
            Destroy(gameObject, 2f);
            Skin.GetComponent<Animator>().Play("Die", -1);
            life = 0;
        }
    }

    public void PlayerDamage(int value)
    {

        if (shieldActive)
        {
           
            ShieldDamage(value);
        }
        else
        {
            life -= value;
            Skin.GetComponent<Animator>().Play("PlayerDamage", 1);
            audioSouce.PlayOneShot(groundedSound, 0.5f);
            Cam.GetComponent<Animator>().Play("CamPlayerDamage", -1);

            // Verifique se o jogador foi derrotado
            if (life <= 0)
            {
                // Implemente qualquer l�gica adicional quando o jogador for derrotado.
            }
        }
    }

    public void ActivateShield(int initialShieldLife)
    {
        shieldActive = true;
        shieldLife = initialShieldLife;
    }

    public void DeactivateShield()
    {
        shieldActive = false;
    }

    public void ShieldDamage(int damageAmount)
    {
        if (shieldActive)
        {
            
            shieldLife -= damageAmount;
            Cam.GetComponent<Animator>().Play("CamPlayerDamage", -1);


            // Verifique se o escudo foi destru�do
            if (shieldLife <= 0)
            {
                DeactivateShield();
                // Implemente qualquer l�gica adicional quando o escudo for destru�do.
            }
        }
    }

    void DropRandomItem()
    {
        if (itemDropManager != null)
        {
            droppedItem = itemDropManager.GetRandomDropItem();

            if (droppedItem != null)
            {
                Vector3 dropPosition = transform.position;
                dropPosition.y += 0.5f; // Ajuste a altura conforme necess�rio para que o item pare�a estar no corpo do jogador.
                Instantiate(droppedItem, dropPosition, Quaternion.identity);
            }
        }
    }
}
