using System;
using Banana;
using UnityEngine;
using Weapon;

public class Player : MonoBehaviour
{
    [SerializeField] private Joystick joystickL;
    [SerializeField] private Joystick joystickR;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth = 100.0f;
    [SerializeField] private GameObject LoseUIPanel;
    [SerializeField] private GameObject JoystickUIPanel;

    public Health healthBar;


    private PlayerAnimator _playerAnimator;
    private Animator _animator;
    private WeaponBase _weapon;

    private void Awake()
    {
        _weapon = GetComponentInChildren<WeaponBase>();
        _playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    public void TakeDamage(float damage)
    {
        float NewHealth = Math.Clamp(currentHealth - damage, 0.0f, maxHealth);

        healthBar.SetHealth(NewHealth);
        currentHealth = NewHealth;
        if (currentHealth == 0.0f)
        {
            Dead();
        }
    }
    
    private Animator animator;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    private void Update()
    {
   

        UpdateJoystickL();
        UpdateJoystickR();
    }

    private void UpdateJoystickL()
    {
        float hoz = joystickL.Horizontal;
        float ver = joystickL.Vertical;
        Vector3 direction = new Vector3(hoz, 0, ver).normalized;
        float mag = joystickL.Direction.magnitude;
        transform.Translate(direction * (speed * mag * Time.deltaTime), Space.World);
        _playerAnimator.Move(mag);
    }

    private void UpdateJoystickR()
    {
        float hoz = joystickR.Horizontal;
        float ver = joystickR.Vertical;
        Vector2 convertedXY = ConvertWithCamera(Camera.main.transform.position, hoz, ver);
        var direction = new Vector3(convertedXY.x, 0, convertedXY.y).normalized;
        var lookAtPosition = transform.position + direction;

        transform.LookAt(lookAtPosition);
    }

    private Vector2 ConvertWithCamera(Vector3 cameraPos, float hor, float ver)
    {
        Vector2 joyDirection = new Vector2(hor, ver).normalized;
        Vector2 camera2DPos = new Vector2(cameraPos.x, cameraPos.z);
        Vector2 cameraToPlayerDirection = (Vector2.zero - camera2DPos).normalized;

        float angle = Vector2.SignedAngle(cameraToPlayerDirection, new Vector2(0, 1));
        Vector2 finalDirection = RotateVector(joyDirection, -angle);
        return finalDirection;
    }

    public Vector2 RotateVector(Vector2 v, float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        float _x = v.x * Mathf.Cos(radian) - v.y * Mathf.Sin(radian);
        float _y = v.x * Mathf.Sin(radian) + v.y * Mathf.Cos(radian);
        return new Vector2(_x, _y);
    }

  

    public void Dead()
    {
        LoseUIPanel.SetActive(true);
        JoystickUIPanel.SetActive(false);

        _animator.Play("Death");
    }
}