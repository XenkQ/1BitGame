using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("Physics")]
    [HideInInspector] public Rigidbody2D characterRigidBody2D;
    private BoxCollider2D playerCollider;

    [Header("Character Spawn")]
    [SerializeField] private Transform newLvlSpawnPoint;
    [SerializeField] private Transform exitLvlPoint;
    [SerializeField] private float transformYOffset = -4.54f;

    [Header("Character Death")]
    [SerializeField] private ParticleSystem deathParticle;
    [HideInInspector] public bool IsDead { get; private set; } = false;

    [Header("Sounds")]
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private AudioClip deathSound;


    private void Awake()
    {
        characterRigidBody2D = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        CharacterRestartProcess();
    }

    private void Update()
    {
        CharacterDeathProcessIfIsDead();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            IsDead = true;
        }
    }

    public void TeleportToNewLvlPoint()
    {
        transform.position = new Vector2(newLvlSpawnPoint.position.x, transformYOffset);
    }

    private void CharacterDeathProcessIfIsDead()
    {
        if(IsDead && spriteRenderer.gameObject.active != false)
        {
            DisablePlayerSprite();
            MakeKinematicBodyType();
            DisableCharacterCollision();
            deathParticle.Play();
            PlayDeathSound();
        }
    }

    private void DisablePlayerSprite()
    {
        spriteRenderer.gameObject.SetActive(false);
    }

    public void MakeKinematicBodyType()
    {
        characterRigidBody2D.bodyType = RigidbodyType2D.Kinematic;
    }

    private void DisableCharacterCollision()
    {
        playerCollider.enabled = false;
    }

    private void PlayDeathSound()
    {
        soundManager.PlaySound(deathSound);
    }

    public void CharacterRestartProcess()
    {
        IsDead = false;
        spriteRenderer.gameObject.SetActive(true);
        MakeDynamicBodyType();
    }

    public void MakeDynamicBodyType()
    {
        characterRigidBody2D.bodyType = RigidbodyType2D.Dynamic;
    }
}
