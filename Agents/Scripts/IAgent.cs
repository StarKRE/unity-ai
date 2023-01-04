using System;

namespace AI.Agents
{
    //Anti-pattern: накопить и запустить
    public interface IAgent
    {
        event Action OnStarted;

        event Action OnStopped;

        bool IsPlaying { get; }
        
        void Play();

        void Stop();
    }
}