using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using com.javierquevedo.events;
using com.javierquevedo.gui;

namespace com.javierquevedo
{

    public class GameController : MonoBehaviour
    {

        protected Game _game;

        private const string _bubbleShooterPrefabName = "Prefabs/BubbleShooterPrefab";
        private GameObject _bubbleShooterPrefab;
        private GameObject _camera;
        private BubbleMatrixController _bubbleMatrixController;
        private GameObject _hud;
        private GameHUD _gameHUD;

        [SerializeField]
        private GameObject _gameFinishedGUI = null;

        void Awake()
        {
            _game = new com.javierquevedo.Game();
        }

        void Start()
        {
            _camera = GameObject.Find("Camera");

            _hud = GameObject.Find("GameHUD");
            _gameHUD = _hud.AddComponent<GameHUD>();
            _gameHUD.game = this._game;

            this.startGame();


        }

        void OnEnable()
        {
            GameEvents.OnBubblesRemoved += onBubblesRemoved;
            GameEvents.OnGameFinished += onGameFinished;
        }

        void OnDisable()
        {
            GameEvents.OnBubblesRemoved -= onBubblesRemoved;
            GameEvents.OnGameFinished -= onGameFinished;
        }

        void Update()
        {

        }

        private void startGame()
        {
            _bubbleShooterPrefab = Instantiate(Resources.Load(_bubbleShooterPrefabName)) as GameObject;
            _bubbleShooterPrefab.transform.position = new Vector3(0, 0, 0);
            _bubbleMatrixController = _bubbleShooterPrefab.GetComponent<BubbleMatrixController>();

            _bubbleMatrixController.startGame();



        }
        // Game Controllers Specializations can override this function to provide
        // specific score behaviour
        protected virtual void onBubblesRemoved(int bubbleCount, bool exploded)
        {
            this._game.destroyBubbles(bubbleCount, exploded);
        }

        protected virtual void onGameFinished(GameState state)
        {
            _gameFinishedGUI.SetActive(true);
            GameFinishedGUI finishedGUI = _gameFinishedGUI.GetComponent<GameFinishedGUI>();
            finishedGUI.game = this._game;
            finishedGUI.StartNewGameSelectedDelegate = this.onGameStartSelected;
            this._game.state = state;
            finishedGUI.game = this._game;

        }

        private void onGameStartSelected()
        {
            SceneManager.LoadScene(1);
        }



    }
}
