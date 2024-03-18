using UnityEngine;
using UnityEngine.UI;

public class CharacterEnemmy : MonoBehaviour
{
    public int life;
    public int MaxLife;
    public Transform Skin;
    public Transform Camera;
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

        if (life >= MaxLife)
        {
            life = MaxLife;
        }

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

      
            life -= value;
            Skin.GetComponent<Animator>().Play("PlayerDamage", 1);
            audioSouce.PlayOneShot(groundedSound, 0.5f);
            Camera.GetComponent<Animator>().Play("CamPlayerDamage", -1);

        // Verifique se o jogador foi derrotado
        if (life <= 0)
            {
                // Implemente qualquer l�gica adicional quando o jogador for derrotado.
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
