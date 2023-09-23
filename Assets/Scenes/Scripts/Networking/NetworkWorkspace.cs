using System;
using UnityEngine;

namespace Networking
{
    #region ChanellID

    public class ChanelID
    {
        public const int Logout = 201;
        public const int Login = 200;
        public const int PlayerPosition = 0;
        public const int SpawnDecal = 6;
        public const int ChangeWeapon = 7;
        public const int Damage = 5;
        public const int Respawn = 8;
        public const int AnimationData = 9;
        public const int SyncGroup = 11;
        public const int CastSpell = 12;
    }

    #endregion

    #region Network

    [Serializable]
    public class SpawnDecal
    {
        public string nick = String.Empty;
        public SVector hitInfoPoint = new SVector(Vector3.zero);
        public SVector hitInfoNormal = new SVector(Vector3.zero);

        public SpawnDecal(string nick, Vector3 hitInfoPoint, Vector3 hitInfoNormal)
        {
            this.nick = nick;
            this.HitInfoPoint = hitInfoPoint;
            this.HitInfoNormal = hitInfoNormal;
        }

        public Vector3 HitInfoPoint
        {
            get => hitInfoPoint.Vector3;
            set
            {
                hitInfoPoint.x = value.x;
                hitInfoPoint.y = value.y;
                hitInfoPoint.z = value.z;
            }
        }

        public Vector3 HitInfoNormal
        {
            get => hitInfoNormal.Vector3;
            set
            {
                hitInfoNormal.x = value.x;
                hitInfoNormal.y = value.y;
                hitInfoNormal.z = value.z;
            }
        }
    }

    [Serializable]
    public class ChangeWeapon
    {
        public string nick = String.Empty;
        public int weapon = 0;

        public ChangeWeapon(string nick, int weapon)
        {
            this.nick = nick;
            this.weapon = weapon;
        }
    }
    
    [Serializable]
    public class Login
    {
        public string nick = String.Empty;
        public Login(string nick)
        {
            this.nick = nick;
        }
    }
    
    [Serializable]
    public class Logout
    {
        public string nick = String.Empty;
        public Logout(string nick)
        {
            this.nick = nick;
        }
    }

    [Serializable]
    public class SendDamage
    {
        public string analDamager = String.Empty;
        public string anal = String.Empty;
        public int damage = 0;

        //Who whom damaging?
        public SendDamage(string analDamager, string anal, int damage)
        {
            this.analDamager = analDamager;
            this.anal = anal;
            this.damage = damage;
        }
    }
    
    [Serializable]
    public class CastSpellData
    {
        public string nick = String.Empty;
        public string spellName = String.Empty;
        public SVector direction = new SVector(Vector3.zero);
        public SVector position = new SVector(Vector3.zero);
        public CastSpellData(string nick, string spellName, Vector3 direction, Vector3 position)
        {
            this.nick = nick;
            this.spellName = spellName;
            this.Direction = direction;
            this.Position = position;
        }
        
        public Vector3 Direction
        {
            get => direction.Vector3;
            set
            {
                direction.x = value.x;
                direction.y = value.y;
                direction.z = value.z;
            }
        }

        public Vector3 Position
        {
            get => position.Vector3;
            set
            {
                position.x = value.x;
                position.y = value.y;
                position.z = value.z;
            }
        }
    }
    
    [Serializable]
    public class AnimationData
    {
        public string nick = String.Empty;
        public string animation = String.Empty;
        public int id = 0;

        public AnimationData(string nick, string animation, int id)
        {
            this.nick = nick;
            this.animation = animation;
            this.id = id;
        }
    }
    
    [Serializable]
    public class SyncTransformData
    {
        public SyncTransformData(string guid, Vector3 position, Vector3 rotation)
        {
            this.guid = guid;
            this.Position = position;
            this.Rotation = rotation;
        }

        public SyncTransformData(NetworkBehaviour transform)
        {
            this.guid = transform.guid;
            this.Position = transform.transform.position;
            this.Rotation = transform.transform.rotation.eulerAngles;
        }

        public Vector3 Rotation
        {
            get => rotation.Vector3;
            set
            {
                rotation.x = value.x;
                rotation.y = value.y;
                rotation.z = value.z;
            }
        }

        public Vector3 Position
        {
            get => position.Vector3;
            set
            {
                position.x = value.x;
                position.y = value.y;
                position.z = value.z;
            }
        }

        public Transform Transform
        {
            set
            {
                Position = value.position;
                Rotation = value.rotation.eulerAngles;
            }
        }

        [SerializeField] public string guid = String.Empty;
        [SerializeField] public SVector position = new SVector(Vector3.zero);
        [SerializeField] public SVector rotation = new SVector(Vector3.zero);
    }

    [Serializable]
    public class NetPlayer
    {
        // TODO: add timestamp for non local network
        public NetPlayer(string nick)
        {
            this.nick = nick;
            this.Position = new Vector3();
            this.Rotation = new Vector3();
        }

        public NetPlayer(string nick, Vector3 position, Vector3 rotation)
        {
            this.nick = nick;
            this.Position = position;
            this.Rotation = rotation;
        }

        public NetPlayer(string nick, Transform transform)
        {
            this.nick = nick;
            this.Position = transform.position;
            this.Rotation = transform.rotation.eulerAngles;
        }

        public Vector3 Rotation
        {
            get => rotation.Vector3;
            set
            {
                rotation.x = value.x;
                rotation.y = value.y;
                rotation.z = value.z;
            }
        }

        public Vector3 Position
        {
            get => position.Vector3;
            set
            {
                position.x = value.x;
                position.y = value.y;
                position.z = value.z;
            }
        }

        public Transform Transform
        {
            set
            {
                Position = value.position;
                Rotation = value.rotation.eulerAngles;
            }
        }

        [SerializeField] public string nick = String.Empty;
        [SerializeField] public SVector position = new SVector(Vector3.zero);
        [SerializeField] public SVector rotation = new SVector(Vector3.zero);
    }

    [Serializable]
    public class Respawn
    {
        public string nick = String.Empty;
        public Respawn(string nick)
        {
            this.nick = nick;
        }
    }
    [Serializable]
    public class SVector
    {
        public float x;
        public float y;
        public float z;

        public SVector(Vector3 position)
        {
            x = position.x;
            y = position.y;
            z = position.x;
        }

        public Vector3 Vector3
        {
            get => new Vector3(x, y, z);
            set
            {
                x = value.x;
                y = value.y;
                z = value.z;
            }
        }
    }

    #endregion
}