using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    PlayerController _playerController;
    GameManager _gameManager;

    float _currentEnergy;

    private void Start()
    {
       SetAllValues();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Ground") && _playerController != null)
            _playerController.SetGround(true);
    }

    void Update()
    {
        if (_gameManager == null || _playerController == null)
            SetAllValues();

        if (transform.position.y < -5f)
        {
            _playerController.SetGameOver(true);

            Destroy(gameObject);
        }

        if (_gameManager.Energy <= 0)
        {
            _playerController.SetGotEnergy(false);
        }

        UpdateStatsText();
    }

    void UpdateStatsText()
    {
        var tempCurrentEnergy = _gameManager.Energy;


        if (tempCurrentEnergy >= _currentEnergy / 2)
            _gameManager.EnergyText.color = Color.green;
        else if (tempCurrentEnergy <= _currentEnergy / 2 && tempCurrentEnergy >= _currentEnergy / 3)
            _gameManager.EnergyText.color = Color.yellow;
        else
            _gameManager.EnergyText.color = Color.red;

        _gameManager.LivesText.text = $"Lives: {_gameManager.Lives}";
        _gameManager.EnergyText.text = $"Energy: {_gameManager.Energy:######.##} points";
    }

    void SetAllValues()
    {
         _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _playerController = GameObject.FindGameObjectWithTag("Pivot").GetComponent<PlayerController>();
        _currentEnergy = _gameManager.CurrentEnergy;
    }
}
