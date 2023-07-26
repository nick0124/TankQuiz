using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _game;
    [SerializeField] private GameObject _finish;

    public void OpenMainMenu()
    {
        _mainMenu.SetActive(true);
        _game.SetActive(false);
        _finish.SetActive(false);
    }

    public void OpenGame()
    {
        _mainMenu.SetActive(false);
        _game.SetActive(true);
        _finish.SetActive(false);
    }

    public void OpenFinish()
    {
        _mainMenu.SetActive(false);
        _game.SetActive(false);
        _finish.SetActive(true);
    }
}
