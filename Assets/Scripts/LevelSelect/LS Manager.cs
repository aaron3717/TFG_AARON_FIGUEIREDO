using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LSManager : MonoBehaviour
{
    public LSPlayer Player;
    private MapPoint[] allPoints;
    void Start()
    {
        AudioManager.instance.StopMusic();
        allPoints = FindObjectsOfType<MapPoint>();
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            foreach (MapPoint point in allPoints)
            {
                if(point.NivelaCargar == PlayerPrefs.GetString("CurrentLevel"))
                {
                    Player.transform.position = point.transform.position;
                    Player.currentPoint = point;
                }
            }
        }
    }

    void Update()
    {
        
    }
    public void LoadLevel()
    {
        StartCoroutine(LoadLevelCO());
    }
    public IEnumerator LoadLevelCO()
    {
        yield return new WaitForSeconds(1f);
        AudioManager.instance.StopMusic();

        SceneManager.LoadScene(Player.currentPoint.NivelaCargar);
    }
}
