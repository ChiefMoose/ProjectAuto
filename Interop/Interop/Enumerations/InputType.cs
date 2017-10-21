
namespace Interop.Enumerations
{
    /// <summary>
    /// Structure types passed into the <see cref="User32.SendInput(uint, INPUT[], int)"/> <see cref="INPUT"/> array.
    /// </summary>
    public enum InputType
    {
        MOUSE = 0,
        KEYBOARD = 1,
        HARDWARE = 2,
    }
}
