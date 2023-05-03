using static System.Console;

namespace PacktLibrary
{
    public interface IPlayable
    {
        void Play();
        void Pause();

        // Default interface implementation. 
        void Stop()
        {
            WriteLine("Default implementation of stop.");
        }
    }
}