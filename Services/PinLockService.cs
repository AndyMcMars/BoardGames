namespace BoardGames.Services
{
    public class PinLockService
    {
        public bool IsUnlocked { get; private set; }

        private string CorrectPin = Environment.GetEnvironmentVariable("PIN_LOCK") ?? "1234";

        public bool TryUnlock(string pin)
        {
            if (pin == CorrectPin)
            {
                IsUnlocked = true;
                return true;
            }

            return false;
        }

        public void Lock() => IsUnlocked = false;
    }
}
