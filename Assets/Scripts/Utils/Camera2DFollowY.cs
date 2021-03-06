using System;
using UnityEngine;

    public class Camera2DFollowY : MonoBehaviour
    {
        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;
        public bool isAndroidBuild;
        private float limitYup;
        private float limitYdown;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;
        static bool isActive = true;

        // Use this for initialization
        private void Start()
        {
            m_LastTargetPosition = target.position;
            m_OffsetZ = (transform.position - target.position).z;
            transform.parent = null;
        }


        // Update is called once per frame
        private void Update()
        {
            if (isActive)
            {   
            // only update lookahead pos if accelerating or changed direction
            float yMoveDelta = (target.position - m_LastTargetPosition).y;

            bool updateLookAheadTarget = Mathf.Abs(yMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor*Vector3.up*Mathf.Sign(yMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward*m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

            if (isAndroidBuild)
            {
                limitYup = -5.21f;
                limitYdown = -326.3f;
            }
            else
            {
                limitYup = 1.3f;
                limitYdown = -332.46f;
            }

            if(newPos.y <= limitYup && newPos.y >= limitYdown)
            {
                transform.position = new Vector3(transform.position.x, newPos.y, transform.position.z); // ONLY MOVES IN Y
            }
            m_LastTargetPosition = target.position;
            }
        }

        static public void disable()
        {
            isActive = false;
        }
    }
