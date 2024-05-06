using ECM.Controllers;
using UntilTheEnd;
using UnityEngine;

namespace ECM.Components
{
    /// <summary>
    /// MouseLook.
    /// 
    /// Component used to 'look around' with the mouse.
    /// This rotate the character along its y-axis (yaw) and a child camera along its local x-axis (pitch).
    /// 
    /// This must be attached to the game object with 'CharacterMovement' component.
    /// </summary>

    public class MouseLook : MonoBehaviour
    {
        #region EDITOR EXPOSED FIELDS
        [SerializeField] private bool _lockCursor = true;
        [SerializeField] private KeyCode _unlockCursorKey = KeyCode.Escape;
        [SerializeField] private float _lateralSensitivity = 2.0f;
        [SerializeField] private float _verticalSensitivity = 2.0f;
        [SerializeField] private bool _smooth;
        [SerializeField] public float _smoothTime = 5.0f;
        [SerializeField] private bool _clampPitch = true;
        [SerializeField] private float _minPitchAngle = -90.0f;
        [SerializeField] private float _maxPitchAngle = 90.0f;
        [SerializeField] private BaseFirstPersonController _baseFirstPersonController;
        #endregion

        #region FIELDS
        private bool _isCursorLocked = true;
        protected Quaternion characterTargetRotation;
        protected Quaternion cameraTargetRotation;
        #endregion

        #region PROPERTIES
        public bool lockCursor
        {
            get { return _lockCursor; }
            set { _lockCursor = value; }
        }

        public KeyCode unlockCursorKey
        {
            get { return _unlockCursorKey; }
            set { _unlockCursorKey = value; }
        }

        public float lateralSensitivity
        {
            get { return _lateralSensitivity; }
            set { _lateralSensitivity = Mathf.Max(0.0f, value); }
        }

        public float verticalSensitivity
        {
            get { return _verticalSensitivity; }
            set { _verticalSensitivity = Mathf.Max(0.0f, value); }
        }

        public bool smooth
        {
            get { return _smooth; }
            set { _smooth = value; }
        }

        public float smoothTime
        {
            get { return _smoothTime; }
            set { _smoothTime = Mathf.Max(0.0f, value); }
        }

        public bool clampPitch
        {
            get { return _clampPitch; }
            set { _clampPitch = value; }
        }

        public float minPitchAngle
        {
            get { return _minPitchAngle; }
            set { _minPitchAngle = Mathf.Clamp(value, -180.0f, 180.0f); }
        }

        public float maxPitchAngle
        {
            get { return _maxPitchAngle; }
            set { _maxPitchAngle = Mathf.Clamp(value, -180.0f, 180.0f); }
        }
        #endregion

        void Start()
        {
            // 변수에 할당
            _baseFirstPersonController = GetComponent<BaseFirstPersonController>();
        }

        #region METHODS

        public virtual void Init(Transform characterTransform, Transform cameraTransform)
        {
            //characterTargetRotation = characterTransform.localRotation;
            //cameraTargetRotation = cameraTransform.localRotation;
        }

        /// <summary>
        /// Perform 'Look' rotation.
        /// This rotate the character along its y-axis (yaw) and a child camera along its local x-axis (pitch).
        /// </summary>
        /// <param name="movement">The character movement component.</param>
        /// <param name="cameraTransform">The camera transform.</param>

        public virtual void LookRotation(CharacterMovement movement, Transform cameraTransform)
        {
            var yaw = Input.GetAxis("Mouse X") * lateralSensitivity;
            var pitch = Input.GetAxis("Mouse Y") * verticalSensitivity;

            var yawRotation = Quaternion.Euler(0.0f, yaw, 0.0f);
            var pitchRotation = Quaternion.Euler(-pitch, 0.0f, 0.0f);

            characterTargetRotation *= yawRotation;
            //cameraTargetRotation *= pitchRotation;

            //if (clampPitch) cameraTargetRotation = ClampPitch(cameraTargetRotation);

            if (smooth)
            {
                // On a rotating platform, append platform rotation to target rotation

                if (movement.platformUpdatesRotation && movement.isOnPlatform && movement.platformAngularVelocity != Vector3.zero)
                {
                    characterTargetRotation *=
                        Quaternion.Euler(movement.platformAngularVelocity * Mathf.Rad2Deg * Time.deltaTime);
                }

                movement.rotation = Quaternion.Slerp(movement.rotation, characterTargetRotation,
                    smoothTime * Time.deltaTime);

                //cameraTransform.localRotation = Quaternion.Slerp(cameraTransform.localRotation, cameraTargetRotation, smoothTime * Time.deltaTime);
            }
            else
            {
                //movement.rotation *= yawRotation;
                //var horizontalInput = Input.GetAxis("Horizontal");// * lateralSensitivity;
                //var rotationAmount = Quaternion.Euler(0.0f, horizontalInput, 0.0f);
                //movement.rotation *= rotationAmount;

                float rotationSpeed = 250f;
                float horizontal = Input.GetAxis("Horizontal");
                //Vector3 rotation = new Vector3(0f, horizontal * rotationSpeed * Time.deltaTime, 0f);
                //transform.Rotate(rotation);
                Quaternion rotationAmount = Quaternion.Euler(0f, horizontal * rotationSpeed * Time.deltaTime, 0f);
                movement.rotation *= rotationAmount;



                cameraTransform.localRotation *= pitchRotation;
                if (clampPitch)
                    cameraTransform.localRotation = ClampPitch(cameraTransform.localRotation);
            }

            UpdateCursorLock(true);
        }


        #region 커서 락/언락
        //  true 커서 Lock일 때 인게임
        // false 커서 UnLock일 때 ESC 메뉴판 활성화
        private bool _onMenuESC = false;
        public virtual void UpdateCursorLock(bool _lockCursor)
        {
            if (_lockCursor)
            {
                // ESC 키
                if (Input.GetKeyDown(unlockCursorKey))
                {
                    _onMenuESC = !_onMenuESC;

                    if (!_onMenuESC) // 인게임이라면 ESC메뉴를 켜야겠지?
                    {
                        _isCursorLocked = true;
                    }
                    else // ESC 한번 더 눌렀을 때 = ESC메뉴를 닫아야겠지? 
                    {
                        _isCursorLocked = false;
                    }
                }
            }
            else // ESC 메뉴에서 Back 버튼 눌렀을 때 메뉴판이 비활성화 되어야함 !!
            {
                _isCursorLocked = false;
            }


            // 이거 디폴트로 계속 진행중임
            if (_isCursorLocked)
            {
                UIManager.instance.TogglePanelESC(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else if (!_isCursorLocked)
            {
                UIManager.instance.TogglePanelESC(true);
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
        }
        #endregion





        protected Quaternion ClampPitch(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            var pitch = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

            pitch = Mathf.Clamp(pitch, minPitchAngle, maxPitchAngle);

            q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * pitch);

            return q;
        }

        #endregion

        #region MONOBEHAVIOUR

        /// <summary>
        /// Validate editor exposed fields.
        /// 
        /// NOTE: If you override this, it is important to call the parent class' version of method
        /// eg: base.OnValidate, in the derived class method implementation, in order to fully validate the class.  
        /// </summary>

        public virtual void OnValidate()
        {
            lateralSensitivity = _lateralSensitivity;
            verticalSensitivity = _verticalSensitivity;

            smoothTime = _smoothTime;

            minPitchAngle = _minPitchAngle;
            maxPitchAngle = _maxPitchAngle;
        }

        #endregion
    }
}
