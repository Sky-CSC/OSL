(function () {
    const MAX_RETRIES = 10;
    const RETRY_INTERVAL_MS = 3000;
    const SLOW_ATTEMPT_THRESHOLD = 5; // show "reload" button after N attempts

    let overlay = null;
    let card = null;
    let titleEl = null;
    let subtitleEl = null;
    let isReconnecting = false;

    function getApplicationName() {
        const meta = document.querySelector('meta[name="osl-app-name"]');
        return meta?.content?.trim() || "Application";
    }

    function buildOverlay() {
        const appName = getApplicationName();

        overlay = document.createElement("div");
        overlay.id = "osl-reconnect-overlay";
        overlay.innerHTML = `
        <div class="osl-reconnect-card" id="osl-reconnect-card">
            <p class="osl-reconnect-app-name">${appName}</p>
            <img src="/favicon.ico" alt="App logo" class="osl-reconnect-logo" />
            <p class="osl-reconnect-title" id="osl-reconnect-title">Connection lost</p>
            <p class="osl-reconnect-subtitle" id="osl-reconnect-subtitle">Attempting to reconnect...</p>
            <button class="osl-reload-button" id="osl-reload-button">Reload page</button>
        </div>`;
        document.body.appendChild(overlay);

        card = overlay.querySelector("#osl-reconnect-card");
        titleEl = overlay.querySelector("#osl-reconnect-title");
        subtitleEl = overlay.querySelector("#osl-reconnect-subtitle");
        overlay.querySelector("#osl-reload-button").addEventListener("click", () => location.reload());
    }

    function updateAttemptUi(attempt, maxRetries) {
        card.classList.remove("osl-failed");
        titleEl.textContent = "Connection lost";
        subtitleEl.textContent = `Reconnecting (attempt ${attempt}/${maxRetries})...`;
        card.classList.toggle("osl-slow", attempt >= SLOW_ATTEMPT_THRESHOLD);
        overlay.classList.add("osl-visible");
    }

    function showFailed() {
        card.classList.add("osl-failed", "osl-slow");
        titleEl.textContent = "Reconnection failed";
        subtitleEl.textContent = "Unable to reestablish a connection to the server.";
        overlay.classList.add("osl-visible");
    }

    function hideOverlay() {
        card.classList.remove("osl-slow", "osl-failed");
        overlay.classList.remove("osl-visible");
    }

    function delay(ms) {
        return new Promise((resolve) => setTimeout(resolve, ms));
    }

    // ---- Theme sync -------------------------------------------------
    function applyStoredTheme() {
        const theme = localStorage.getItem("osl-theme") || "light";
        document.documentElement.dataset.theme = theme;
    }

    globalThis.OSLReconnect = {
        setTheme: function (theme) {
            localStorage.setItem("osl-theme", theme);
            document.documentElement.dataset.theme = theme;
        }
    };

    applyStoredTheme();
    buildOverlay();

    // ---- Blazor circuit reconnection handler -------------------------
    // NOTE: onConnectionDown fires only once per disconnection.
    // We own the entire retry loop, calling Blazor.reconnect() ourselves.
    class CustomReconnectionHandler {
        onConnectionDown(options, _error) {
            if (isReconnecting) return; // avoid overlapping loops
            isReconnecting = true;
if (!serverWatcherStarted) {
    serverWatcherStarted = true;
    watchServer();
}
            this._runRetryLoop(options.maxRetries ?? MAX_RETRIES, options.retryIntervalMilliseconds ?? RETRY_INTERVAL_MS);
        }

        onConnectionUp() {
            isReconnecting = false;
            hideOverlay();
        }

        async _runRetryLoop(maxRetries, intervalMs) {
            for (let attempt = 1; attempt <= maxRetries; attempt++) {
                if (!isReconnecting) return; // reconnected in the meantime

                updateAttemptUi(attempt, maxRetries);
                await delay(intervalMs);
                if (!isReconnecting) return;

                try {
                    const succeeded = await globalThis.Blazor.reconnect();
                    if (succeeded) {
                        // onConnectionUp will be triggered by the framework
                        return;
                    }
                } catch {
                    // Reconnect attempt threw (e.g. server unreachable) — keep retrying
                }
            }

            if (isReconnecting) {
                showFailed();
            }
        }
    }

let serverWatcherStarted = false;

async function watchServer() {

    while (isReconnecting) {

        try {

            const r = await fetch("/favicon.ico", {
                method: "HEAD",
                cache: "no-store"
            });

            if (r.ok) {
                location.reload();
                return;
            }

        } catch { }

        await delay(1000);
    }
}

    Blazor.start({
        circuit: {
            reconnectionOptions: {
                maxRetries: MAX_RETRIES,
                retryIntervalMilliseconds: RETRY_INTERVAL_MS
            },
            reconnectionHandler: new CustomReconnectionHandler()
        }
    });
})();

// (function () {
//     const MAX_RETRIES = 10;
//     const RETRY_INTERVAL_MS = 3000;
//     const RECONNECT_TIMEOUT_MS = 5000; // max time to wait for a single reconnect() call
//     const SLOW_ATTEMPT_THRESHOLD = 5; // show "reload" button after N attempts
//     const AUTO_RELOAD_DELAY_MS = 2000; // delay before auto-reloading after final failure

//     let overlay = null;
//     let card = null;
//     let titleEl = null;
//     let subtitleEl = null;
//     let isReconnecting = false;

//     function getApplicationName() {
//         const meta = document.querySelector('meta[name="osl-app-name"]');
//         return meta?.content?.trim() || "Application";
//     }

//     function buildOverlay() {
//         const appName = getApplicationName();

//         overlay = document.createElement("div");
//         overlay.id = "osl-reconnect-overlay";
//         overlay.innerHTML = `
//         <div class="osl-reconnect-card" id="osl-reconnect-card">
//             <p class="osl-reconnect-app-name">${appName}</p>
//             <img src="/favicon.ico" alt="App logo" class="osl-reconnect-logo" />
//             <p class="osl-reconnect-title" id="osl-reconnect-title">Connection lost</p>
//             <p class="osl-reconnect-subtitle" id="osl-reconnect-subtitle">Attempting to reconnect...</p>
//             <button class="osl-reload-button" id="osl-reload-button">Reload page</button>
//         </div>`;
//         document.body.appendChild(overlay);

//         card = overlay.querySelector("#osl-reconnect-card");
//         titleEl = overlay.querySelector("#osl-reconnect-title");
//         subtitleEl = overlay.querySelector("#osl-reconnect-subtitle");
//         overlay.querySelector("#osl-reload-button").addEventListener("click", () => location.reload());
//     }

//     function updateAttemptUi(attempt, maxRetries) {
//         card.classList.remove("osl-failed");
//         titleEl.textContent = "Connection lost";
//         subtitleEl.textContent = `Reconnecting (attempt ${attempt}/${maxRetries})...`;
//         card.classList.toggle("osl-slow", attempt >= SLOW_ATTEMPT_THRESHOLD);
//         overlay.classList.add("osl-visible");
//     }

//     function showFailed() {
//         card.classList.add("osl-failed", "osl-slow");
//         titleEl.textContent = "Reconnection failed";
//         subtitleEl.textContent = "Unable to reestablish a connection. Reloading...";
//         overlay.classList.add("osl-visible");
//     }

//     function hideOverlay() {
//         card.classList.remove("osl-slow", "osl-failed");
//         overlay.classList.remove("osl-visible");
//     }

//     function delay(ms) {
//         return new Promise((resolve) => setTimeout(resolve, ms));
//     }

//     // Wraps Blazor.reconnect() so a hung network call can never stall the retry loop.
//     // Resolves to false if the timeout is hit before reconnect() settles.
//     function reconnectWithTimeout(timeoutMs) {
//         return new Promise((resolve) => {
//             let settled = false;

//             const timer = setTimeout(() => {
//                 if (!settled) {
//                     settled = true;
//                     resolve(false);
//                 }
//             }, timeoutMs);

//             globalThis.Blazor.reconnect()
//                 .then((result) => {
//                     if (!settled) {
//                         settled = true;
//                         clearTimeout(timer);
//                         resolve(Boolean(result));
//                     }
//                 })
//                 .catch(() => {
//                     if (!settled) {
//                         settled = true;
//                         clearTimeout(timer);
//                         resolve(false);
//                     }
//                 });
//         });
//     }

//     // ---- Theme sync -------------------------------------------------
//     function applyStoredTheme() {
//         const theme = localStorage.getItem("osl-theme") || "light";
//         document.documentElement.dataset.theme = theme;
//     }

//     globalThis.OSLReconnect = {
//         setTheme: function (theme) {
//             localStorage.setItem("osl-theme", theme);
//             document.documentElement.dataset.theme = theme;
//         }
//     };

//     applyStoredTheme();
//     buildOverlay();

//     // ---- Blazor circuit reconnection handler -------------------------
//     // NOTE: onConnectionDown fires only once per disconnection.
//     // We own the entire retry loop, calling Blazor.reconnect() ourselves.
//     class CustomReconnectionHandler {
//         onConnectionDown(options, _error) {
//             if (isReconnecting) return; // avoid overlapping loops
//             isReconnecting = true;
//             if (!serverWatcherStarted) {
//                 serverWatcherStarted = true;
//                 watchServer();
//             }
//             this._runRetryLoop(options.maxRetries ?? MAX_RETRIES, options.retryIntervalMilliseconds ?? RETRY_INTERVAL_MS);
//         }

//         onConnectionUp() {
//             isReconnecting = false;
//             hideOverlay();
//         }

//         async _runRetryLoop(maxRetries, intervalMs) {
//             for (let attempt = 1; attempt <= maxRetries; attempt++) {
//                 if (!isReconnecting) return; // reconnected in the meantime

//                 updateAttemptUi(attempt, maxRetries);

//                 const succeeded = await reconnectWithTimeout(RECONNECT_TIMEOUT_MS);
//                 if (succeeded) {
//                     // onConnectionUp will be triggered by the framework
//                     return;
//                 }
//                 if (!isReconnecting) return;

//                 await delay(intervalMs);
//             }

//             if (isReconnecting) {
//                 showFailed();
//                 // The original circuit no longer exists on the server after
//                 // this many failed attempts (typical after an app restart).
//                 // A full reload is required to establish a brand new circuit.
//                 await delay(AUTO_RELOAD_DELAY_MS);
//                 if (isReconnecting) {
//                     location.reload();
//                 }
//             }
//         }
//     }

//     let serverWatcherStarted = false;

//     async function watchServer() {

//         while (isReconnecting) {

//             try {

//                 const r = await fetch("/favicon.ico", {
//                     method: "HEAD",
//                     cache: "no-store"
//                 });

//                 if (r.ok) {
//                     location.reload();
//                     return;
//                 }

//             } catch { }

//             await delay(1000);
//         }
//     }

//     Blazor.start({
//         circuit: {
//             reconnectionOptions: {
//                 maxRetries: MAX_RETRIES,
//                 retryIntervalMilliseconds: RETRY_INTERVAL_MS
//             },
//             reconnectionHandler: new CustomReconnectionHandler()
//         }
//     });
// })();
