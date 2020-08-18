
using Assets.HeroEditor4D.Common.CharacterScripts;
using System.Collections;
using UnityEngine;

public class PlayerMovement : Movement
{
    public CharacterAnimation CharacterAnimation;
   // [SerializeField] public AnimatorController anim;
  //  [SerializeField] private StateMachine myState;
    [SerializeField] private float WeaponAttackDuration;
   // [SerializeField] private ReceiveItem myItem;
   // [SerializeField] public GenericAbility currentAbility;

    private Vector2 tempMovement = Vector2.down;
  //  private Vector2 facingDirection = Vector2.down;


    void Start()
    {
      //  CharacterAnimation.SetState(CharacterState.Walk);
    }


    //public bool UpdateSword() {
    //    if (anim.GetAnimBool("Gold"))
    //    {
    //        anim.SetAnimParameter("Gold", false);
    //    } else
    //    {
    //        anim.SetAnimParameter("Gold", true);
    //    }
    //    return anim.GetAnimBool("Gold");
    //}
    void Update()
    {
        //if (myState.myState == GenericState.receiveItem)
        //{
        //    if (Input.GetButtonDown("Check"))
        //    {
        //        myState.ChangeState(GenericState.idle);
        //        anim.SetAnimParameter("ReceiveItem", false);
        //        myItem.ChangeSpriteState();
        //    }
        //    return;
        //}

        //if (!IsrestrictedState(myState.myState))
        //{
            GetInput();
            SetAnimation();
        //}

    }

   

    //bool IsrestrictedState(GenericState currentState)
    //{
    //    if (currentState == GenericState.attack || currentState == GenericState.ability)
    //    {
    //        return true;
    //    }
    //    return false;
    //}
    //void SetState(GenericState newState)
    //{
    //    myState.ChangeState(newState);
    //}


    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            CharacterAnimation.Attack();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {

            CharacterAnimation.SetState(CharacterState.Run);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {

            CharacterAnimation.SetState(CharacterState.Walk);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {

            CharacterAnimation.SetState(CharacterState.Jump);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {

            CharacterAnimation.SetState(CharacterState.Climb);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {

            CharacterAnimation.Die();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {

            CharacterAnimation.Hit();
        }
        
        // if (Input.GetButtonDown("Attack"))
        //{
        //    StartCoroutine(WeaponCo());
        //    tempMovement = Vector2.zero;
        //    Motion(tempMovement);
        //}
        //else if (Input.GetButtonDown("Ability") && currentAbility)
        //{

        //    StartCoroutine(AbilityCo(currentAbility.duration));
        //}
        // else
        // if (CharacterAnimation.GetState() == CharacterState.Walk)
        {
            
            tempMovement.x = Input.GetAxisRaw("Horizontal");
         
                tempMovement.y = Input.GetAxisRaw("Vertical");
         
            Motion(tempMovement);
        }
        //else
        //{
            
        //    tempMovement = Vector2.zero;
        //    Motion(tempMovement);
        //}
    }
    
    void SetAnimation()
    {
       
        if (tempMovement.magnitude > 0)
        {

            // anim.SetAnimParameter("Look X", Mathf.Round(tempMovement.x));
            //anim.SetAnimParameter("Look Y", Mathf.Round(tempMovement.y));
            // anim.SetAnimParameter("Moving", true);
           
            GetComponent<Character4D>().SetDirection(tempMovement);
            //facingDirection = tempMovement;
        }
        else
        {
            // anim.SetAnimParameter("Moving", false);
            //  if (myState.myState != GenericState.attack)
            //  {
            //      SetState(GenericState.idle);
            //  }
          //  CharacterAnimation.SetState(CharacterState.Idle);
        }
    }

    //public IEnumerator WeaponCo()
    //{
    //    myState.ChangeState(GenericState.attack);
    //    anim.SetAnimParameter("Attacking", true);
    //    yield return new WaitForSeconds(WeaponAttackDuration);
    //    myState.ChangeState(GenericState.idle);
    //    anim.SetAnimParameter("Attacking", false);
    //}

    //public IEnumerator AbilityCo(float abilityDuration)
    //{
    //    myState.ChangeState(GenericState.ability);
    //    if (currentAbility.name == "ArrowAbility" || currentAbility.name == "BouncyBall")
    //    {
    //        anim.SetAnimParameter("Bow", true);
    //    }
    //    currentAbility.Ability(transform.position, facingDirection, anim.anim, myRigidbody);

    //    yield return new WaitForSeconds(abilityDuration);
    //    anim.SetAnimParameter("Bow", false);
    //    myState.ChangeState(GenericState.idle);
    //}
}

