using UnityEngine;
using MoreMountains.Feedbacks;
public class FeadBackPlay : MonoBehaviour
{
    [SerializeField]
    MMFeedbacks _mmFeedback;
    
    public void PlayFeaadBack()
    {
        _mmFeedback.PlayFeedbacks();
        
    }
}
