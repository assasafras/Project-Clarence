using System;
using UnityEngine;

public class HitPoints : MonoBehaviour
{
    //public delegate void RemainingChangedHandler(int newAmount);
    //public event RemainingChangedHandler OnRemainingChanged = delegate { };

    [SerializeField]
    private int total;
    public int Total {
        get {return total; }
        set
        {
            if (Remaining == Total)
                Remaining = total = value;
            else
                total = value;
        }
    }

    [SerializeField]
    private int remaining;
    public int Remaining
    {
        get { return remaining; }
        set
        {
            remaining = value;
            // Notify Listeners that the remaining value has changed.
            //OnRemainingChanged(remaining); 
        }
    }

    public bool Alive
    {
        get { return Remaining > 0; }
    }
    public HitPoints(int total) : this(total, total) { }
    public HitPoints(int total, int remaining) : this (total, remaining, 0) { }

    public HitPoints(int total, int remaining, int minimum)
    {
        Total = total;
        Remaining = remaining;
    }

    public void Kill()
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
    public void Heal(int amountToHeal)
    {
        Remaining += amountToHeal;
    }

    public float PercentRemaining()
    {
        return Convert.ToSingle(Remaining) / Convert.ToSingle(Total);
    }
}