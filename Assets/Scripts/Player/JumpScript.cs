using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct FrogSprites
{
    public Sprite idle;
    public Sprite jump;
}

public class JumpScript : MonoBehaviour
{
    [SerializeField] public FrogSprites frogSprite;
    [SerializeField] public SpriteRenderer spriteRenderer;
    private Vector3? _mousePos;
    public float jumpForce = 0.5f;
    private Rigidbody2D _rigidbody2D;
    private CheckFloor _checkFloor;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _checkFloor = GetComponentInChildren<CheckFloor>();
        _checkFloor.enabled = false;
        _rigidbody2D.Sleep();
    }

    private void Start()
    {
    }

    private void Update()
    {
        GetMouse();
        Jump();
    }

    private void GetMouse()
    {
        if (Camera.main && Input.GetMouseButtonDown(0) && !_rigidbody2D.IsAwake())
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _rigidbody2D.WakeUp();
        }
        else
            _mousePos = null;
    }

    private void Jump()
    {
        var vector2 = CalculateVector().normalized;
        if (Vector2.zero == vector2)
            return;
        if (vector2.y < 0.15f)
        {
            Debug.Log("Jump is to low");
            return;
        }

        spriteRenderer.flipX = vector2.x > 0;
        
        spriteRenderer.sprite = frogSprite.jump;
        _rigidbody2D.AddForce(vector2 * jumpForce, ForceMode2D.Impulse);
        _mousePos = null;
        _checkFloor.enabled = true;
    }

    private Vector2 CalculateVector()
    {
        if (_mousePos == null)
            return Vector2.zero;
        return _mousePos.Value - transform.position;
    }
}