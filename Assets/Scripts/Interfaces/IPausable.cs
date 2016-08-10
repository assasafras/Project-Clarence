using Assets.Scripts.Events;

namespace Assets.Scripts.Interfaces
{
    public interface IPausable
    {
        void PausedHandler(PausedEventArgs e);
    }
}