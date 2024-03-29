using Unity.Netcode;
using UnityEngine;

public abstract class Coin : NetworkBehaviour
{
    protected SpriteRenderer _spriteRenderer;
    protected CircleCollider2D _collider2D;
    protected int _coinValue = 10;
    protected bool _alreadyCollected;

    //초기 동기화를 위한 네트워크 변수
    public NetworkVariable<bool> isActive = new NetworkVariable<bool>();

    public abstract int Collect();

    protected void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<CircleCollider2D>();
    }

    public override void OnNetworkSpawn()
    {
        if (IsClient)
        {
            SetVisible(isActive.Value);
        }
    }

    public void SetVisible(bool value)
    {
        _collider2D.enabled = value;
        _spriteRenderer.enabled = value;
    }

    public void SetValue(int value)
    {
        _coinValue = value;
    }
}
