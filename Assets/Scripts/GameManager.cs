﻿using UnityEngine;

public class GameManager : MonoBehaviour {

    private ObjectDestructor[] platformList;
    private ScoreManager scoreManager;
    private Vector3 platformStartPoint;
    private Vector3 playerStartPoint;
    private Vector3 backgroundStartPoint;

    public PlayerController player;
    public RestartMenu restartMenu;
    public Transform platformGenerator;
    public Transform backgroundGenerator;

	void Start () {
        backgroundStartPoint = backgroundGenerator.position;
        platformStartPoint = platformGenerator.position;
        playerStartPoint = player.transform.position;
        scoreManager = FindObjectOfType<ScoreManager>();
    }
	
	void Update () {
	
	}

    public void RestartGame()
    {
        //StartCoroutine("RestartGameCo");
        scoreManager.scoreIncreasing = false;
        player.gameObject.SetActive(false);
        restartMenu.gameObject.SetActive(true);
    }
    public void Reset()
    {
        restartMenu.gameObject.SetActive(false);
        platformList = FindObjectsOfType<ObjectDestructor>();

        for (int i = 0; i < platformList.Length; i++)
            platformList[i].gameObject.SetActive(false);

        backgroundGenerator.position = backgroundStartPoint;
        player.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        player.gameObject.SetActive(true);

        scoreManager.scoreCount = 0;
        scoreManager.scoreIncreasing = true;
    }
    /*
    public IEnumerator RestartGameCo()
    {
        scoreManager.scoreIncreasing = false;
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformDestructor>();

        for (int i = 0; i < platformList.Length; i++)
            platformList[i].gameObject.SetActive(false);

        player.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        player.gameObject.SetActive(true);

        scoreManager.scoreCount = 0;
        scoreManager.scoreIncreasing = true;
    }
    */
}
