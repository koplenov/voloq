using Networking;
using UnityEngine;

public class NetPlayerData : MonoBehaviour
{
    public string nick;
    public BotHands botHands;
    public BotState botState;

    public void UpdatePlayer(NetPlayer netPlayer)
    {
        var diff = netPlayer.Position - transform.position;
        Debug.Log(diff);
        //if (diff.x < 0.4)
        //{
        //   Debug.Log("вперед");
        //}
        //if (diff.x > -0.4)
        //{
        //   Debug.Log("назад");
        //}
        
        transform.position = netPlayer.Position;
        transform.rotation = Quaternion.Euler(netPlayer.Rotation);
    }
}
