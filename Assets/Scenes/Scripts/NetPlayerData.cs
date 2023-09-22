using Networking;
using UnityEngine;

public class NetPlayerData : MonoBehaviour
{
    public string nick;
    public BotHands botHands;
    public BotState botState;

    public void UpdatePlayer(NetPlayer netPlayer)
    {
        transform.position = netPlayer.Position;
        transform.rotation = Quaternion.Euler(netPlayer.Rotation);
    }

    public void UpdateAnimation(AnimationData animationData)
    {
        Debug.Log(animationData.id);
    }
}
