using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{

    private AsyncOperation async;
    [SerializeField] private Image progressHouse;
    [SerializeField] private Text txtPercent;

    // Start is called before the first frame update
    void Start()
    {
        InitParam();
        LoadScene();
    }

    void InitParam()
    {
        Time.timeScale = 1.0f;
        Input.ResetInputAxes();
        System.GC.Collect();
    }

    void LoadScene()
    {
        Scene currScene = SceneManager.GetActiveScene();
        async = SceneManager.LoadSceneAsync(currScene.buildIndex + 1);

        async.allowSceneActivation = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (progressHouse)
            progressHouse.fillAmount = async.progress + 0.1f;

        if (txtPercent)
            txtPercent.text = ((async.progress + 0.1f) * 100).ToString("F2") + " %";


        if(async.progress > 0.89f && SplashScreen.isFinished)
        {
            async.allowSceneActivation = true;
        }
    }
}
