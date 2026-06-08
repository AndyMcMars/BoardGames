export function registerServiceWorker() {
    if (!('serviceWorker' in navigator)) return;

    navigator.serviceWorker.register('/service-worker.js')
        .then(r => console.log('SW registered', r))
        .catch(err => console.error('SW failed', err));
}

let deferredPrompt = null;

window.addEventListener('beforeinstallprompt', (e) => {
    e.preventDefault();
    deferredPrompt = e;
});

export async function installPWA() {
    if (!deferredPrompt) {
        console.log('No install prompt available');
        return false;
    }

    deferredPrompt.prompt();

    const result = await deferredPrompt.userChoice;

    deferredPrompt = null;

    return result.outcome === 'accepted';
}