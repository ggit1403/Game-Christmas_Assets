using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDesTroy : MonoBehaviour
{
    // Start is called before the first frame update
    public static DontDesTroy instance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Awake()
    {
        // Đảm bảo chỉ có một instance của SceneStateManager tồn tại
        if (instance == null)
        {
            instance = this;


        }
        else
        {
            // Nếu đã có một instance khác tồn tại, hủy đối tượng
            Destroy(gameObject);
        }

    }
    void Update()
    {
       
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "onGround" || currentScene.name == "onSky")
        {
            DontDestroyOnLoad(this.gameObject);

        }
        else if (currentScene.name == "Main Menu")
        {
            // Nếu là một scene khác, hủy đối tượng
            Destroy(this.gameObject);

        }
    }
}
