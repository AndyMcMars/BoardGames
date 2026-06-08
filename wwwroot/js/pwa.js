let deferredPrompt = null;

window.addEventListener('beforeinstallprompt', (e) => {
    console.log('PWA install available');

    // Prevent Chrome from showing its own prompt immediately
    e.preventDefault();

    deferredPrompt = e;
});

export async function installPWA() {
    if (!deferredPrompt) {
        console.log('Install prompt not available');
        return false;
    }

    deferredPrompt.prompt();

    const result = await deferredPrompt.userChoice;

    console.log('Install result:', result.outcome);

    deferredPrompt = null;

    return result.outcome === 'accepted';
}

export function canInstallPWA() {
    return deferredPrompt !== null;
}