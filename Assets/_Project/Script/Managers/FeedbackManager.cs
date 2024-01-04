using BelumProduktif.DesignPattern.Singleton;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace BelumProduktif.Managers
{
    [AddComponentMenu("Tsukuyomi/Managers/FeedbackManager")]
    public class FeedbackManager : MonoDDOL<FeedbackManager>
    {
        #region Variable

        [field: SerializeField] public MMFeedbacks ImpulseFeedbacks { get; private set; }
        [field: SerializeField] public MMFeedbacks FaderFeedbacks { get; private set; }
        [field: SerializeField] public MMFeedbacks DirectionalInFeedbacks { get; private set; }
        [field: SerializeField] public MMFeedbacks DirectionalOutFeedbacks { get; private set; }

        #endregion

        #region Tsukuyomi Callbacks

        // Call Feedbacks Event
        public void CallImpulse() => ImpulseFeedbacks?.PlayFeedbacks();
        public void CallFader() => FaderFeedbacks?.PlayFeedbacks();
        public void CallDirectionalIn() => DirectionalInFeedbacks?.PlayFeedbacks();
        public void CallDirectionalOut() => DirectionalOutFeedbacks?.PlayFeedbacks();
        
        // Get MMF_Player Feedbacks
        public MMFeedbacks GetImpulse() => ImpulseFeedbacks;
        public MMFeedbacks GetFader() => FaderFeedbacks;
        public MMFeedbacks GetDirectionalIn() => DirectionalInFeedbacks;
        public MMFeedbacks GetDirectionalOut() => DirectionalOutFeedbacks;

        #endregion
    }
}
