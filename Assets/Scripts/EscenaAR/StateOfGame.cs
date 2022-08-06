using System;
using ServiceLocatorPath;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class StateOfGame : MonoBehaviour, IMediator
{
    [SerializeField] private TextMeshProUGUI debugging;
    [SerializeField] GameObject m_PlacedPrefab;
    [SerializeField] private ShooterToEnemies shooter;
    [SerializeField] private Camera camera;
    [SerializeField] private UiController uiController;
    
    private EnemyStatesConfiguration _enemyStatesConfiguration;
    private IMediadorAR _ar;
    private bool _buclePrincipal;
    private bool hasWait;
    private bool canUse;
    private Vector2 positionToClick;
    private bool _hasClick;
    private int _vidaHeal;
    private float _porcentOfOne;
    private float _scaleMultiply;
    private PjController _sceneInteractive;


    public void Configuration(IMediadorAR ar)
    {
        _ar = ar;

        _ar.StartSession();
            
        _enemyStatesConfiguration = new EnemyStatesConfiguration();
        _enemyStatesConfiguration.AddInitialState(EnemyStatesConfiguration.ConfigurationOfGame, new ConfigurationOfGame(this));
        _enemyStatesConfiguration.AddState(EnemyStatesConfiguration.WaitForClickInSpace, new WaitForClick(this));
        _enemyStatesConfiguration.AddState(EnemyStatesConfiguration.Game, new Game(this));
        _enemyStatesConfiguration.AddState(EnemyStatesConfiguration.FinishGame, new FinishGame(this));
        _buclePrincipal = true;
        StartState(_enemyStatesConfiguration.GetInitialState());
        canUse = true;
        //Write($"Configurado");
        //_scaleMultiply = 
    }

    private void ColocarVida(int _vida)
    {
        _vidaHeal = _vida;
        RedibujarVida();
    }

    private void RedibujarVida()
    {
        //vida.text = $"{_vidaHeal}";
    }

    private void Update()
    {
        if (!canUse) return;
        if (!_hasClick && _ar.Touch())
        {
            _hasClick = true;
            positionToClick = _ar.GetMousePosition();
        }
    }
    private async void StartState(IEnemyState state, object data = null)
    {
        while (_buclePrincipal)
        {
            var resultData = await state.DoAction(data);
            var nextState = _enemyStatesConfiguration.GetState(resultData.NextStateId);
            state = nextState;
            data = resultData.ResultData;
        }
    }
    
    
    private void OnDestroy()
    {
        _buclePrincipal = false;
        hasWait = true;
    }

    private void OnDisable()
    {
        _buclePrincipal = false;
        hasWait = true;
    }

    public void Write(string text)
    {
        ServiceLocator.Instance.GetService<IDebugText>().Log(text);
    }

    public bool ShootRaycast(Action action)
    {
        try
        {
            //Write($"instancia");
            _sceneInteractive = _ar.InstantiateObjectInRaycast(GetPositionInWord(), m_PlacedPrefab).GetComponent<PjController>();
            _sceneInteractive.Configure(uiController);
            action?.Invoke();
            return true;
        }
        catch (Exception e)
        {
            Write($"Error - {e.Message}");
            ServiceLocator.Instance.GetService<IShowErrors>().ShowError(e.Message);
            return false;
        }
    }

    public void ConfiguraEnemigoSpawner()
    {
        //spawnerEnemy.Configuration(this);
    }

    public void RestarVida(int vidaToRestar)
    {
        _vidaHeal -= vidaToRestar;
        RedibujarVida();
    }

    public bool HasWait()
    {
        return hasWait;
    }

    public void StopSpawnAndDestroidAll()
    {
        //spawnerEnemy.StopSpawn();
        //spawnerEnemy.CleanEnemies();
    }

    public void ShowTheGameOver()
    {
        //panelToGameOver.SetActive(true);        
    }

    public void ConfigureShooter()
    {
        shooter.Configure(this);
    }

    public ARRaycastManager GetRayCastManager()
    {
        return _ar.GetRayCastManager();
    }

    public Camera GetSessionOrigin()
    {
        return _ar.GetSessionOrigin();
    }

    public void HideDebuggers()
    {
        _ar.HideDebuggers();
    }

    public Camera GetCamera()
    {
        return camera;
    }

    public Vector3 GetMousePositionInScream()
    {
        return _ar.GetMousePosition();
    }

    public void StartSessionOfAR()
    {
        _ar.StartSession();
    }

    public bool HasClickInScream()
    {
        var aux = _hasClick;
        _hasClick = false;
        return aux;
    }

    public Vector2 GetPositionInWord()
    {
        //Write($"{_ar.GetMousePosition()} _ar.GetMousePosition()");
        return _ar.GetMousePosition();
    }

    public bool FinishGame()
    {
        return _vidaHeal <= 0;
    }

    public void Restart()
    {
        _buclePrincipal = false;
        canUse = false;
    }
}