using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System;

public class BasicBitchPlayer : MonoBehaviour {

    public static BasicBitchPlayer current;

    [Range(0, 100)]
    public int moveSpeed;
    public float MoveSpeed { get { return moveSpeed / 10f; } set { moveSpeed = Convert.ToInt32(value * 10f); } }
    [Range(0f, 10f)]
    public float TurnSpeed;


    public int coinsCollected;
    public int score;

    public int HitPointsTotal;
    public int ShieldTotal;
    public float ShieldDecayRate;
    public float PrimaryDamage;
    public float PrimaryProjectileSpeed;
    public float PrimaryFireRate;
    public float PrimaryReloadSpeed;
    public float SecondaryDamage;
    public float SecondaryProjectileSpeed;
    public float SecondaryFireRate;
    public float SecondaryReloadSpeed;
    public float SecondaryAmmoMax;

    public bool godMode = false;

    public Weapon PrimaryWeapon;
    public SecondaryWeapon SecondaryWeapon;

    public Shield Shield;
    public HitPoints HP;

    private Vector3 translate = new Vector3(0, 0, 0.005f)
        , rotate = new Vector3(5f, 0, 0)
        , startPosition
        , startRotation;

    [Range(0, 100)]
    public int jitter = 10;

    private float previousMoveSpeed;

    internal void TakeDamage(int damage)
    {
        // If the player has a shield then deal damge to that first.
        if (Shield.Active)
        {
            Shield.Remaining -= damage;
        }
        // Otherwise damage the player's hit points.
        else
        {
            HP.Remaining -= damage;
        }
    }
    public void Kill()
    {
        this.MoveSpeed = 0;
        GameState.EndGame();
        this.gameObject.SetActive(false);
    }

    // Use this for initialization
    void Awake ()
    {
        print("Player Awake() called.");
        BasicBitchPlayer.current = this;
        startPosition = this.transform.position;
        startRotation = this.transform.eulerAngles;
        jitter = 10;
        Shield.Initialize(ShieldTotal, ShieldDecayRate);

        HP = new HitPoints();
        HP.Initialize(HitPointsTotal);
    }

    void Update()
    {
        if (!GameState.IsPaused)
        {
            score += 10;
            if (HP.Remaining <= 0)
            {
                Kill();
            }
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

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                MoveSpeed += 0.1f;
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                MoveSpeed -= 0.1f;

            //if (Input.GetButton("Fire1"))
            //{
            //    PrimaryWeapon.Fire();
            //}
            //if (Input.GetButton("Fire2"))
            //{
            //    SecondaryWeapon.Fire();
            //} 
        }
    }
    void AddPositionalNoise()
    {
        // reset position to start position, this allows us to not shift the player off it's start point 
        // (e.g. if the x axis had larger -ve numbers added to it more often that +ve then it would move the player).
        float jtr = jitter / 10000f;
        transform.position = startPosition;
        float x = UnityEngine.Random.Range(-jtr, jtr);
        float y = UnityEngine.Random.Range(-jtr, jtr);
        float z = UnityEngine.Random.Range(-jtr, jtr);
        transform.Translate(x, y, z);
    }
    void OnEnable()
    {
        GameState.OnPaused += OnPausedHandler;
    }
    void OnDisable()
    {
        GameState.OnPaused -= OnPausedHandler;
    }

    private void OnPausedHandler(bool isPaused)
    {
        if (isPaused)
        {
            previousMoveSpeed = MoveSpeed;
            MoveSpeed = 0;
        }
        else
        {
            MoveSpeed = previousMoveSpeed;
        }
    }
}
