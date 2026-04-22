using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Cryptography;

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
            try
            {
                var result = await _storage.GetAsync<bool>(StorageKey);
                IsUnlocked = result.Success && result.Value;
            }
            catch (CryptographicException)
            {
                // Old/invalid data → clear it
                await _storage.DeleteAsync(StorageKey);
                IsUnlocked = false;
            }
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
