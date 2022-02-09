using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CController_Player : CBase_Character
{
    public bool CanMove = false;
    public bool CanSwipe = false;
    public CController_Enemy CurrentEnemy;
    [SerializeField] private float MovementSpeed_Z = 6;
    [SerializeField] private float MovementSpeed_X = 10;
    [SerializeField] private int CurrentLane = 1;
    [SerializeField] private float LaneDistance = 0.50f;
    [SerializeField] public int LaneCount = 2;
    [SerializeField] float TargetX;
    public int DefeatedEnemyCount;

    private CharacterController CharacterController;
    protected override void Awake()
    {
        base.Awake();
        CharacterController = GetComponent<CharacterController>();

        TargetX = 0;
    }
    private void Start()
    {
        CManager_UI.Instance.SetCollectableCount(Level);
        CWorld.Instance.TimelineManager.PlayStartingTimeline();
    }
    private void Update()
    {
        if(!CanMove || CWorld.Instance.TimelineManager.IsStartTimelinePlaying()) return;

        Movement();
    }
    private void LateUpdate()
    {
        Animator.SetBool("IsMoving", (CanMove && CharacterController.velocity.magnitude > 0));
    }
    public void ToLeft()
    {
        if(CurrentLane > 0 && CanSwipe) 
        {
            CurrentLane--;
            TargetX -= LaneDistance;
        } 
    }
    public void ToRight()
    {
        if(CurrentLane < LaneCount && CanSwipe)
        {
            CurrentLane++;
            TargetX += LaneDistance;
        } 
    }
    private void Movement()
    {
        if (Input.GetKeyDown(KeyCode.D)) ToRight();
        if (Input.GetKeyDown(KeyCode.A)) ToLeft();

        float x = Mathf.Abs( TargetX - transform.position.x) > 0 ? TargetX - transform.position.x  : 0;
        CharacterController.Move(new Vector3(x * MovementSpeed_X, 0, 1 * MovementSpeed_Z) * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider P_Collider)
    {
        if(P_Collider.gameObject != this.gameObject)
        {
            if(P_Collider.gameObject.layer == LayerMask.NameToLayer("Collectable"))
            {
                Level++;
                UpdateLevelText();
                GameObject.Destroy(P_Collider.gameObject);
            }
            else if(P_Collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                CurrentEnemy = P_Collider.gameObject.GetComponentInParent<CController_Enemy>();
                if(CurrentEnemy == null) return;
                
                CanMove = false;
                CanSwipe = false;

                if(Level > CurrentEnemy.Level) // Player Wins
                {
                    CurrentEnemy.Text_Level.gameObject.SetActive(false);
                    CurrentEnemy.Animator.SetTrigger("OnTerrified");

                    Animator.SetTrigger("OnAttack");
                    Animator.SetInteger("AttackIndex", AttackIndex);
                }
                else // Enemy Wins
                {
                    Text_Level.gameObject.SetActive(false);
                    Animator.SetTrigger("OnTerrified");

                    CurrentEnemy.Animator.SetTrigger("OnAttack");
                    CurrentEnemy.Animator.SetInteger("AttackIndex", CurrentEnemy.AttackIndex);
                }
            }
            else if(P_Collider.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
            {
                CanMove = false;

                Text_Level.gameObject.SetActive(false);
                Animator.SetTrigger("OnTerrified");
                Animator.SetTrigger("OnHit");

                CWorld.Instance.SceneManager.StartLoad(true, false);
            }
            else if(P_Collider.gameObject.layer == LayerMask.NameToLayer("Buff"))
            {
                CBuffObject buff = P_Collider.gameObject.GetComponent<CBuffObject>();
                if(buff == null) return;

                Level = (buff.BuffType == EBuffType.MULTIPLICATION) ? Level * buff.BuffAmount : Level + buff.BuffAmount;
                UpdateLevelText();

                GameObject.Destroy(P_Collider.gameObject);
            }
            else if(P_Collider.gameObject.layer == LayerMask.NameToLayer("Finish"))
            {
                CanMove = false;
                CanSwipe = false;

                CWorld.Instance.TimelineManager.PlayEndingTimeline();
                
                if(Level >= CWorld.Instance.TargetCollectableCount) Animator.SetTrigger("OnVictory");
                else Animator.SetTrigger("OnDefeat");
            }
        }
    }
    public override void UpdateLevelText()
    {
        base.UpdateLevelText();
        if(CManager_UI.Instance) CManager_UI.Instance.SetCollectableCount(Level);
    }
}
