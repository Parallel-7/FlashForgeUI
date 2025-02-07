async function showFileSelection(listType) {
    console.log('showFileSelection called with listType:', listType);
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

function displayFileSelection(files, listType) {
    console.log('displayFileSelection called with listType:', listType, 'and files:', files);
    const fileList = document.getElementById('fileList');

    if (fileList) {
        fileList.innerHTML = '';

        if (files.length === 0) {
            const noFilesMsg = document.createElement('p');
            noFilesMsg.textContent = 'No files available.';
            fileList.appendChild(noFilesMsg);
            return;
        }

        files.forEach(file => {
            const fileItem = document.createElement('div');
            fileItem.classList.add('file-item');
            fileItem.onclick = function() { selectFile(fileItem, file); };

            // Request thumbnail via WebSocket
            sendWebSocketMessage({
                type: 'getThumbnail',
                parameters: { filename: file }
            });

            const thumbnail = document.createElement('img');
            thumbnail.id = `thumb-${file}`;
            thumbnail.alt = file;
            thumbnail.onerror = () => { thumbnail.src = ''; };
            fileItem.appendChild(thumbnail);

            const fileName = document.createElement('p');
            fileName.textContent = file;
            fileItem.appendChild(fileName);
            fileList.appendChild(fileItem);
        });

        console.log('Files loaded into modal');
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