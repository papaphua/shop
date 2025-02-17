var ImagePicker = ImagePicker || {};

ImagePicker.registerReferenceAsync = async function (dotNetObject) {
    ImagePicker.dotNetHelper = dotNetObject;
};

ImagePicker.loadImageAsync = async function () {
    const [filePicker] = await window.showOpenFilePicker();

    const file = await filePicker.getFile();
    const buffer = await file.arrayBuffer();
    const bytes = new Uint8Array(buffer);

    const blob = new Blob([buffer], {type: 'image/png'});
    const url = URL.createObjectURL(blob);

    return {
        imgUrl: url,
        imgBytes: bytes
    };
};
