using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] private Canvas StartingScreenCanvas;
    [SerializeField] private Canvas GamePlayCanvas;
    [SerializeField] private Canvas SettingsCanvas;
    [SerializeField] private Canvas GameOverCanvas;
    [SerializeField] private Rigidbody2D playerRigidBody;
    public bool gamePlayScreen = false;

    void Start()
    {
        StartingScreenCanvas.enabled = true;
        GamePlayCanvas.enabled = false;
        SettingsCanvas.enabled = false;
        GameOverCanvas.enabled = false;
    }
    public void OnPlayBtnClick()
    {
        gamePlayScreen = true;
        GamePlayCanvas.enabled = true;
        StartingScreenCanvas.enabled = false;
    }
    public void OnSettingsBtnClick()
    {
        gamePlayScreen = false;
        GamePlayCanvas.enabled = false;
        SettingsCanvas.enabled = true;
        Time.timeScale = 0;
    }
    public void OnResume()
    {
        gamePlayScreen = true;
        GamePlayCanvas.enabled = true;
        SettingsCanvas.enabled = false;
        Time.timeScale = 1;
    }
    public void OnGameOverScreen()
    {
        gamePlayScreen = false;
        StartingScreenCanvas.enabled = false;
        GamePlayCanvas.enabled = false;
        SettingsCanvas.enabled = false;
        GameOverCanvas.enabled = true;
    }
    public void OnRestartBtnClick()
    {
        SceneManager.LoadScene("MainLevel", LoadSceneMode.Single);
    }
    public void onLowGravitySelected()
    {
        Physics2D.gravity = new Vector2(0, -7f);
    }
    public void onMedGravitySelected()
    {
        Physics2D.gravity = new Vector2(0, -9.8f);
    }
    public void onHighGravitySelected()
    {
        Physics2D.gravity = new Vector2(0, -13f);
    }
}
