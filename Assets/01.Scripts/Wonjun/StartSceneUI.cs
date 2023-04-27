using Febucci.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneUI : MonoBehaviour
{
    public TextAnimatorPlayer textplayer;
    public TextMeshProUGUI _titleText;
    [SerializeField]
    private GameObject _exPenal;
    // Start is called before the first frame update
    void Start()
    {
        _exPenal.SetActive(false);  
        _titleText.SetText("<rainb>Genes of Darkness");
        textplayer.ShowText(_titleText.text);
    }

    public void StartGame(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void Explain()
    {
        _exPenal.SetActive(true);
    }
    public void Exitexplain()
    {
        _exPenal.SetActive(false);
    }
}
