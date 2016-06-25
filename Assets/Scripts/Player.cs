using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;
using System;
using Assets.Scripts.Attributes;
using System.Reflection;

public class Player : MonoBehaviour {

    public enum AttributeType
    {
        MoveSpeed,
        HitPointsTotal,
        ShieldTotal,
        ShieldDuration,
        PrimaryFireRate,
        PrimaryReloadSpeed,
        PrimaryProjectileSpeed,
        PrimaryDamage,
        SecondaryFireRate,
        SecondaryReloadSpeed,
        SecondaryProjectileSpeed,
        SecondaryDamage,
        SecondaryAmmoMax,
        SecondayAmmoRemaining,
        TurnSpeed
    }

    internal string GetAttributeString()
    {
        string str = "";

        str += "MoveSpeed: "                  + MoveSpeed;
        str += "\nTurnSpeed: "                + TurnSpeed;
        str += "\nHitPointsTotal: "           + HitPointsTotal;
        str += "\nShieldTotal: "              + ShieldTotal;
        str += "\nShieldDuration: "           + ShieldDuration;
        str += "\nPrimaryDamage: "            + PrimaryDamage;
        str += "\nPrimaryProjectileSpeed: "   + PrimaryProjectileSpeed;
        str += "\nPrimaryFireRate: "          + PrimaryFireRate;
        str += "\nPrimaryReloadSpeed: "       + PrimaryReloadSpeed;
        str += "\nSecondaryDamage: "          + SecondaryDamage;
        str += "\nSecondaryProjectileSpeed: " + SecondaryProjectileSpeed;
        str += "\nSecondaryFireRate: "        + SecondaryFireRate;
        str += "\nSecondaryReloadSpeed: "     + SecondaryReloadSpeed;
        str += "\nSecondaryAmmoMax: "         + SecondaryAmmoMax;

        return str;
    }

    public enum BonusType
    {
        Raw,
        Final
    }

    Vector3 translate = new Vector3(0, 0, 0.005f), rotate  = new Vector3(5f, 0, 0);

    public void Destroy()
    {
        this.gameObject.SetActive(false);
    }

    public float jitter = 0.001f;
    Vector3 startPosition, startRotation;

    public HitPoints HP;
    public Shield Shield;
    public Hull Hull;
    public Wings Wings;
    public Weapon PrimaryWeapon;
    public SecondaryWeapon SecondaryWeapon;

    // Player's Attributes
    public CustomAttribute MoveSpeed                = new CustomAttribute(0);
    public CustomAttribute TurnSpeed                = new CustomAttribute(0);
    public CustomAttribute HitPointsTotal           = new CustomAttribute(0);
    public CustomAttribute ShieldTotal              = new CustomAttribute(0);
    public CustomAttribute ShieldDuration           = new CustomAttribute(0);
    public CustomAttribute PrimaryDamage            = new CustomAttribute(0);
    public CustomAttribute PrimaryProjectileSpeed   = new CustomAttribute(0);
    public CustomAttribute PrimaryFireRate          = new CustomAttribute(0);
    public CustomAttribute PrimaryReloadSpeed       = new CustomAttribute(0);
    public CustomAttribute SecondaryDamage          = new CustomAttribute(0);
    public CustomAttribute SecondaryProjectileSpeed = new CustomAttribute(0);
    public CustomAttribute SecondaryFireRate        = new CustomAttribute(0);
    public CustomAttribute SecondaryReloadSpeed     = new CustomAttribute(0);
    public CustomAttribute SecondaryAmmoMax         = new CustomAttribute(0);

    public List<BaseAttribute> attributes;

    // Use this for initialization
    void Start ()
    {
        startPosition = this.transform.position;
        startRotation = this.transform.eulerAngles;

        // MoveSpeed.BaseValue = 2;

        // add attributes to primary weapon.
        PrimaryWeapon.Damage = PrimaryDamage;
        PrimaryWeapon.ProjectileSpeed = PrimaryProjectileSpeed;
        PrimaryWeapon.FireRate = PrimaryFireRate;
        PrimaryWeapon.ReloadSpeed = PrimaryReloadSpeed;

        // Add attributes to secondary weapon.
        SecondaryWeapon.Damage = SecondaryDamage;
        SecondaryWeapon.ProjectileSpeed = SecondaryProjectileSpeed;
        SecondaryWeapon.FireRate = SecondaryFireRate;
        SecondaryWeapon.ReloadSpeed = SecondaryReloadSpeed;
        SecondaryWeapon.AmmoMax = SecondaryAmmoMax;
    }


    // Update is called once per frame
    void Update ()
    {
        // add some rotation and position movement to accompany the world rotating.
        Vector3 trn, rt;
        float horiz;
        horiz = Input.GetAxisRaw("Horizontal");
        trn = translate * horiz;
        rt = rotate * horiz;

        this.transform.position = startPosition + trn;
        this.transform.eulerAngles = startRotation + rt;

        // Add some jitter to the ship to make it seem like it actually has an engine.
        AddPositionalNoise();

        if (Input.GetButton("Fire1"))
        {
            PrimaryWeapon.Fire();
        }
    }
    void AddPositionalNoise()
    {
        // reset position to start position, this allows us to not shift the player off it's start point 
        // (e.g. if the x axis had larger -ve numbers added to it more often that +ve then it would move the player).
        transform.position = startPosition;
        float x = UnityEngine.Random.Range(-jitter, jitter);
        float y = UnityEngine.Random.Range(-jitter, jitter);
        float z = UnityEngine.Random.Range(-jitter, jitter);
        transform.Translate(x, y, z);
    }

    public void AddBonus(Player.AttributeType attribute, BaseAttribute bonus)
    {
        ManageBonus(attribute, BonusType.Raw, bonus, "AddBonus");
    }
    
    public void RemoveBonus(Player.AttributeType attribute, BaseAttribute bonus)
    {
        RemoveBonus(attribute, BonusType.Raw, bonus);
    }

    public void RemoveBonus(Player.AttributeType attribute, BonusType bt, BaseAttribute bonus)
    {
        ManageBonus(attribute, bt, bonus, "RemoveBonus");
    }

    /// <summary>
    /// Adds or removes (which are currently only two functions) the specified bonus of the given 
    /// bonus type from the given attribute.
    /// </summary>
    /// <param name="attribute">AttributeType that corresponds to an attribute instance on the player.</param>
    /// <param name="bt">The BonusType which describes which type of bonus is being managed.</param>
    /// <param name="bonus">The bonus instance which will be applied to the attribute instance.</param>
    /// <param name="methodName">The name of the method to invoke on the attribute instance.</param>
    private void ManageBonus(Player.AttributeType attribute, BonusType bt, BaseAttribute bonus, string methodName)
    {
        // Get the type of this instance.
        var type = this.GetType();

        // Get the field information of this instance where the field's name is the same as the attribute given.
        var attributeName = Enum.GetName(attribute.GetType(), attribute);
        var fieldInfo = type.GetField(attributeName);

        // Get the instance of the field, so we can invoke it's method later.
        var attr = fieldInfo.GetValue(this);

        // Declare the type of all arguments in the method signature.
        var methodAgrTypes = new Type[] { bt.GetType(), bonus.GetType() };

        // Find the AddBonus method with the given signature and name. e.g - AddBonus(Player.BonusType, BaseAttribute)
        var method = fieldInfo.FieldType.GetMethod(methodName, methodAgrTypes);

        // Declare the arguments to be passed to the method call.
        var args = new object[] { bt, bonus };

        // Invoke the method.
        method.Invoke(attr, args);

        // This whole process is exactly the same as calling this.HitPointsTotal.AddBonus(bt, bonus)
        // Assuming that attribute = Player.AttributeType.HitPointsTotal.

        // Pretty much it's leveraging Relfection to use the AttributeType enum to point at CustomAttributes
        // Defined on this instance of Player.
    }
}
