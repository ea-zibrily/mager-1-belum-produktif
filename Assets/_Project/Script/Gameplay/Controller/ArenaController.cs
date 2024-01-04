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
        
        private Transform wayStartPosition;
        private Transform wayEndPosition;

        [Header("Reference")]
        private ScoreController scoreController;
    
        #endregion
    
        #region MonoBehaviour Callbacks

        private void Awake()
        {
            wayStartPosition = GameObject.Find("WayPosition_1").transform;
            wayEndPosition = GameObject.Find("WayPosition_2").transform;
        
            scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
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
            if(transform.position.x <= wayEndPosition.transform.position.x)
            {
                transform.position = wayStartPosition.transform.position;
            }
        }

        private void IncreaseWayMoveSpeed()
        {
            wayMoveSpeed += scoreController.MultiplierTime;
            if (wayMoveSpeed > maxWayMoveSpeed)
            {
                wayMoveSpeed = maxWayMoveSpeed;
            }
        }
    
        #endregion

    }
}
