using System;
using UnityEngine;

namespace BelumProduktif.DesignPattern.Singleton
{
    // Simple Persistent Base Class
    public class MonoDDOL<T> : MonoBehaviour where T: MonoBehaviour
    {
        public static T Instance;

        protected void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this as T;
            DontDestroyOnLoad(gameObject);
            
            // Init Derived Class Component on Awake
            InitComponent();
        }
        
        protected virtual void InitComponent() { }
    }
}