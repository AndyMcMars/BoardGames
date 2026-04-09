using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace BoardGames.Services
{
    public class PinLockService
    {
        private const string StorageKey = "pin-unlocked";

        private readonly ProtectedLocalStorage _storage;
        public bool IsUnlocked { get; private set; }

        private string CorrectPin = Environment.GetEnvironmentVariable("PIN_LOCK") ?? "1234";
        public PinLockService(ProtectedLocalStorage storage)
        {
            _storage = storage;
        }

        public async Task InitializeAsync()
        {
            var result = await _storage.GetAsync<bool>(StorageKey);
            IsUnlocked = result.Success && result.Value;
        }

        public async Task<bool> TryUnlockAsync(string pin)
        {
            if (pin == CorrectPin)
            {
                IsUnlocked = true;
                await _storage.SetAsync(StorageKey, true);
                return true;
            }

            return false;
        }

        public async Task LockAsync()
        {
            IsUnlocked = false;
            await _storage.DeleteAsync(StorageKey);
        }

    }
}
