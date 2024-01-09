using System;
using BelumProduktif.Managers;
using UnityEngine;

namespace BelumProduktif.Gameplay.Controller
{
    [AddComponentMenu("Tsukuyomi/Controller/ArenaController")]
    public class ArenaController : MonoBehaviour
    {
        #region Variable

        [Header("Way Component")] 
        [SerializeField] private float wayMoveSpeed;
        [SerializeField] private float maxWayMoveSpeed;
        
        private Transform _wayStartPosition;
        private Transform _wayEndPosition;

        [Header("Reference")]
        private ScoreController _scoreController;
    
        #endregion
    
        #region MonoBehaviour Callbacks

        private void Awake()
        {
            _wayStartPosition = GameObject.Find("WayPosition_1").transform;
            _wayEndPosition = GameObject.Find("WayPosition_2").transform;
        
            _scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
        }

        private void Update()
        {
            if (!GameManager.Instance.IsGameStart)
            {
                return;
            }
        
            WayMovement();
        }
    
        #endregion
    
        #region Tsukuyomi Callbacks
        
        private void WayMovement()
        {
            IncreaseWayMoveSpeed();
            transform.position = new Vector2(transform.position.x - wayMoveSpeed * Time.deltaTime, transform.position.y);
            if(transform.position.x <= _wayEndPosition.transform.position.x)
            {
                transform.position = _wayStartPosition.transform.position;
            }
        }

        private void IncreaseWayMoveSpeed()
        {
            wayMoveSpeed += _scoreController.MultiplierTime;
            if (wayMoveSpeed > maxWayMoveSpeed)
            {
                wayMoveSpeed = maxWayMoveSpeed;
            }
        }
    
        #endregion

    }
}
