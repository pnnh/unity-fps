using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[AddComponentMenu("Game/GameManager")]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public int m_score = 0;

    public static int m_hiscore = 0;

    public int m_ammo = 100;

    private Player m_player = null;

    private Text txt_ammo;

    private Text txt_hiscore;

    private Text txt_life;

    private Text txt_score;

    private Button button_restart;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        GameObject uicanvas = GameObject.Find("Canvas");
        foreach (Transform t in uicanvas.transform.GetComponentsInChildren<Transform>())
        {
            if (t.name.CompareTo("txt_ammo") == 0)
            {
                txt_ammo = t.GetComponent<Text>();
            } else if (t.name.CompareTo("txt_hiscore") == 0)
            {
                txt_hiscore = t.GetComponent<Text>();
                txt_hiscore.text = "High Score " + m_hiscore;
            } else if (t.name.CompareTo("txt_life") == 0)
            {
                txt_life = t.GetComponent<Text>();
            } else if (t.name.CompareTo("txt_score") == 0)
            {
                txt_score = t.GetComponent<Text>();
            } else if (t.name.CompareTo("Restart Button") == 0)
            {
                button_restart = t.GetComponent<Button>();
                button_restart.onClick.AddListener(delegate()
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                });
                button_restart.gameObject.SetActive(false);
            }
        }
    }

    public void SetScore(int score)
    {
        m_score += score;
        if (m_score > m_hiscore)
            m_hiscore = m_score;
        txt_score.text = "Score <color=yellow>" + m_score + "</color>";
        txt_hiscore.text = "High Score" + m_hiscore;
    }

    public void SetAmmo(int ammo)
    {
        m_ammo -= ammo;
        if (ammo < 0)
            m_ammo = 100 - m_ammo;
        txt_ammo.text = m_ammo.ToString() + " / 100";
    }

    public void SetLife(int life)
    {
        txt_life.text = life.ToString();
        if (life <= 0)
        {
            button_restart.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
