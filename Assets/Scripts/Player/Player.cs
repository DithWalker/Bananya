using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Joystick joystickL;
    [SerializeField] private Joystick joystickR;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth = 100.0f;

    public Health healthBar;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        healthBar.SetHealth(currentHealth - damage);
        currentHealth -= damage;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }


    void Update()
    {
        UpdateJoystickL();
        UpdateJoystickR();
    }

    void UpdateJoystickL()
    {
        float hoz = joystickL.Horizontal;
        float ver = joystickL.Vertical;
        Vector2 convertedXY = ConvertWithCamera(Camera.main.transform.position, hoz, ver);
        Vector3 direction = new Vector3(convertedXY.x, 0, convertedXY.y);
        //   Vector3 direction = new Vector3(convertedXY.x, 0, convertedXY.y).normalized;
        float mag = joystickL.Direction.magnitude;
        transform.Translate(direction * (speed * mag * Time.deltaTime));
    }

    void UpdateJoystickR()
    {
        float hoz = joystickR.Horizontal;
        float ver = joystickR.Vertical;
        Vector2 convertedXY = ConvertWithCamera(Camera.main.transform.position, hoz, ver);
        Vector3 direction = new Vector3(convertedXY.x, 0, convertedXY.y).normalized;
        Vector3 lookAtPosition = transform.position + direction;
        transform.LookAt(lookAtPosition);
    }

    private Vector2 ConvertWithCamera(Vector3 cameraPos, float hor, float ver)
    {
        Vector2 joyDirection = new Vector2(hor, ver).normalized;
        Vector2 camera2DPos = new Vector2(cameraPos.x, cameraPos.z);
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.z);
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

    private void LateUpdate()
    {
    }

    private void OnDisable()
    {
    }

    private void OnDestroy()
    {
    }
}