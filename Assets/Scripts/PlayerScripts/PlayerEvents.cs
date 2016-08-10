using Assets.Scripts.Enums;

namespace Assets.Scripts.PlayerScripts
{
    /// <summary>
    /// Holds all eventhandlers for the Player, other components of the Player can Raise the events.
    /// Anything else can only subscribe to the events.
    /// </summary>
    public partial class Player
    {
        public delegate void MovedHandler(float distance);
        public event MovedHandler OnMoved = delegate { };
        
        public delegate void TurningBeginHandler(Direction dir);
        public event TurningBeginHandler OnTurningBegin = delegate { };

        public delegate void TurningEndHandler(Direction dir);
        public event TurningEndHandler OnTurningEnd = delegate { };

        /// <summary>
        /// Taking damage, regardless if it's shield or HP damage.
        /// </summary>
        /// <param name="damage">Amount of damage taken.</param>
        /// <param name="source">The object that caused the damage.</param>
        public delegate void TakeDamageHandler(int damage, object source);
        public event TakeDamageHandler OnTakeDamage = delegate { };

        public delegate void TakeHPDamageHandler(int damage, object source);
        public event TakeHPDamageHandler OnTakeHPDamage = delegate { };

        public delegate void TakeShieldDamageHandler(int damage, object source);
        public event TakeShieldDamageHandler OnTakeShieldDamage = delegate { };

        public delegate void KilledHandler(object source);
        public event KilledHandler OnKilled = delegate { };

        public delegate void ShieldDestroyedHandler(object source);
        public event ShieldDestroyedHandler OnShieldDestroyed = delegate { };

        public delegate void CollectedPickupHandler(PickupType type);
        public event CollectedPickupHandler OnCollectedPickup = delegate { };

        public delegate void FiredPrimaryHandler();
        public event FiredPrimaryHandler OnFiredPrimary = delegate { };

        public delegate void FiredSecondaryHandler();
        public event FiredSecondaryHandler OnFiredSecondary = delegate { };

        public delegate void CollisionHandler(object other);
        public event CollisionHandler OnCollision = delegate { };
    }
}
