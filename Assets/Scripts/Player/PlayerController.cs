using System;
using System.Collections;
using Player;
using UnityEngine;
using Utils;

public class PlayerController : MonoBehaviour {
    public States _curState;

    [Header("基础组件")]
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public Collider2D footCollider2D;
    public GameObject attackArea;

    [Header("输入相关")]
    public KeyCode attackInput;
    public KeyCode defenceInput;
    public KeyCode jumpInput;

    [Header("运动数值")]
    public float moveSpeed;
    public float accleration;
    public float jumpForce;
    public float upGravity;
    public float downGravity;

    [Header("攻击数值")]
    public float maxHp;
    public float curHp;
    public float baseDamage;
    public float backNum;
    public float damageReflect;
    public float onDefenceDamageFactor;
    public float damageAreaRadius;
    public bool enableDamageReflect;

    [Header("状态boolean")]
    public bool onGround = true;
    public bool canMove = true;
    public bool canJump = false;
    public bool canAttack = true;
    public bool isMove = false;
    public bool invince = false;

    private Vector2 _startPoint;
    private AudioSource _getHitSound;
    private AudioSource _jumpSound;

    private void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = transform.Find("Model").GetComponent<Animator>();
        footCollider2D = this.transform.GetChild(0).GetComponent<Collider2D>();
        attackArea = this.transform.GetChild(1).gameObject;
        _startPoint = this.transform.position;
        EventCenter.GetInstance().AddEventListener(tag == "Player1" ? EventTypes.Player2Attack : EventTypes.Player1Attack, this.CheckIfBeingDamaged);
        _getHitSound = GameObject.Find("BeingAttackSound").GetComponent<AudioSource>();
        _jumpSound = GameObject.Find("JumpSound").GetComponent<AudioSource>();

        StopAllCoroutines();
    }

    private void OnEnable() {
        GeneMatch();

        onGround = true;
        canMove = true;
        canJump = false;
        canAttack = true;
        isMove = false;
        invince = false;
        attackArea.SetActive(false);

        switch (this.CompareTag("Player1") ? GlobalManager.P1PredictResult : GlobalManager.P2PredictResult) {
            case PredictResult.LostHp:
                maxHp -= UnityEngine.Random.Range(5, 9);
                break;

            case PredictResult.ImproveDamage:
                baseDamage += UnityEngine.Random.Range(4, 12);
                break;

            default: throw new ArgumentOutOfRangeException();
        }

        curHp = maxHp;
        transform.position = _startPoint;
    }

    private void OnDisable() {
        StopAllCoroutines();
    }

    private void OnDestroy() {
        EventCenter.GetInstance().RemoveEventListener(tag == "Player1" ? EventTypes.Player2Attack : EventTypes.Player1Attack, this.CheckIfBeingDamaged);
    }

    private void Update() {
        GroundCheck();

        if (rigidbody2D.velocity.y >= 0.5f) {
            rigidbody2D.gravityScale = upGravity;
        } else {
            rigidbody2D.gravityScale = downGravity;
        }

        do {
            if (_curState == States.Die) {
                return;
            }

            if (curHp < 0) {
                _curState = States.Die;
                break;
            }

            if (_curState == States.GetHit) {
                break;
            }

            if (_curState == States.Attack) {
                break;
            }

            if (Input.GetKeyDown(attackInput) && canAttack) {
                _curState = States.Attack;
                break;
            }

            if (Input.GetKeyDown(defenceInput) && onGround) {
                _curState = States.Defence;
                break;
            }

            if (!onGround) {
                _curState = States.Air;
                break;
            }
        } while (false);


        if (canMove) HorizontalMove();

        switch (_curState) {
            case States.Idle:
                IdleHandler();

                _moveEntered = false;
                _airEntered = false;
                _attackEntered = false;
                _defenceEntered = false;
                _getHitEntered = false;
                attackArea.SetActive(false);
                break;

            case States.Move:
                MoveHandler();

                _idleEntered = false;
                _airEntered = false;
                _attackEntered = false;
                _defenceEntered = false;
                _getHitEntered = false;
                attackArea.SetActive(false);
                break;

            case States.Air:
                AirHandler();

                _idleEntered = false;
                _moveEntered = false;
                _attackEntered = false;
                _defenceEntered = false;
                _getHitEntered = false;
                attackArea.SetActive(false);
                break;

            case States.Attack:
                AttackHandler();

                _idleEntered = false;
                _moveEntered = false;
                _airEntered = false;
                _defenceEntered = false;
                _getHitEntered = false;
                break;

            case States.Defence:
                DefenceHandler();

                _idleEntered = false;
                _moveEntered = false;
                _airEntered = false;
                _attackEntered = false;
                _getHitEntered = false;
                attackArea.SetActive(false);
                break;

            case States.GetHit:
                GetHitHandler();

                _idleEntered = false;
                _moveEntered = false;
                _airEntered = false;
                _attackEntered = false;
                _defenceEntered = false;
                attackArea.SetActive(false);
                break;

            case States.Die:
                canMove = false;
                onGround = false;
                canJump = false;
                canAttack = false;
                break;

            default: throw new ArgumentOutOfRangeException();
        }
    }

    public void GroundCheck() {
        onGround = footCollider2D.IsTouchingLayers(1 << LayerMask.NameToLayer("Ground"));
    }

    private void HorizontalMove() {
        var input = Input.GetAxisRaw("Horizontal" + (this.CompareTag("Player1") ? "1" : "2"));
        isMove = input != 0;
        var rb = rigidbody2D;
        var curSpeed = rb.velocity.x;
        var tarSpeed = moveSpeed;
        var tmp = input == 0 ? 0 : tarSpeed;

        curSpeed = Mathf.Lerp(curSpeed, tmp * input, accleration);
        rb.velocity = new Vector2(curSpeed, rb.velocity.y);
        if (input != 0)
            transform.eulerAngles = input > 0
                ? new Vector3(0, 0, 0)
                : new Vector3(0, 180, 0);
    }

    private void GeneMatch() {
        var gene = this.CompareTag("Player1") ? GlobalManager.P1CurDNA_str : GlobalManager.P2CurDNA_str;
        // var gene = "Cc";
        GetComponent<GeneDiff>().GeneSelect(gene);
        // TODO 基因引发的数值变化
        if (gene.Contains("AA")) {
            baseDamage = 27;
        } else if (gene.Contains("Aa") || gene.Contains("aA")) {
            baseDamage = 22;
        } else {
            baseDamage = 18;
        }

        if (gene.Contains("BB")) {
            enableDamageReflect = true;
            damageReflect = 16;
        } else if (gene.Contains("Bb") || gene.Contains("bB")) {
            enableDamageReflect = true;
            damageReflect = 9;
        } else {
            enableDamageReflect = false;
        }

        if (gene.Contains("CC")) {
            moveSpeed = 9;
        } else if (gene.Contains("Cc") || gene.Contains("cC")) {
            moveSpeed = 7;
        } else {
            moveSpeed = 5;
        }
    }

    private bool _idleEntered = false;
    private bool _moveEntered = false;
    private bool _airEntered = false;
    private bool _attackEntered = false;
    private bool _defenceEntered = false;
    private bool _getHitEntered = false;

    private void IdleHandler() {
        if (!_idleEntered) {
            animator.Play("idle");
            canMove = true;
            canJump = onGround;
            rigidbody2D.gravityScale = upGravity;
            _idleEntered = true;
        }

        if (Input.GetKeyDown(jumpInput) && onGround) {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
            _jumpSound.Play();
            _curState = States.Air;
        }

        if (!Mathf.Approximately(rigidbody2D.velocity.x, 0) && onGround) {
            _curState = States.Move;
        }
    }

    private void CheckIfBeingDamaged() {
        if (invince) return;
        var enemy = GameObject.FindWithTag(this.CompareTag("Player1") ? "Player2" : "Player1");
        var enemyAttackCenter = enemy.GetComponent<PlayerController>().attackArea.transform.position;
        if ((enemyAttackCenter - this.transform.position).magnitude < damageAreaRadius) {
            if (_curState == States.Defence) curHp -= enemy.GetComponent<PlayerController>().baseDamage * onDefenceDamageFactor;
            else curHp -= enemy.GetComponent<PlayerController>().baseDamage;
            if (this.enableDamageReflect) {
                enemy.GetComponent<PlayerController>().curHp -= damageReflect;
            }
            _curState = States.GetHit;
        }
    }

    private void MoveHandler() {
        if (!_moveEntered) {
            animator.Play("move");
            _moveEntered = true;
        }

        if (Mathf.Approximately(rigidbody2D.velocity.x, 0)) {
            _curState = States.Idle;
        }
        if (Input.GetKeyDown(jumpInput) && onGround) {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
            _jumpSound.Play();
            _curState = States.Air;
        }
    }

    private void AirHandler() {
        if (!_airEntered) {
            animator.Play("Jump");
            _airEntered = true;
        }

        if (onGround) {
            _curState = States.Move;
        }

        canJump = false;
    }

    private void AttackHandler() {
        if (!_attackEntered) {
            animator.Play(UnityEngine.Random.Range(0, 10) > 4 ? "attack1" : "attack2");
            attackArea.SetActive(true);
            canAttack = false;
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            // StopCoroutine(WaitTime());
            // StartCoroutine(WaitTime());
            _attackEntered = true;
            StopCoroutine(IntervalJudge());
            StartCoroutine(IntervalJudge());
        }


        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.98f) {
            attackArea.SetActive(false);
            _curState = States.Move;
            canAttack = true;
            canMove = true;
        }
    }

    IEnumerator IntervalJudge() {
        var len = animator.GetCurrentAnimatorStateInfo(0).length;
        for (int i = 0; i < 3; ++i) {
            if (!GameObject.FindWithTag(this.CompareTag("Player1") ? "Player2" : "Player1").GetComponent<PlayerController>().invince)
                EventCenter.GetInstance().EventTrigger(tag == "Player1" ? EventTypes.Player1Attack : EventTypes.Player2Attack);
            yield return new WaitForSecondsRealtime(len / 3.1f);
        }
        attackArea.SetActive(false);
        _curState = States.Move;
        canAttack = true;
        canMove = true;
    }

    private void DefenceHandler() {
        if (!_defenceEntered) {
            animator.Play("Defence");
            _defenceEntered = true;
        }

        if (Input.GetKeyUp(defenceInput)) {
            _curState = States.Move;
        }
    }

    private void GetHitHandler() {
        if (!_getHitEntered) {
            animator.Play("Fall");
            _getHitSound.Play();
            canMove = false;
            _getHitEntered = true;
            invince = true;
            var enemy = GameObject.FindWithTag(this.CompareTag("Player1") ? "Player2" : "Player1");
            var val = this.transform.position.x - enemy.transform.position.x;
            this.transform.position += new Vector3(0, 0.1f, 0);
            this.rigidbody2D.velocity = backNum * new Vector2(val, Mathf.Abs(val)).normalized;
        }

        StopCoroutine(GetHitTrick());
        StartCoroutine(GetHitTrick());
    }

    IEnumerator GetHitTrick() {
        yield return new WaitForSecondsRealtime(0.4f);
        canMove = true;

        _curState = States.Move;
        yield return new WaitForSecondsRealtime(0.7f);
        invince = false;
    }
}