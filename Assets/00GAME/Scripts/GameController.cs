using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HuynnLib;

public class GameController : Singleton<GameController>
{
    

    [SerializeField] PlayerController _player;
    public PlayerController Player {

        get {
            if (_player == null)
                _player = FindObjectOfType<PlayerController>();

            return _player;
        }
    }

    [SerializeField]
    float _timer = 0;

    GAMESTATE _gameState = GAMESTATE.Init;

    public GAMESTATE GameState => _gameState;

    void StartGamePlay(object data) {
        _timer = 0;
        _gameState = GAMESTATE.Play;
    }

    void InitLevel(object data) {
        _gameState = GAMESTATE.Init;
        _timer = 0;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        Observer.Instant.AddListener(Observer.GAME_START, StartGamePlay);
        Observer.Instant.AddListener(Observer.INIT_LEVEL, InitLevel);

        InitLevel(null);
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameState != GAMESTATE.Play)
            return;

        if (_timer < 10)
            _timer += Time.deltaTime;
        else
        {
            _timer = 10;
            _gameState = GAMESTATE.Over;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Observer.Instant.Notify(Observer.INIT_LEVEL);
            SceneManager.LoadScene(0);
        }
    }

    private void OnDestroy()
    {
        Observer.Instant.RemoveListener(Observer.GAME_START, StartGamePlay);
        Observer.Instant.RemoveListener(Observer.INIT_LEVEL, InitLevel);
    }

    public enum GAMESTATE {
        Init,
        Play,
        Over
    }
}
