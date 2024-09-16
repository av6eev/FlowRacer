using Input;
using UnityEngine;
using UnityEngine.UIElements;
using Updater;

namespace Car.Movement
{
    public class CarMovementUpdater : IUpdater
    {
        private readonly IInputModel _inputModel;
        private readonly CarModel _model;
        private readonly CarView _view;
        private float _currentYRotation;

        public CarMovementUpdater(IInputModel inputModel, CarModel model, CarView view)
        {
            _inputModel = inputModel;
            _model = model;
            _view = view;
        }
        
        public void Update(float deltaTime)
        {
            _view.Position = new Vector3(_view.Position.x, CarModel.MinVerticalCoordinate, _view.Position.z);

            if (!_model.IsReady || !_inputModel.IsEnable.Value) return;
            
            Move(deltaTime);
            Turn(deltaTime);
            Rotate(deltaTime);
        }

        private void Move(float deltaTime)
        {
            _view.Move(_model.Specification.MoveSpeed);
            _model.CurrentPosition.Value = _view.Position;
        }

        private void Turn(float deltaTime)
        {
            var carRb = _view.Rigidbody;

            if (Mathf.Abs(_inputModel.TurnInput) > 0)
            {
                var direction = new Vector3(_inputModel.TurnInput * _model.Specification.TurnSpeed, _model.CurrentPosition.Value.y, carRb.velocity.z);
                _view.Turn(direction);
            }
            else
            {
                var direction = Vector3.Lerp(carRb.velocity, new Vector3(0, 0, carRb.velocity.z), deltaTime * _model.Specification.CenteringAfterTurnMultiplier);
                _view.Turn(direction);
            }
        }

        private void Rotate(float deltaTime)
        {
            if (Mathf.Abs(_inputModel.TurnInput) > 0)
            {
                _currentYRotation += _inputModel.TurnInput * _model.Specification.RotateSpeed;
                _currentYRotation = Mathf.Clamp(_currentYRotation, -_model.Specification.MaxRotateAngle, _model.Specification.MaxRotateAngle);    
            }
            else
            {
                _currentYRotation = Mathf.Lerp(_currentYRotation, 0, _model.Specification.CenteringAfterTurnMultiplier * deltaTime);
            }

            var direction = Quaternion.Slerp(_view.Rotation, Quaternion.Euler(0, _currentYRotation, 0), deltaTime * _model.Specification.TurnSlerpMultiplier);
            _view.Rotate(direction);
        }
    }
}