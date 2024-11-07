using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{

    //todo: fix up this script ;-;
    private static SceneLoader instance;
    public BattleDetails Battle;
    [SerializeField] GameObject QuitMenu;
    [SerializeField] GameObject InvMenu;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy the new instance if it's not the first one
            Destroy(gameObject);
        }
    }
    public void StoredBattle(BattleDetails x)
    {
        Battle.Allies = x.Allies;
        Battle.Enemies = x.Enemies;
    }

    public void LoadScene(int x)
    {
        SceneManager.LoadScene(x);
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    void Update()//todo: remember to change this when making settings 
    {
        if(Input.GetKeyDown("escape"))
        {
            QuitMenu.SetActive(!QuitMenu.active);
        }
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            InvMenu.SetActive(!InvMenu.active);
        }
    }
}




