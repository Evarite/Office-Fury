using Office.Input;
using System;

namespace Office.Managers
{
    public class InputManager : IDisposable
    {
        public InputActions InputSystem { get; private set; }

        public InputManager()
        {
            InputSystem = new();
            InputSystem.Enable();
        }

        public void Dispose() => InputSystem.Dispose();
    }
}