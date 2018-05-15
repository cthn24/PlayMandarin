using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class backgroundMusic : MonoBehaviour {

    static backgroundMusic instance = null;


	void Awake()
    {

        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

    }

}
