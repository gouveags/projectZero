using UnityEngine;

public class ItemDropManager : MonoBehaviour
{
    public GameObject[] dropItems;
    public float dropChance = 0.5f;
    public GameObject GetRandomDropItem()
    {
        if (dropItems.Length > 0 && Random.value <= dropChance)
        {
            int randomIndex = Random.Range(0, dropItems.Length);
            return dropItems[randomIndex];
        }
        else
        {
            return null;
        }
    }
}


