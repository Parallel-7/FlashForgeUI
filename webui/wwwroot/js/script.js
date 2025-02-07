// Global Variables
let ws = null;
let currentListType = null;
let selectedFile = null;
let isSendingCommand = false;
let nonProFlag = false;
let connected = false;
let config = null;
let reconnectAttempts = 0;
const MAX_RECONNECT_ATTEMPTS = 5;

function initializeWebSocket() {
    const wsProtocol = window.location.protocol === 'https:' ? 'wss:' : 'ws:';
    const wsUrl = `${wsProtocol}//${window.location.host}/ws`;

    showSpinner('Connecting to printer server...');
    ws = new WebSocket(wsUrl);

    ws.onopen = () => {
        connected = true;
        reconnectAttempts = 0;
        appendLog('Connected to printer server');
    };

    ws.onclose = () => {
        connected = false;
        handleDisconnect();
    };

    ws.onerror = (error) => {
        console.error('WebSocket error:', error);
        handleDisconnect();
    };

    ws.onmessage = (event) => {
        try {
            const message = JSON.parse(event.data);
            handleWebSocketMessage(message);
        } catch (error) {
            console.error('Error parsing WebSocket message:', error);
        }
    };
}

function handleDisconnect() {
    if (reconnectAttempts < MAX_RECONNECT_ATTEMPTS) {
        reconnectAttempts++;
        showSpinner('Connection lost. Reconnecting...');
        setTimeout(initializeWebSocket, 2000);
    } else {
        showSpinner('Connection lost. Please refresh the page.');
    }
}

function handleWebSocketMessage(message) {
    if (!message.type) return;

    switch (message.type) {
        case 'config':
            handleConfigMessage(message.data);
            hideSpinner();
            break;
        case 'status':
            handleStatusUpdate(message.data);
            break;
        case 'response':
            handleCommandResponse(message.data);
            break;
        case 'error':
            appendLog('Error: ' + message.message);
            if (isSendingCommand) {
                hideSpinner();
                isSendingCommand = false;
            }
            break;
        case 'fileList':
            handleFileList(message.data);
            break;
        case 'thumbnail':
            handleThumbnail(message.filename, message.data);
            break;
    }
}

function handleConfigMessage(configData) {
    config = configData;
    
    
    if (config.debugMode) {
        appendLog('Debug mode enabled');
    }
}

function handleStatusUpdate(status) {
    if (!status) return;

    document.getElementById('currentJob').textContent = status.currentJob || 'Current Job';
    document.getElementById('eta').textContent = status.eta || '--';
    document.getElementById('progress').textContent = status.progress || '--';
    document.getElementById('extruderTemp').innerHTML = (status.extruderTemp || '--') + '°C';
    document.getElementById('bedTemp').innerHTML = (status.bedTemp || '--') + '°C';
    document.getElementById('printerStatus').textContent = status.printerStatus || '--';
    document.getElementById('filtrationStatus').textContent = status.filtrationStatus || '--';
    document.getElementById('filamentUsed').textContent = status.filamentUsed || '--';
    document.getElementById('totalRunTime').textContent = status.totalRunTime || '--';
    document.getElementById('layerInfo').textContent = status.layerInfo || '--';
    document.getElementById('weight').textContent = status.weight || '--';
    document.getElementById('length').textContent = status.length || '--';
    document.getElementById('coolingFanSpeed').textContent = status.coolingFanSpeed || '--';

    if (!nonProFlag && status.chamberFanSpeed !== undefined) {
        document.getElementById('chamberFanSpeed').textContent = status.chamberFanSpeed;
    }

    // Update Progress Bar
    let progress = parseFloat(sanitizeNumberString(status.progress));
    if (!isNaN(progress)) {
        document.getElementById('progressBar').style.width = progress + '%';
    }

    // Handle Pro/Non-Pro features
    if (!status.isPro && !nonProFlag) {
        // check for custom camera first before disabling view/controls
        if (!config.customCamera) {
            hideElement('webcam');
            hideElement('toggleWebcam');
        }
        hideElement('setChamberFanSpeed');
        hideElement('setLedOn');
        hideElement('setLedOff');
        hideElement('setExternalFiltration');
        hideElement('setInternalFiltration');
        hideElement('setFiltrationOff');
        appendLog('Non-pro model in use, some features have been restricted');
        nonProFlag = true;
    }
}

function handleCommandResponse(response) {
    appendLog(response);
    if (isSendingCommand) {
        isSendingCommand = false;
        hideSpinner();
    }
}

function handleFileList(files) {
    const fileList = document.getElementById('fileList');
    if (!fileList) return;

    fileList.innerHTML = '';

    if (!files || files.length === 0) {
        const noFilesMsg = document.createElement('p');
        noFilesMsg.textContent = 'No files available.';
        fileList.appendChild(noFilesMsg);
        return;
    }

    files.forEach(file => {
        const fileItem = document.createElement('div');
        fileItem.classList.add('file-item');
        fileItem.onclick = () => selectFile(fileItem, file);

        // Request thumbnail for this file
        sendWebSocketMessage({
            type: 'getThumbnail',
            parameters: { filename: file }
        });

        const thumbnail = document.createElement('img');
        thumbnail.id = `thumb-${file}`;
        thumbnail.alt = file;
        fileItem.appendChild(thumbnail);

        const fileName = document.createElement('p');
        fileName.textContent = file;
        fileItem.appendChild(fileName);
        fileList.appendChild(fileItem);
    });
}

function handleThumbnail(filename, base64Data) {
    const thumbnail = document.getElementById(`thumb-${filename}`);
    if (thumbnail) {
        thumbnail.src = `data:image/png;base64,${base64Data}`;
    }
}

async function sendCommand(command, params = {}) {
    if (!ws || ws.readyState !== WebSocket.OPEN) {
        appendLog('Not connected to server');
        return;
    }

    isSendingCommand = true;
    showSpinner('Executing command');

    sendWebSocketMessage({
        type: 'command',
        command: command,
        parameters: params
    });
}

function sendWebSocketMessage(message) {
    if (!ws || ws.readyState !== WebSocket.OPEN) {
        appendLog('Not connected to server');
        return;
    }

    try {
        ws.send(JSON.stringify(message));
    } catch (error) {
        appendLog('Error sending message: ' + error);
        if (isSendingCommand) {
            isSendingCommand = false;
            hideSpinner();
        }
    }
}

async function showFileSelection(listType) {
    const modal = document.getElementById('fileSelectionModal');
    const modalTitle = document.getElementById('modalTitle');
    const fileList = document.getElementById('fileList');

    if (modal && modalTitle && fileList) {
        modalTitle.textContent = listType === 'local' ? 'Select a G-code File to Print' : 'Select Recent Job';
        fileList.innerHTML = '<p>Loading...</p>';
        currentListType = listType;
        selectedFile = null;
        modal.removeAttribute('data-selected-file');
        document.body.classList.add('modal-active');

        sendWebSocketMessage({
            type: 'getFiles',
            parameters: { listType }
        });
    }
}

function selectFile(element, file) {
    const modal = document.getElementById('fileSelectionModal');
    const allFileItems = document.querySelectorAll('.file-item');
    allFileItems.forEach(item => item.classList.remove('selected'));
    element.classList.add('selected');
    selectedFile = file;
    modal.setAttribute('data-selected-file', file);

    const startPrintBtn = document.querySelector('.modal-content button[onclick="startPrintJob()"]');
    if (startPrintBtn) {
        startPrintBtn.disabled = false;
    }
}

function closeFileList() {
    const modal = document.getElementById('fileSelectionModal');
    if (modal) {
        document.body.classList.remove('modal-active');
        modal.removeAttribute('data-list-type');
        modal.removeAttribute('data-selected-file');
        selectedFile = null;
        currentListType = null;
    }
}

async function startPrintJob() {
    if (!selectedFile) {
        alert('No file selected!');
        return;
    }

    const autoLevel = document.getElementById('autoLevelCheckbox').checked;
    await sendCommand('startLocalJob', {
        filename: selectedFile,
        autoLevel: autoLevel
    });

    closeFileList();
}

async function promptForValue(command, message, paramName) {
    const value = prompt(message);
    if (value !== null && value.trim() !== '') {
        const params = { [paramName]: value.trim() };
        await sendCommand(command, params);
    } else {
        appendLog('Command cancelled: ' + command);
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

// Utility functions
function sanitizeNumberString(str) {
    if (typeof str !== 'string') str = String(str);
    let sanitized = str.replace(/[^0-9.-]+/g, '');
    sanitized = sanitized.replace(/(?!^)-/g, '');
    const parts = sanitized.split('.');
    if (parts.length > 2) {
        sanitized = parts[0] + '.' + parts.slice(1).join('');
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
        logDiv.scrollTop = logDiv.scrollHeight;
    }
}

function hideElement(id) {
    const element = document.getElementById(id);
    if (element) {
        element.style.display = 'none';
    }
}

function showSpinner(message = null) {
    const spinnerOverlay = document.getElementById('spinnerOverlay');
    if (spinnerOverlay) {
        resumeSpinner();
        spinnerOverlay.classList.remove('hidden');
        if (message) setSpinnerText(message);
    }
}

function hideSpinner() {
    const spinnerOverlay = document.getElementById('spinnerOverlay');
    if (spinnerOverlay) {
        spinnerOverlay.classList.add('hidden');
        const spinnerText = document.getElementById("spinnerTitle");
        if (spinnerText) spinnerText.textContent = '';
    }
}

function setSpinnerText(message) {
    if (message) {
        const spinnerText = document.getElementById("spinnerTitle");
        if (spinnerText) {
            spinnerText.textContent = message;
        }
    }
}

function resumeSpinner() {
    const spinnerOverlay = document.getElementById('spinnerOverlay');
    if (spinnerOverlay) {
        spinnerOverlay.style.animationPlayState = 'running';
    }
}

// Initialize WebSocket connection when the page loads
window.addEventListener('load', () => {
    initializeWebSocket();
});

// Handle page unload
window.addEventListener('beforeunload', () => {
    if (ws && ws.readyState === WebSocket.OPEN) {
        ws.close();
    }
});