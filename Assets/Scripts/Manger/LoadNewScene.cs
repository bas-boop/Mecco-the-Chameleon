using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LoadNewScene : MonoBehaviour
{
    private GameObject gameManger;
    [SerializeField] private TimerManger TM;
    [SerializeField] private float someTime;

    private void Awake()
    {
        gameManger = GameObject.Find("Gamemanger");
        TM = gameManger.GetComponent<TimerManger>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.HasTag("Player"))
        {
            SceneManager.LoadScene(Random.Range(3, 12));
            col.gameObject.transform.position = Vector3.zero;
            TM.levelsSuccesede++;
            var addedTime = someTime / TM.levelsSuccesede + 1;
            TM.timer += addedTime;
        }
    }
}
