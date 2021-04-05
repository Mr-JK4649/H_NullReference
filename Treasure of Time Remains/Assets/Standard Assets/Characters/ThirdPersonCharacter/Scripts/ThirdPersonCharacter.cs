using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(CapsuleCollider))]
	[RequireComponent(typeof(Animator))]
	public class ThirdPersonCharacter : MonoBehaviour
	{
		[SerializeField] float m_MovingTurnSpeed = 360;
		[SerializeField] float m_StationaryTurnSpeed = 180;
		[SerializeField] float m_JumpPower = 12f;
		[Range(1f, 4f)][SerializeField] float m_GravityMultiplier = 2f;
		[SerializeField] float m_RunCycleLegOffset = 0.2f; //specific to the character in sample assets, will need to be modified to work with others
		[SerializeField] float m_MoveSpeedMultiplier = 1f;
		[SerializeField] float m_AnimSpeedMultiplier = 1f;
		[SerializeField] float m_GroundCheckDistance = 0.1f;

		Rigidbody m_Rigidbody;
		//�S����ZAHA 4��5���@Animator��private����bublic �ɕύX
		public Animator m_Animator;
		bool m_IsGrounded;
		float m_OrigGroundCheckDistance;
		const float k_Half = 0.5f;
		float m_TurnAmount;
		float m_ForwardAmount;
		Vector3 m_GroundNormal;
		float m_CapsuleHeight;
		Vector3 m_CapsuleCenter;
		CapsuleCollider m_Capsule;
		bool m_Crouching;
		bool m_DoubleJumpPossible;

		public bool _input_get;

		bool jumpflg;
		//���g����ҏW///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		//3_26���ҏW �����̃X�N���v�g����菜�����߃R�����g�A�E�g

		//�ʏ푬�x
		//float _Normalspeed = 1f;

		////���͂��ꂽ��
		////�X�s�[�h�A�b�v�v������
		//float _speedup_time_count;

		////AnimetionCurve�ŉ����p�����[�^�쐬
		//[SerializeField]
		//AnimationCurve Speed_parameters;

		////�X�L���̎���
		//[SerializeField]
		//float _Skill_Time = 2;

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		void Start()
		{
			m_Animator = GetComponent<Animator>();
			m_Rigidbody = GetComponent<Rigidbody>();
			m_Capsule = GetComponent<CapsuleCollider>();
			m_CapsuleHeight = m_Capsule.height;
			m_CapsuleCenter = m_Capsule.center;

			m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
			m_OrigGroundCheckDistance = m_GroundCheckDistance;
		}

		//���g����ҏW
		//3��26��_�ҏW�ς�  ��������菜�����߂ɃR�����g�A�E�g
		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
   //     private void Update()
   //     {

			////���͂��ꂽ��v���J�n
			//if (_input_get == true) {
			//	//���Ԍv��
			//	_speedup_time_count += Time.deltaTime;

   //             //���Ԃō�����l���X�s�[�h�ɑ��
   //             m_AnimSpeedMultiplier = Speed_parameters.Evaluate(_speedup_time_count);
   //             m_MoveSpeedMultiplier = Speed_parameters.Evaluate(_speedup_time_count);
			//}

			////������Ԃ��������ԂɂȂ����炽�����烊�Z�b�g
			//if (_speedup_time_count >= _Skill_Time)
			//{
			//	_speedup_time_count = 0;//���Z�b�g
			//	_input_get = false;//���͏�Ԃ��I�t�ɂ���
			//	m_AnimSpeedMultiplier = _Normalspeed;//�ʏ푬�x�ɖ߂�
			//}

			////m_AnimSpeedMultiplier���}�C�i�X�ɂȂ������~���邽��(�ʏ푬�x)1�ȉ��ɂȂ�����ʏ푬�x���ێ�
			//if (m_AnimSpeedMultiplier <= _Normalspeed)
   //         {
			//	m_AnimSpeedMultiplier = _Normalspeed;
   //         }

			//�f�o�b�N�m�F�p
			//Debug.Log(_speedup_time_count);


		//}
		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
		public void Move(Vector3 move, bool crouch, bool jump)
		{

			// convert the world relative moveInput vector into a local-relative
			// turn amount and forward amount required to head in the desired
			// direction.
			if (move.magnitude > 1f) move.Normalize();
			move = transform.InverseTransformDirection(move);
			CheckGroundStatus();
			move = Vector3.ProjectOnPlane(move, m_GroundNormal);
			m_TurnAmount = Mathf.Atan2(move.x, move.z);
			m_ForwardAmount = move.z;

			ApplyExtraTurnRotation();

			// control and velocity handling is different when grounded and airborne:
			if (m_IsGrounded)
			{
				HandleGroundedMovement(crouch, jump);
			}
			else
			{
				HandleAirborneMovement(jump);
			}

			// �S����ZAHA 4��5�� �R�����g�ς� -> ScaleCapsuleForCrouching(crouch);

			PreventStandingInLowHeadroom();

			// send input and other state parameters to the animator
			UpdateAnimator(move);
		}

		//�S���� ZAHA 4��5���@�R�����g�ς݁�
		//���Ⴊ�݋@�\�֐�
		//void ScaleCapsuleForCrouching(bool crouch)
		//{
		//	if (m_IsGrounded && crouch)
		//	{
		//		if (m_Crouching) return;
		//		m_Capsule.height = m_Capsule.height / 2f;
		//		m_Capsule.center = m_Capsule.center / 2f;
		//		m_Crouching = true;
		//	}
		//	else
		//	{
		//		Ray crouchRay = new Ray(m_Rigidbody.position + Vector3.up * m_Capsule.radius * k_Half, Vector3.up);
		//		float crouchRayLength = m_CapsuleHeight - m_Capsule.radius * k_Half;
		//		if (Physics.SphereCast(crouchRay, m_Capsule.radius * k_Half, crouchRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
		//		{
		//			m_Crouching = true;
		//			return;
		//		}
		//		m_Capsule.height = m_CapsuleHeight;
		//		m_Capsule.center = m_CapsuleCenter;
		//		m_Crouching = false;
		//	}
		//}

		void PreventStandingInLowHeadroom()
		{
			// prevent standing up in crouch-only zones
			if (!m_Crouching)
			{
				Ray crouchRay = new Ray(m_Rigidbody.position + Vector3.up * m_Capsule.radius * k_Half, Vector3.up);
				float crouchRayLength = m_CapsuleHeight - m_Capsule.radius * k_Half;
				if (Physics.SphereCast(crouchRay, m_Capsule.radius * k_Half, crouchRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
				{
					m_Crouching = true;
				}
			}
		}

		//�A�j���[�V�����X�V���
		void UpdateAnimator(Vector3 move)
		{
			// update the animator parameters
			m_Animator.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);
			m_Animator.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);
			m_Animator.SetBool("Crouch", m_Crouching);
			m_Animator.SetBool("OnGround", m_IsGrounded);

			//�n�ʂɋ��Ȃ����W�����v�A�j���[�V�����Ă�
			if (!m_IsGrounded)
			{
				m_Animator.SetFloat("Jump", m_Rigidbody.velocity.y);
            }
			// calculate which leg is behind, so as to leave that leg trailing in the jump animation
			// (This code is reliant on the specific run cycle offset in our animations,
			// and assumes one leg passes the other at the normalized clip times of 0.0 and 0.5)
			float runCycle =
				Mathf.Repeat(
					m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime + m_RunCycleLegOffset, 1);
			float jumpLeg = (runCycle < k_Half ? 1 : -1) * m_ForwardAmount;
			
			
			if (m_IsGrounded)
			{
				m_Animator.SetFloat("JumpLeg", jumpLeg);
			}

			// the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
			// which affects the movement speed because of the root motion.
			if (m_IsGrounded && move.magnitude > 0)
			{
				m_Animator.speed = m_AnimSpeedMultiplier;
			}
			else
			{
				// don't use that while airborne
				m_Animator.speed = 1;
			}
		}


		void HandleAirborneMovement(bool jump)
		{
			if (m_DoubleJumpPossible && jump)
			{
				PerfomDoubleJump();
			}
			else
			{

				// apply extra gravity from multiplier:
				Vector3 extraGravityForce = (Physics.gravity * m_GravityMultiplier) - Physics.gravity;
				m_Rigidbody.AddForce(extraGravityForce);

				m_GroundCheckDistance = m_Rigidbody.velocity.y < 0 ? m_OrigGroundCheckDistance : 0.01f;
			}
		}


		void HandleGroundedMovement(bool crouch, bool jump)
		{
			// check whether conditions are right to allow a jump:
			if (jump && !crouch && m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
			{
				// jump!
				m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_JumpPower, m_Rigidbody.velocity.z);
				m_IsGrounded = false;
				m_Animator.applyRootMotion = false;
				m_GroundCheckDistance = 0.1f;
				m_DoubleJumpPossible = true;
			}
		}

        void PerfomDoubleJump()
        {
			// jump!
			//m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_JumpPower, m_Rigidbody.velocity.z);
			//m_IsGrounded = false;
			//m_Animator.applyRootMotion = false;
			//m_GroundCheckDistance = 0.1f;
			//m_DoubleJumpPossible = false;
		}

		void ApplyExtraTurnRotation()
		{
			// help the character turn faster (this is in addition to root rotation in the animation)
			float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
			transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
		}


		public void OnAnimatorMove()
		{
			// we implement this function to override the default root motion.
			// this allows us to modify the positional speed before it's applied.
			if (m_IsGrounded && Time.deltaTime > 0)
			{
				Vector3 v = (m_Animator.deltaPosition * m_MoveSpeedMultiplier) / Time.deltaTime;

				// we preserve the existing y part of the current velocity.
				v.y = m_Rigidbody.velocity.y;
				m_Rigidbody.velocity = v;
			}
		}

		//�n�ʔ���
		void CheckGroundStatus()
		{
			RaycastHit hitInfo;
#if UNITY_EDITOR
			// helper to visualise the ground check ray in the scene view
			Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * m_GroundCheckDistance));
#endif
			// 0.1f is a small offset to start the ray from inside the character
			// it is also good to note that the transform position in the sample assets is at the base of the character
			if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, m_GroundCheckDistance))
			{
				m_GroundNormal = hitInfo.normal;
				m_IsGrounded = true;
				m_Animator.applyRootMotion = true;
				//Debug.Log("�X�^�C���b�V�����n");
			}
			else
			{
				m_IsGrounded = false;
				m_GroundNormal = Vector3.up;
				m_Animator.applyRootMotion = false;
			}
		}
	}
}
