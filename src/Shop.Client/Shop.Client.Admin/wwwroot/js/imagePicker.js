async function loadImageAsync() {
    const [filePicker] = await window.showOpenFilePicker();
    const file = await filePicker.getFile();

    if (!file) {
        return null;
    }

    const buffer = await file.arrayBuffer();
    const bytes = new Uint8Array(buffer);

    const blob = new Blob([buffer], {type: 'image/png'});
    const url = URL.createObjectURL(blob);

    return {
        imgUrl: url,
        imgBytes: bytes
    };
}
