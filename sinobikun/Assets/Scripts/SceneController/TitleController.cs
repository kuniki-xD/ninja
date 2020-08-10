using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{

    [SerializeField] private PopButton _popButton;
    // Start is called before the first frame update
    private void Start()
    {
        _popButton.Init(onButtonDownAction);
    }

    private void onButtonDownAction()
    {
        SceneManager.LoadSceneAsync("Select");
    }
}
