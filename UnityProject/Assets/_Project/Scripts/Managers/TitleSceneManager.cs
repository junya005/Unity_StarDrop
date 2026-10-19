using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField]
    private string _nextSceneName;

    [SerializeField]
    private GameObject _creditPanel;

    private float _inputInterval = 0.2f;

    private float time = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if(time < _inputInterval)
        {
            time += Time.deltaTime;
            return;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _creditPanel.SetActive(!_creditPanel.activeSelf);
        }

        if (Input.anyKeyDown && CheckInputSpetialKeys() && !_creditPanel.activeSelf)
        {
            LoadingManager.Instance.ChangeScene(_nextSceneName);
        }
    }

    private bool CheckInputSpetialKeys()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            return false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            return false;
        }

        if (Input.GetKeyDown(KeyCode.LeftWindows) || Input.GetKeyDown(KeyCode.RightWindows))
        {
            return false;
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
        {
            return false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            return false;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            return false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) ||
        Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            return false;
        }

        return true;
    }
}
