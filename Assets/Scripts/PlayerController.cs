using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rb;
    Vector3 _cameraOffset;
    GameObject _player;
    GameObject _pivot;
    bool _isGround;
    bool _isGameOver;
    bool _gotEnergy;
    RespownPoint _respawn;

    GameManager _gameManager;

    [SerializeField] float speed = 15f;
    [SerializeField] float jumpForce = 20000f;
    [SerializeField] [Range(0.1f, 15f)] float rotationSpeed; //The speed by which the camera rotates when orbiting

    public void SetGround(bool isGround)
    {
        _isGround = isGround;
    }

    public void SetGameOver(bool gameOver)
    {
        _isGameOver = gameOver;
    }

    public void SetGotEnergy(bool gotEnergy)
    {
        _gotEnergy = gotEnergy;
    }

    void Start()
    {
        _respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespownPoint>();

        _respawn.Spawn();

        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _gameManager.GameOverPanel.SetActive(false);

        _pivot = GameObject.FindWithTag("Pivot");
        _player = GameObject.FindWithTag("Player");
        _rb = _player.GetComponent<Rigidbody>();

        _cameraOffset = _pivot.transform.position - _player.transform.position;

        transform.LookAt(_player.transform);

        _rb.Sleep();

        _isGround = true;
        _gotEnergy = true;
    }

    void FixedUpdate()
    {
        if (!_isGameOver && _gotEnergy)
        {
            if (_player != null)
            {
                Movement();

                OrbitCamera();

                // Ball follow code
                transform.position = _player.transform.position + _cameraOffset;
            }
            else
            {
                _player = GameObject.FindWithTag("Player");
                _rb = _player.GetComponent<Rigidbody>();
            }
        }
        else if (!_gotEnergy && !_isGameOver)
        {
            // TODO: Freeze postion
            _rb.velocity = Vector3.zero;
        }

        else if (_isGameOver && _gameManager.Lives > 0)
        {
            _gameManager.Lives--;
            _respawn.Spawn();
            _isGameOver = false;
            _isGround = true;
        }
        else if (_isGameOver && _gameManager.Lives <= 0)
        {
            // TODO: Game over logic
            Text levelResultText = _gameManager.GameOverPanel.transform.GetChild(0).gameObject.GetComponent<Text>();
            levelResultText.text = "YOU       LOOSE!";
            levelResultText.color = Color.red;
            _gameManager.GameOverPanel.SetActive(true);
        }
    }

    
    private void Update()
    {
        // Temp testin only method !DELETE THIS BEFOR REALESE!
        if (Input.GetKeyDown(KeyCode.T))
        {
            var portal = GameObject.Find("Portal");

            if (portal != null)
            {
                _player.transform.position = portal.transform.position;
            }
        }

        // This normal code, DO NOT DELETE
        if (Input.GetKeyDown(KeyCode.P))
        {
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            _gameManager.Energy -= _gameManager.StopEnergyPrice;
        }
    }

    //Method to handle Orbit of the Camera
    private void OrbitCamera()
    {
        //If the player holds the selected mouse button
        if (Input.GetKey(KeyCode.D))
        {
            //We cache the mouse rotation values multiplied by the rotation speed
            float y_rotate = 1 * rotationSpeed;
            float x_rotate = 0 * rotationSpeed;

            //We calculate the rotation angles based on the cached values and a specific axes
            Quaternion xAngle = Quaternion.AngleAxis(y_rotate, Vector3.up);
            Quaternion yAngle = Quaternion.AngleAxis(x_rotate, Vector3.left);

            //We multiply the rotation angle by the camera offset 
            _cameraOffset = xAngle * _cameraOffset;
            _cameraOffset = yAngle * _cameraOffset;

            //We make our transform to "look" at the target		
            transform.LookAt(_player.transform);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //We cache the mouse rotation values multiplied by the rotation speed
            float y_rotate = -1 * rotationSpeed;
            float x_rotate = 0 * rotationSpeed;

            //We calculate the rotation angles based on the cached values and a specific axes
            Quaternion xAngle = Quaternion.AngleAxis(y_rotate, Vector3.up);
            Quaternion yAngle = Quaternion.AngleAxis(x_rotate, Vector3.left);

            //We multiply the rotation angle by the camera offset 
            _cameraOffset = xAngle * _cameraOffset;
            _cameraOffset = yAngle * _cameraOffset;

            //We make our transform to "look" at the target		
            transform.LookAt(_player.transform);
        }
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            var v = 1f;
            var move = new Vector3(0, 0, v) * speed * Time.fixedDeltaTime;

            // Convert from local to world coordinates
            var moveTransform = transform.TransformDirection(move);
            _rb.AddForce(moveTransform, ForceMode.VelocityChange);

            // Decrese energy
            _gameManager.Energy -= _gameManager.MoveEnergyPrice;
        }

        if (Input.GetKey(KeyCode.S))
        {
            var v = -1f;

            var move = new Vector3(0, 0, v) * speed * Time.fixedDeltaTime;

            var moveTransform = transform.TransformDirection(move);
            _rb.AddForce(moveTransform, ForceMode.VelocityChange);

            // Decrese energy
            _gameManager.Energy -= _gameManager.MoveEnergyPrice;
        }

        if (Input.GetKey(KeyCode.Space) && _isGround)
        {
            _isGround = false;
            _rb.AddForce(Vector3.up * jumpForce * Time.fixedDeltaTime);
        }
    }
}
