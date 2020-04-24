using UnityEngine;

namespace Monster.ThirdPersonMonster 
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    public class ThirdPersonMonster : MonoBehaviour
    {
		[SerializeField] float movingTurnSpeed = 360;
		[SerializeField] float stationaryTurnSpeed = 180;
		[SerializeField] float moveSpeedMultiplier = 1f;
		[SerializeField] float animSpeedMultiplier = 1f;
		[SerializeField] float groundCheckDistance = 0.1f;

		Rigidbody rigidBody;
		Animator animator;
		bool isGrounded;
		float turnAmount;
		float forwardAmount;
		Vector3 groundNormal;


		// Start is called before the first frame update
		void Start()
        {
			animator = GetComponent<Animator>();
			rigidBody = GetComponent<Rigidbody>();

			rigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		}

		public void Move(Vector3 move)
		{

			// convert the world relative moveInput vector into a local-relative
			// turn amount and forward amount required to head in the desired
			// direction.
			if (move.magnitude > 1f) move.Normalize();
			move = transform.InverseTransformDirection(move);
			CheckGroundStatus();
			move = Vector3.ProjectOnPlane(move, groundNormal);
			turnAmount = Mathf.Atan2(move.x, move.z);
			forwardAmount = move.z;

			ApplyExtraTurnRotation();

			// send input and other state parameters to the animator
			UpdateAnimator(move);
		}

		void UpdateAnimator(Vector3 move)
		{
			animator.SetFloat("Forward", forwardAmount, 0.1f, Time.deltaTime);
			animator.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);
			animator.SetBool("OnGround", isGrounded);

			//float runCycle =
			//	Mathf.Repeat(
			//		animator.GetCurrentAnimatorStateInfo(0).normalizedTime + 0.2f, 1);
			// the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
			// which affects the movement speed because of the root motion.
			if (isGrounded && move.magnitude > 0)
			{
				animator.speed = animSpeedMultiplier;
			}
			else
			{
				// don't use that while airborne
				animator.speed = 1;
			}
		}

		void ApplyExtraTurnRotation()
		{
			// help the character turn faster (this is in addition to root rotation in the animation)
			float turnSpeed = Mathf.Lerp(stationaryTurnSpeed, movingTurnSpeed, forwardAmount);
			transform.Rotate(0, turnAmount * turnSpeed * Time.deltaTime, 0);
		}


		public void OnAnimatorMove()
		{
			// we implement this function to override the default root motion.
			// this allows us to modify the positional speed before it's applied.
			if (isGrounded && Time.deltaTime > 0)
			{
				Vector3 v = (animator.deltaPosition * moveSpeedMultiplier) / Time.deltaTime;

				// we preserve the existing y part of the current velocity.
				v.y = rigidBody.velocity.y;
				rigidBody.velocity = v;
			}
		}


		void CheckGroundStatus()
		{
			RaycastHit hitInfo;
#if UNITY_EDITOR
			// helper to visualise the ground check ray in the scene view
			Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * groundCheckDistance));
#endif
			// 0.1f is a small offset to start the ray from inside the character
			// it is also good to note that the transform position in the sample assets is at the base of the character
			if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, groundCheckDistance))
			{
				groundNormal = hitInfo.normal;
				isGrounded = true;
				animator.applyRootMotion = true;
			}
			else
			{
				isGrounded = false;
				groundNormal = Vector3.up;
				animator.applyRootMotion = false;
			}
		}
	}

}
