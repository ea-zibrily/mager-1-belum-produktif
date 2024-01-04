using UnityEngine;

namespace BelumProduktif.DesignPattern.Singleton
{
    public class HasanSingleton<T> : MonoBehaviour where T: MonoBehaviour
    {
        #region Fields

        /// <summary>
        /// The instance.
        /// </summary>
        private static T _instance;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static T Instance
        {
            get
            {
                if ( _instance == null )
                {
                    _instance = FindObjectOfType<T> ();
                    if ( _instance == null )
                    {
                        GameObject obj = new GameObject ();
                        obj.name = typeof ( T ).Name;
                        _instance = obj.AddComponent<T> ();
                    }
                }
                return _instance;
            }
        }
        
        #endregion

        #region Methods

        /// <summary>
        /// Use this for initialization.
        /// </summary>
        protected void Awake ()
        {
            if ( _instance == null )
            {
                _instance = this as T;

                if (Application.isPlaying)
                {
                    DontDestroyOnLoad(gameObject);
                }
                
                // Init existing instance
                InitComponent();
            }
            else
            {
                if (Application.isPlaying)
                {
                    Destroy(gameObject);
                }
                else
                {
                    DestroyImmediate(gameObject);
                }
            }
        }
        
        protected virtual void InitComponent() { }

        #endregion
    }
}