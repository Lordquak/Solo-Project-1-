using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FpsMovement : MonoBehaviour {
	
	//walking
	[Space(20)]
	public bool enableWalk = true;
	private Rigidbody rb;
	public float walkSpeed = 5f;
	Vector3 playerInput;
	Vector3 velocity;
	Vector3 velocityChange;
	
	//jumping
	[Space(20)]
	public bool enableJump = true;
	public float jumpPower = 5f;
	public KeyCode jumpKey = KeyCode.Space;
	private bool isJumping;
	private bool isGrounded;
	
	//sprinting
	[Space(20)]
	public bool enableSprint = true;
	public KeyCode sprintKey = KeyCode.LeftShift;
	public float sprintSpeed = 7f; 
	private float originalWalkSpeed;
	private bool isSprinting = false;
	
	//Crouching
	[Space(20)]
	public bool enableCrouch = true;
	public bool holdToCrouch = true;
	public KeyCode crouchKey = KeyCode.LeftControl;
	public float crouchHeight = .75f;
	public float speedReduction = .5f;
	public CapsuleCollider capsuleColl;
	public Transform cameraPivot;
	private bool isCrouched = false;
	private Vector3 originalCapsuleCenter;
	private Vector3 jointOriginalPos;
	private float capsuleHeight;
	
	[Space(20)]
	public bool enableHeadBob = true;
	public HeadbobSystem headBober;

	private void Start() {
    	
		rb = GetComponent<Rigidbody>();
		capsuleColl = GetComponent<CapsuleCollider>();
		originalCapsuleCenter = capsuleColl.center;
		capsuleHeight = capsuleColl.height;
		originalWalkSpeed = walkSpeed;

		
	}

	private void Update() {
		
		
		if(enableJump && Input.GetKeyDown(jumpKey) && isGrounded) {
        	
			Jump();
		}
		
		if (enableSprint) {
        	
			if(Input.GetKeyDown(sprintKey)) {
            	
				isSprinting = true;
				Sprint();
                
			} else if(Input.GetKeyUp(sprintKey)) {
            	
				isSprinting = false;
				Sprint();
			}
		}
		
		if (enableCrouch) {
        	
			if(Input.GetKeyDown(crouchKey) && !holdToCrouch) {
            	
				Crouch();
			}
            
			if(Input.GetKeyDown(crouchKey) && holdToCrouch) {
            	
				isCrouched = true;
				Crouch();
                
			} else if(Input.GetKeyUp(crouchKey) && holdToCrouch) {
            	
				isCrouched = false;
				Crouch();
			}
		}

		
		CheckGround();
	    
	}

	void FixedUpdate() {

		if(enableWalk)
		
		playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		    
		playerInput = transform.TransformDirection(playerInput) * walkSpeed;

		velocity = rb.velocity;
		velocityChange = (playerInput - velocity);
		    
		velocityChange.y = 0;

		rb.AddForce(velocityChange, ForceMode.VelocityChange);
	}
	
	private void CheckGround() {
    	
		Vector3 origin = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y * .5f), transform.position.z);
		Vector3 direction = transform.TransformDirection(Vector3.down);
		float distance = .75f;

		if (Physics.Raycast(origin, direction, out RaycastHit hit, distance)) {
        	
			Debug.DrawRay(origin, direction * distance, Color.red);
			isGrounded = true;
			isJumping = false;
	        
		} else {
        	
			isGrounded = false;
			isJumping = true;
		}
	}

	private void Jump() {
    	
		if (isGrounded) {
        	
			rb.AddForce(0f, jumpPower, 0f, ForceMode.Impulse);
			isGrounded = false;
		}
	}
	
	private void Sprint() {
		
		if(!isSprinting) {
			    
			//Debug.Log("sprinting");
			DOTween.To(()=> walkSpeed,
				x=> walkSpeed = x, originalWalkSpeed ,
				2);
				
			isSprinting = true;
	
		}  else {
			
			//Debug.Log("!sprinting");
			DOTween.To(()=> walkSpeed,
				x=> walkSpeed = x, sprintSpeed ,
				2);
				
			isSprinting = false;
			
		
		}
	}
	
	private void Crouch() {
    	
		if(!isCrouched) {
        	
			DOTween.To(()=> capsuleColl.center,
				x=> capsuleColl.center = x,
				originalCapsuleCenter, 2);
		           		
			DOTween.To(()=> capsuleColl.height,
				x=> capsuleColl.height = x, 2 ,
				2);
		        
			DOTween.To(()=> cameraPivot.transform.localPosition,
				x=> cameraPivot.transform.localPosition = x,
				new Vector3(0, 0.5f,0), 2);
		        
			DOTween.To(()=> walkSpeed,
				x=> walkSpeed = x, originalWalkSpeed ,
				2);
		        
			isCrouched = true;
	        
		} else {
        	
			DOTween.To(()=> capsuleColl.center,
				x=> capsuleColl.center = x,
				new Vector3(0, -0.5f, 0), 2);
	        	
			DOTween.To(()=> capsuleColl.height,
				x=> capsuleColl.height = x, 1 ,
				2);
		        
			DOTween.To(()=> cameraPivot.transform.localPosition,
				x=> cameraPivot.transform.localPosition = x,
				new Vector3(0,0.0f,0), 2);
		        
			DOTween.To(()=> walkSpeed,
				x=> walkSpeed = x, speedReduction ,
				2);
		        
			isCrouched = false;
		}
	}
}
