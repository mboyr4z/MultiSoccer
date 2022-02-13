using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

public class OdayaGirmeAni : MonoBehaviourPunCallbacks
{
    public static OdayaGirmeAni Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    // sahne yüklendiğinde, managerlar aktif olur ve her oyuncunun controllerları açılır
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)      //s ahne 1 yüklendiğinde
        {
            foreach (Transform manager in transform)
            {
                manager.gameObject.SetActive(true);
            }
        }
    }
}
