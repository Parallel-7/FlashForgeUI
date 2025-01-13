// Global Variables
let currentListType = null;
let selectedFile = null;
let statusInterval = null;
let isSendingCommand = false;
let nonProFlag = false;
let connected = false;
let connectionErrors = 0;

let printerState = '';

/*const PrinterState = Object.freeze({
    READY: "ready",
    PRINTING: "printing",
    PAUSED: "paused",
    BUSY:   "busy"
});*/

function sanitizeNumberString(str) {
    // Remove all characters except digits, decimal points, and negative signs
    let sanitized = str.replace(/[^0-9.-]+/g, '');

    // Handle multiple negative signs by keeping only the first one
    sanitized = sanitized.replace(/(?!^)-/g, '');

    // Handle multiple decimal points by keeping only the first one
    const parts = sanitized.split('.');
    if (parts.length > 2) {
        sanitized = parts.shift() + '.' + parts.join('');
    }

    return sanitized;
}

function appendLog(message) {
    const logDiv = document.getElementById('log');
    if (logDiv) {
        const timestamp = new Date().toLocaleTimeString();
        const newLogEntry = document.createElement('p');
        newLogEntry.textContent = `[${timestamp}] ${message}`;
        logDiv.appendChild(newLogEntry);
        logDiv.scrollTop = logDiv.scrollHeight; // Scroll to bottom
    }
}

function hideElement(id) {
    const element = document.getElementById(id);
    if (element) {
        element.style.display = 'none';
    }
}

function showSpinner(message = null) {
    //console.log("Showing spinner");
    const spinnerOverlay = document.getElementById('spinnerOverlay');
    //const spinnerText = document.getElementById("spinnerTitle");
    if (spinnerOverlay) {
        resumeSpinner(); // make sure it's spinning.. lol
        spinnerOverlay.classList.remove('hidden');
        if (message) setSpinnerText(message);
    }
}

function pauseSpinner() {
    const spinnerOverlay = document.getElementById('spinnerOverlay');
    spinnerOverlay.style.animationPlayState = 'paused';
}

function resumeSpinner() {
    const spinnerOverlay = document.getElementById('spinnerOverlay');
    spinnerOverlay.style.animationPlayState = 'running';
}

function setSpinnerText(message) {
    if (message) {
        const spinnerText = document.getElementById("spinnerTitle");
        if (spinnerText) {
            spinnerText.textContent = message;
        }
    }
}

function hideSpinner() {
    //console.log("Hiding spinner");
    const spinnerOverlay = document.getElementById('spinnerOverlay');
    if (spinnerOverlay) {
        spinnerOverlay.classList.add('hidden');
        const spinnerText = document.getElementById("spinnerTitle");
        if (spinnerText) spinnerText.textContent = ''; // clear old message (if it exists)
    }
}

function toggleWebcam() {
    const webcamImg = document.getElementById('webcam');
    if (webcamImg) {
        if (webcamImg.classList.contains('hidden')) {
            webcamImg.classList.remove('hidden');
            appendLog('Webcam enabled.');
        } else {
            webcamImg.classList.add('hidden');
            appendLog('Webcam disabled.');
        }
    }
}

async function promptForValue(command, message, paramName) {
    const value = prompt(message);
    if (value !== null && value.trim() !== '') {
        const params = '?' + paramName + '=' + encodeURIComponent(value.trim());
        await sendCommand(command, params);
    } else {
        appendLog('Command: ' + command + ' cancelled');
    }
}


function pauseStatusUpdates() {
    if (statusInterval) {
        clearInterval(statusInterval);
        statusInterval = null;
        //appendLog('Status updates paused.');
    }
}

function resumeStatusUpdates() {
    if (!statusInterval) {
        statusInterval = setInterval(fetchStatus, 1000);
        //appendLog('Status updates resumed.');
    }
}

async function fetchStatus() {
    if (isSendingCommand) {
        return;
    }

    try {
        const response = await fetch('/status');
        if (!response.ok) { throw new Error(`Server responded with status ${response.status}`);}
        
        const data = await response.json();
        if (!connected) {
            connected = true;
            hideSpinner();
        }

        printerState = data.printerStatus; //  update state

        if (!data.isPro && !nonProFlag) { // Disable pro exclusive features
            hideElement('webcam');
            hideElement('toggleWebcam');
            hideElement('setChamberFanSpeed');
            hideElement('setLedOn');
            hideElement('setLedOff');
            hideElement('setExternalFiltration');
            hideElement('setInternalFiltration');
            hideElement('setFiltrationOff');
            appendLog('Non-pro model in use, some features have been restricted');
            nonProFlag = true;
        }

        // Update Status Elements
        document.getElementById('currentJob').textContent = data.currentJob || 'Current Job';
        document.getElementById('eta').textContent = data.eta || '--';
        document.getElementById('progress').textContent = data.progress || '--';
        document.getElementById('extruderTemp').innerHTML = (data.extruderTemp || '--') + '&deg;C';
        document.getElementById('bedTemp').innerHTML = (data.bedTemp || '--') + '&deg;C';
        document.getElementById('printerStatus').textContent = data.printerStatus || '--';
        document.getElementById('filtrationStatus').textContent = data.filtrationStatus || '--';
        document.getElementById('filamentUsed').textContent = data.filamentUsed || '--';
        document.getElementById('totalRunTime').textContent = data.totalRunTime || '--';
        document.getElementById('layerInfo').textContent = data.layerInfo || '--';
        document.getElementById('weight').textContent = data.weight || '--';
        document.getElementById('length').textContent = data.length || '--';
        document.getElementById('coolingFanSpeed').textContent = data.coolingFanSpeed || '--';
        if (!nonProFlag) {
            document.getElementById('chamberFanSpeed').textContent = data.chamberFanSpeed || '--';
        }

        // Update Progress Bar
        //console.log('Raw data.progress: ' + data.progress)
        let progress = parseFloat(sanitizeNumberString(data.progress));
        //console.log('Parsed data.progress: ' + progress)
        if (!isNaN(progress)) {
            document.getElementById('progressBar').style.width = progress + '%';
        }
    } catch (error) {
        if (connected) {
            connectionErrors++;
            if (connectionErrors >= 5) {
                connected = false;
                connectionErrors = 0; // reset after connection loss
                showSpinner('Connection lost')
            }
            appendLog('Error fetching status: ' + error);
        } // hide errors when no initial connection
    }
}

async function sendCommand(command, params = '') {
    pauseStatusUpdates();
    isSendingCommand = true;
    //appendLog(`Sending command: ${command}${params}`);
    showSpinner("Executing command"); // Show spinner when command starts

    try {
        const response = await fetch(`/command/${command}${params}`); // read response from C#
        if (!response.ok) { throw new Error(`Server responded with status ${response.status}`); }
        const data = await response.text(); // get the response message
        pauseSpinner(); // stop the spinning while the message is shown (probably should do something less ugly?)
        appendLog(data);
        setSpinnerText(data); // show the message on the spinner
        await new Promise(r => setTimeout(r, 1500)); 
    } catch (error) {
        // todo better logging
        appendLog('Error sending command: ' + error);
    } finally {
        isSendingCommand = false;
        resumeStatusUpdates();
        hideSpinner(); // Hide spinner when command completes
    }
}

function handleKeyPress(event) {
    if (event.key === 'Escape') {
        closeFileList();
    }
}

window.addEventListener('load', async () => {
    document.addEventListener('keydown', handleKeyPress);
    showSpinner('Waiting for connection'); // user *should* never see this, but just in case
    await fetchStatus(); // Initial fetch
    statusInterval = setInterval(fetchStatus, 1000);
    
});
