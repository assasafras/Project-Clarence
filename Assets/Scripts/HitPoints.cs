using System;
using UnityEngine;

public class HitPoints
{
    public delegate void Change();

    public static event Change OnChange = delegate { };

    private int _total;
    public int Total {
        get {return _total; }
        set
        {
            if (Remaining == Total)
                Remaining = _total = value;
            else
                _total = value;
        }
    }

    private int _remaining;
    public int Remaining
    {
        get { return _remaining; }
        set
        {
            _remaining = value;
            OnChange(); // Notify Listeners that the remaingin value has changed.
        }
    }

    private int _minimum;
    /// <summary>
    /// The amount of remaining hitpoints required to be considered alive.
    /// </summary>
    public int Minimum
    {
        get {return _minimum; }
        set
        {
            // cannot set minimum greater than or equl to Total, so if attempted set it to 1 below Total.
            _minimum = value >= Total ? Total - 1 : value;
        }
    }

    public bool Alive
    {
        get
        {
            return Remaining > Minimum;
        }
    }
    public void Initialize(int total)
    {
        Initialize(total, total);
    }

    public void Initialize(int total, int remaining)
    {
        Initialize(total, remaining, 0);
    }

    public void Initialize(int total, int remaining, int minimum)
    {
        Total = total;
        Remaining = remaining;
        Minimum = minimum;
    }

    public void Kill()
    {
        Remaining = Minimum - 1;
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
    public void Heal(int amountToHeal)
    {
        Remaining += amountToHeal;
    }

    public float PercentRemaining()
    {
        return Convert.ToSingle(Remaining) / Convert.ToSingle(Total);
    }
}