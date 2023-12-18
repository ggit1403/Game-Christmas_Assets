using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateManager : MonoBehaviour
{
    public static SceneStateManager instance;
    public bool isInOnGroundScene;

    void Awake()
    {
        // Đảm bảo chỉ có một instance của SceneStateManager tồn tại
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        // Đăng ký sự kiện để lắng nghe khi scene thay đổi
        SceneManager.sceneLoaded += OnSceneLoaded;
        CheckCurrentScene();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Kiểm tra xem scene mới được load có phải là onGround hay không
        if (scene.name == "onGround")
        {
            isInOnGroundScene = true;
        }
        else if (scene.name == "onSky")
        {
            isInOnGroundScene = false;
        }
    }

    void CheckCurrentScene()
    {
        // Kiểm tra xem scene hiện tại là onGround hay không
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "onGround")
        {
            isInOnGroundScene = true;
            this.gameObject.GetComponent<MoveOnGround>().enabled = true;
            this.gameObject.GetComponent<PlayerMoveOnSky>().enabled = false;
        
        }
        else if (currentScene.name == "onSky")
        {
            isInOnGroundScene = false;
            this.gameObject.GetComponent<MoveOnGround>().enabled = false;
            this.gameObject.GetComponent<PlayerMoveOnSky>().enabled = true;
        

        }
    }
}
