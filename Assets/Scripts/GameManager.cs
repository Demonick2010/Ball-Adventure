using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Variables
    [SerializeField] GameObject _respawnPoint;
    [SerializeField] GameObject _playerPrefab;
    [SerializeField] GameObject _pivotPrefab;
    [SerializeField] List<GameObject> _bonusList;

    // Player stats
    [SerializeField] int _points;
    [SerializeField] float _energy;
    [SerializeField] int _lives;
    [SerializeField] [Range(0.01f, 15f)] float _moveEnergyPrice;
    [SerializeField] [Range(0.01f, 50f)] float _stopEnergyPrice;
    [SerializeField] bool _levelKey = false;

    // UI
    [SerializeField] Text _livesText;
    [SerializeField] Text _energyText;
    [SerializeField] Text _messageText;
    [SerializeField] GameObject _gameOverPanel;

    // Info variables
    public float CurrentEnergy { get; private set; }

    void Start()
    {
        CurrentEnergy = Energy;
    }

    #region Get and Set Methods

    public GameObject RespawnPoint
    {
        get => _respawnPoint;
        set => _respawnPoint = value;
    }

    public GameObject PlayerPrefab
    {
        get => _playerPrefab;
        set => _playerPrefab = value;
    }

    public GameObject PivotPrefab
    {
        get => _pivotPrefab;
        set => _pivotPrefab = value;
    }

    public List<GameObject> BonusList
    {
        get => _bonusList;
        set => _bonusList = value;
    }

    public int Points
    {
        get => _points;
        set => _points = value;
    }

    public float Energy
    {
        get => _energy;
        set => _energy = value;
    }

    public int Lives
    {
        get => _lives;
        set => _lives = value;
    }

    public float MoveEnergyPrice
    {
        get => _moveEnergyPrice;
        set => _moveEnergyPrice = value;
    }

     public Text EnergyText
     {
        get => _energyText;
        set => _energyText = value;
     }

     public Text LivesText
     {
        get => _livesText;
        set => _livesText = value;
     }

    public Text MessageText
    {
        get => _messageText;
        set => _messageText = value;
    }

    public GameObject GameOverPanel
    {
        get => _gameOverPanel;
        set => _gameOverPanel = value;
    }

    public float StopEnergyPrice
    {
        get => _stopEnergyPrice;
        set => _stopEnergyPrice = value;
    }

    public bool LevelKey
    {
        get => _levelKey;
        set => _levelKey = value;
    }

    #endregion

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
