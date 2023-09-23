using Networking;
using UnityEngine;

namespace Utils
{
    public static class GameUtils
    {
        public static void SendDamage(string analDamager, string anal, int damage)
        {
            SendDamage netPlayer = new SendDamage(analDamager, anal, damage);
            
            // content bytes
            byte[] testByted = Data.ObjectToByteArray(netPlayer);

            // bytes to send or bytes from server
            byte[] packetBytes = Packer.CombinePacket(ChanelID.Damage, testByted);
            
            // simple send bytes to server
            Network.SendUdpData(packetBytes);
        }
        
        public static void SendAnimation(string nick, string animation, int id)
        {
            AnimationData netPlayer = new AnimationData(nick, animation, id);
            
            // content bytes
            byte[] testByted = Data.ObjectToByteArray(netPlayer);

            // bytes to send or bytes from server
            byte[] packetBytes = Packer.CombinePacket(ChanelID.AnimationData, testByted);
            
            // simple send bytes to server
            Network.SendUdpData(packetBytes);
        }
        
        public static void SendSyncGroup(ref NetworkBehaviour[] objects)
        {
            SyncTransformData[] serialize = new SyncTransformData[objects.Length];
            for (var i = 0; i < objects.Length; i++)
            {
                serialize[i] = new SyncTransformData(objects[i]);
            }
            
            foreach (var obj in objects)
            {
                // new SyncTransformData(obj);
                
            }
            
            // SyncPositionGroup netPlayer = new SyncPositionGroup(nick, animation, id);
            
            // content bytes
            // byte[] testByted = Data.ObjectToByteArray(netPlayer);

            // bytes to send or bytes from server
            // byte[] packetBytes = Packer.CombinePacket(ChanelID.AnimationData, testByted);
            
            // simple send bytes to server
            // Network.SendUdpData(packetBytes);
        }
    }
}