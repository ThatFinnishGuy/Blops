using UnityEngine;
using System.Collections;
using TMPro;

namespace com.javierquevedo
{
    public class GameHUD : MonoBehaviour
    {

        public Game game;
        private TextMeshProUGUI textMesh;
        private int currentScore = 0;
        private int previousScore = 0;

        void Start()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            currentScore = game.score;
            if(currentScore > previousScore)
            {
                StartCoroutine(Pulse());
                previousScore = currentScore;
            }

            textMesh.text = currentScore.ToString();
        }

        private IEnumerator Pulse()
        {
            for(float i = 1f; i <= 1.1f; i += 0.02f)
            {
                textMesh.rectTransform.localScale = new Vector3(i, i, i);
                yield return new WaitForEndOfFrame();
            }
            textMesh.rectTransform.localScale = new Vector3(1f, 1f, 1f);
        }
        
    }
}
/*
GUI.Label(new Rect(20,100,200,30), "Score: " + game.score);
			GUI.Label(new Rect(20,120,200,30), "Bubbles destroyed: " + game.bubblesDestroyed);
			GUI.Label(new Rect(20,140,200,30), "Time played: " + timeText);*/