using Networking;
using UnityEngine;

public class NetPlayerData : MonoBehaviour
{
    public string nick;
    public BotHands botHands;
    public BotState botState;
    public Animator sakuraAnimator;

    public void UpdatePlayer(NetPlayer netPlayer)
    {
        // transform.position = netPlayer.Position;
        transform.position = Vector3.Slerp(transform.position, netPlayer.Position, Time.fixedDeltaTime * 5);
        transform.rotation = Quaternion.Euler(netPlayer.Rotation);
    }

    public void UpdateAnimation(AnimationData animationData)
    {
        sakuraAnimator.SetInteger(animationData.animation, animationData.id);
    }
}
