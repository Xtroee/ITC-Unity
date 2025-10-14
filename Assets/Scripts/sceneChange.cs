using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    public void PlayAction(){
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
