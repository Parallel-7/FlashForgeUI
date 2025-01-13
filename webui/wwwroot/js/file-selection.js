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
        document.body.classList.add('modal-active'); // show the modal
        //console.log('Modal shown with listType:', listType);
        try {
            const response = await fetch(`/files?listType=${encodeURIComponent(listType)}`);
            if (!response.ok) { throw new Error(`Bad response: ${response.status}`); }
            const files = await response.json();
            displayFileSelection(files, listType);
        } catch (error) {
            fileList.innerHTML = '<p>Error loading files.</p>';
            //return 'Error fetching file list: ' + error;
        }
    }
}

// Display File Selection in Modal
function displayFileSelection(files, listType) {
    console.log('displayFileSelection called with listType:', listType, 'and files:', files);
    const fileList = document.getElementById('fileList');

    if (fileList) {
        fileList.innerHTML = ''; // clear old items

        if (files.length === 0) {
            const noFilesMsg = document.createElement('p');
            noFilesMsg.textContent = 'No files available.';
            fileList.appendChild(noFilesMsg);
            return;
        }

        files.forEach(file => { // loop through files
            const fileItem = document.createElement('div');
            fileItem.classList.add('file-item');
            fileItem.onclick = function() { selectFile(fileItem, file);}; // handle selecting a file

            const thumbnail = document.createElement('img'); // load preview
            thumbnail.src = '/thumbnails/' + encodeURIComponent(file);
            thumbnail.alt = file;
            thumbnail.onerror = () => { thumbnail.src = ''; }; // missing preview
            fileItem.appendChild(thumbnail);

            const fileName = document.createElement('p'); // add to list
            fileName.textContent = file;
            fileItem.appendChild(fileName);
            fileList.appendChild(fileItem);
        });

        console.log('Files loaded into modal');
    }
}

function selectFile(element, file) {
    //console.log('File selected:', file);
    const modal = document.getElementById('fileSelectionModal');
    const allFileItems = document.querySelectorAll('.file-item');
    allFileItems.forEach(item => item.classList.remove('selected'));
    element.classList.add('selected');
    selectedFile = file;
    modal.setAttribute('data-selected-file', file);
    
    const startPrintBtn = document.querySelector('.modal-content button[onclick="startPrintJob()"]'); // "unlock" start button
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
        //const fileList = document.getElementById('fileList');
        //if (fileList) {
        //    fileList.innerHTML = '';
        //}
        //console.log('Modal closed');
    }
}

async function startPrintJob() {
    //console.log('startPrintJob called');
    if (!selectedFile) {
        alert('No file selected!');
        return "No file selected";
    }

    const autoLevel = document.getElementById('autoLevelCheckbox').checked;
    let command = '';

    if (currentListType === 'local') {
        command = 'startLocalJob';
    } else if (currentListType === 'recent') {
        command = 'startRecentJob';
    } else {
        return('Unknown list type: ' + currentListType);
    }

    const params = `?filename=${encodeURIComponent(selectedFile)}&autoLevel=${autoLevel}`;
    await sendCommand(command, params);
    closeFileList();
    return "ok"
}