namespace PlayerController
{
    public class PlayerStateFactory
    {
        private PlayerStateMachine _playerStateMachine;
        
        public PlayerStateFactory(PlayerStateMachine playerStateMachine)
        {
            _playerStateMachine = playerStateMachine;
        }

        public PlayerBaseState Healthy()
        {
            return new PlayerHealthyState(_playerStateMachine, this);
        }
        
        public PlayerBaseState Combat()
        {
            return new PlayerCombatState(_playerStateMachine, this);
        }
        
        public PlayerBaseState Die()
        {
            return new PlayerDieState(_playerStateMachine, this);
        }

        public PlayerBaseState Idle()
        {
            return new PlayerIdleState(_playerStateMachine, this);
        }

        public PlayerBaseState Walk()
        {
            return new PlayerWalkState(_playerStateMachine, this);
        }

        public PlayerBaseState Run()
        {
            return new PlayerRunState(_playerStateMachine, this);
        }

        public PlayerBaseState Jump()
        {
            return new PlayerJumpState(_playerStateMachine, this);
        }
        
        public PlayerBaseState Fall()
        {
            return new PlayerFallState(_playerStateMachine, this);
        }

        public PlayerBaseState Roll()
        {
            return new PlayerRollState(_playerStateMachine, this);
        }
        
        public PlayerBaseState Crouch()
        {
            return new PlayerCrouchState(_playerStateMachine, this);
        }
    }
}