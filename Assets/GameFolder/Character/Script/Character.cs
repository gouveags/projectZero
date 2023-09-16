using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int life;
    public Transform Skin;
    public Transform Cam;
    public AudioSource audioSouce;
    public AudioClip groundedSound;
    public ItemDropManager itemDropManager; // Referência ao ItemDropManager.
    private GameObject droppedItem;
    private bool hasDroppedItem = false; // Variável para controlar se o item já foi dropado.
    

    void Start()
    {
        itemDropManager = FindObjectOfType<ItemDropManager>();
    }

    void Update()
    {
        

     if (life <= 0 && !hasDroppedItem)
        {
            
            DropRandomItem(); // Chama a função de drop apenas se o item ainda não tiver sido dropado.
            hasDroppedItem = true; // Marca que o item já foi dropado.
            Destroy(gameObject, 2f);
            Skin.GetComponent<Animator>().Play("Die", -1);
            life = 0;
            

        }

    }

    public void PlayerDamege(int value)
    {
        life = life - value;
        Skin.GetComponent<Animator>().Play("PlayerDamage", 1);
        audioSouce.PlayOneShot(groundedSound, 0.5f);
        Cam.GetComponent<Animator>().Play("CamPlayerDamge", -1);
    }

    void DropRandomItem()
    {
        if (itemDropManager != null)
        {
            droppedItem = itemDropManager.GetRandomDropItem();

            if (droppedItem != null)
            {
                Vector3 dropPosition = transform.position;
                dropPosition.y += 0.5f; // Ajuste a altura conforme necessário para que o item pareça estar no corpo do jogador.
                Instantiate(droppedItem, dropPosition, Quaternion.identity);
            }
        }
    }
}
