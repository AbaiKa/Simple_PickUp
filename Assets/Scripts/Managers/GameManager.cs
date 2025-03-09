using SPUPlayer;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ItemsManager itemsManager;
    [SerializeField] private Player player;

    private void Awake()
    {
        itemsManager.Init();
        player.Init();
    }

    public void Restart()
    {
        itemsManager.Restart();
        player.Restart();
    }
}
