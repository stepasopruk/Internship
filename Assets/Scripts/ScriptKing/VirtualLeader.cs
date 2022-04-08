using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualLeader : MonoBehaviour
{
    [Header("Prefab игрока")]
    [SerializeField] private GameObject _playerPrefabs;
    [Header("Кол-во игроков")]
    [SerializeField] private int _countPlayer = 2;
    [Header("Список позиций спавна игроков")]
    [SerializeField] private List<Transform> SpawnPointPlayer = new List<Transform>();

    private GameObject _currentPlayer;
    private Queue<Player> PlayersQueue = new Queue<Player>();

    Player currentQueuePlayer;

    private void Start()
    {
        AddPlayer(_countPlayer);

        StartNextPlayerTurn();
    }

    private void AddPlayer(int countPlayer)
    {
        for (int i = 0; i < countPlayer; i++)
        {
            _currentPlayer = Instantiate(_playerPrefabs, SpawnPointPlayer[i].position, Quaternion.identity);
            _currentPlayer.name = "Player №" + (i + 1);
            _currentPlayer.SetActive(true);
            PlayersQueue.Enqueue(_currentPlayer.GetComponent<Player>());
        }
    }


    private void Update()
    {

    }

    private void StartNextPlayerTurn()
    {
        currentQueuePlayer = PlayersQueue.Dequeue();
        currentQueuePlayer.EndTurnEvent += OnEndPlayerTurn;
        currentQueuePlayer.StartTurn();
        PlayerStep(currentQueuePlayer.HasTurn);
    }

    private void OnEndPlayerTurn()
    {
        currentQueuePlayer.EndTurnEvent -= OnEndPlayerTurn;
        PlayersQueue.Enqueue(currentQueuePlayer);
        StartNextPlayerTurn();
    }

    private void PlayerStep(bool step)
    {
        if (step)
        {
            Debug.Log("Ходит " + PlayersQueue.Peek().name);
        }
    }

    public void OnChangeQQ()
    {
        StartNextPlayerTurn();
    }

}
