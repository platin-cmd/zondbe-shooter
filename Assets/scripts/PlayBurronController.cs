using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayBurronController : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("1st Level");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
}
