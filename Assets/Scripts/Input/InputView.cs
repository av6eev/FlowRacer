using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputView : MonoBehaviour
    {
        public event Action<float> OnTurnPerformed; 
        public event Action OnTurnCanceled; 
        
        public InputActionAsset PlayerInputAsset;

        public void Initialize()
        {
            PlayerInputAsset.Enable();

            PlayerInputAsset["HorizontalMovement"].performed += HandleTurnPerformed;
            PlayerInputAsset["HorizontalMovement"].canceled += HandleTurnCanceled;
        }

        public void Dispose()
        {
            PlayerInputAsset.Disable();
            
            PlayerInputAsset["HorizontalMovement"].performed -= HandleTurnPerformed;
            PlayerInputAsset["HorizontalMovement"].canceled -= HandleTurnCanceled;
        }

        private void HandleTurnCanceled(InputAction.CallbackContext ctx) => OnTurnCanceled?.Invoke();
        private void HandleTurnPerformed(InputAction.CallbackContext ctx) => OnTurnPerformed?.Invoke(ctx.ReadValue<Vector2>().x);
    }
}