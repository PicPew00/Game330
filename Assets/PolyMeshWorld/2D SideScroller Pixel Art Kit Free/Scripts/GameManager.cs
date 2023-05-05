
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{


    [Header("Buttons")]
    [SerializeField] private Button PlayBtn;    
    [SerializeField] private Button QuitBtn;

    // Start is called before the first frame update
    void Start()
    {

        PlayBtn.onClick.AddListener(GoToGameScene);
        QuitBtn.onClick.AddListener(QuitGame);
    }

    private void GoToGameScene() {

        SceneManager.LoadSceneAsync(1);
    
    }

    private void QuitGame() {

        Application.Quit();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
