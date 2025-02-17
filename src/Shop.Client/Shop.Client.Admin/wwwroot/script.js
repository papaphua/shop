var ImagePicker = ImagePicker || {};

ImagePicker.registerReference = function (dotNetObject) {
    ImagePicker.dotNetHelper = dotNetObject;
};

ImagePicker.loadImage = function() {
    const input = document.createElement('input');
    
    input.type = 'file';
    input.accept = 'image/*';
    
    document.body.appendChild(input);
    
    input.click();

    input.onchange = function(event) {
        const file = event.target.files[0];

        if (!file) return;

        const reader = new FileReader();
        reader.readAsArrayBuffer(file);

        reader.onload = function(event) {
            const bytes = new Uint8Array(event.target.result);
            const string = Array.from(bytes, byte => String.fromCharCode(byte)).join('');
            const base64String = btoa(string);

            ImagePicker.dotNetHelper.invokeMethodAsync('HandleFileChange', base64String);
        };

        reader.onerror = function() {
            console.error("Error reading file");
        };
    };
};
