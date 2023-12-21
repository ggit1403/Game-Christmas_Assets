using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateManager : MonoBehaviour
{
    public static SceneStateManager instance;
    public bool isInOnGroundScene;
    public GameObject pos;
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
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "onGround" || currentScene.name == "onSky")
        {
            DontDestroyOnLoad(gameObject);
         
        }
        else if (currentScene.name == "Main Menu")
        {
            // Nếu là một scene khác, hủy đối tượng
            Destroy(this.gameObject);
       
        }

    }
    void FixedUpdate()
    {
        if (pos == null)
        {
            pos = GameObject.FindWithTag("pos");
        }
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
        if (pos != null)
        {
            transform.position = new Vector3(pos.transform.position.x, pos.transform.position.y,0);
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
