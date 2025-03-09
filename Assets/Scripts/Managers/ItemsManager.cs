using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private int amount;
    [SerializeField] private float offset;
    [SerializeField] private ItemComponent[] prefabs;

    private List<ItemComponent> items = new List<ItemComponent>();
    public void Init()
    {
        CreateItems();
    }

    public void Restart()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Destroy(items[i].gameObject);
        }

        items.Clear();
        CreateItems();
    }

    private void CreateItems()
    {
        float totalWidth = (amount - 1) * offset;
        float startX = -totalWidth / 2f;

        for (int i = 0; i < amount; i++)
        {
            var p = prefabs[Random.Range(0, prefabs.Length)];
            Vector3 spawnPosition = EvaluateItemsPosition(i, startX);
            var item = Instantiate(p, spawnPosition, Quaternion.identity);
            item.Init(container);
            items.Add(item);
        }
    }
    private Vector3 EvaluateItemsPosition(int i, float startX)
    {
        return container.position + new Vector3(0, 0, startX + i * offset);
    }
}
