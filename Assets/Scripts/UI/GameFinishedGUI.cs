using UnityEngine;
using System.Collections;
using TMPro;

namespace com.javierquevedo.gui
{

    public class GameFinishedGUI : MonoBehaviour
    {

        GameFinishGUIDelegate startNewGameSelectedDelegate;
        public delegate void GameFinishGUIDelegate();

        public GameFinishGUIDelegate StartNewGameSelectedDelegate
        {
            set
            {
                this.startNewGameSelectedDelegate = value;
            }
        }

        public Game game;

        [SerializeField]
        private TextMeshProUGUI winLoss = null;

        [SerializeField]
        private TextMeshProUGUI scoreResult = null;

        [SerializeField]
        private TextMeshProUGUI blocksResult = null;
      

        void Start()
        {
            PopulateTextFields();
        }

        void Update()
        {
            
        }

        void PopulateTextFields()
        {
            winLoss.text = "YOU " + (game.state == GameState.Win ? "WON!" : "LOST!");
            scoreResult.text = game.score.ToString();
            blocksResult.text = game.bubblesDestroyed.ToString();
        }
        
        

        public void newGameWasSelected()
        {
            if (startNewGameSelectedDelegate != null)
                startNewGameSelectedDelegate();
        }

        public void QuitGame()
        {
            Debug.Log("Quitting");
            Application.Quit();
        }
    }



}
