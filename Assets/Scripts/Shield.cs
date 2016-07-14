using System;
using UnityEngine;

public class Shield : MonoBehaviour// : AComponent
{

    public delegate void Change();

    public static event Change OnChange = delegate { };
    private float _total;
    public float Total
    {
        get { return _total; }
        set
        {
            if (Remaining == Total)
                Remaining = _total = value;
            else
                _total = value;
        }
    }

    private float _remaining;
    public float Remaining
    {
        get { return _remaining; }
        set
        {
            OnChange();
            _remaining = value;
        }
    }

    public float DecayRate { get; private set; }

    public void Initialize(int total, float decayRate)
    {
        Initialize(total, decayRate, false);
    }

    public void Initialize(int total, float decayRate, bool startActive)
    {
        Remaining = Total = Convert.ToSingle(total);
        
        DecayRate = decayRate;
        if (!startActive)
        {
            this.DeActivate();
            Remaining = 0;
        }
    }

    void Update()
    {
        //print("Shield: Update called!");
        // Check if the shield is up first.
        if (Active)
        {
            //print("Shield: Active is true so reducing Remaining Amount ("+Remaining+") by delta time " + Time.deltaTime);
            // Shield is up, start reducing it's duration.
            Remaining -= Time.deltaTime * DecayRate;
        }
    }

    /// <summary>
    /// Wrapper for Alive function.
    /// </summary>
    /// <returns>true if the shield is active, false if it is not.</returns>
    public bool Active { get { return Remaining > 0; } }

    /// <summary>
    /// Activates the shield, bringing it to full capacity and setting it's remaining duration to the maximum.
    /// </summary>
    public void Activate()
    {
        Heal();
    }

    public void DeActivate()
    {
        Remaining = 0;
    }

    /// <summary>
    /// Sets remaining HitPoints equal to total, basically fully heals the unit.
    /// </summary>
    public void Heal()
    {
        Heal(Total - Remaining);
    }
    /// <summary>
    /// Adds the specified amount of hitpoints to the unit's remaining HitPoints.
    /// Cannot heal the unit above it's maximum HitPoints.
    /// </summary>
    /// <param name="amountToHeal">The amount of HitPoints to heal the unit by.</param>
    public void Heal(float amountToHeal)
    {
        Remaining += amountToHeal;
    }

    public float PercentRemaining()
    {
        return Remaining / Total;
    }

    //public RawBonus ShieldDurationBonus = new RawBonus(1f);
    //public RawBonus ShieldTotalBonus = new RawBonus(5f);
    //override protected void AddAttributesToPlayer()
    //{
    //    player.ShieldDuration.AddRawBonus(ShieldDurationBonus);
    //    player.ShieldTotal.AddRawBonus(ShieldTotalBonus);
    //}
    //override protected void RemoveAttributesFromPlayer()
    //{
    //    player.ShieldDuration.RemoveRawBonus(ShieldDurationBonus);
    //    player.ShieldTotal.RemoveRawBonus(ShieldTotalBonus);
    //}
}