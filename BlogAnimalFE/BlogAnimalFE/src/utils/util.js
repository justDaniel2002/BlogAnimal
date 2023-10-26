export function fileToBase64(file) {
  console.log(file);
  return new Promise((resolve) => {
    const reader = new FileReader();

    reader.onload = (event) => {
        const result = event.target?.result
        const base64String = result ? result.split(",")[1] : null;
        resolve("data:image/jpeg;base64,"+base64String);
    };

    reader.readAsDataURL(file);
});
}

export function convertFileListToBytes(fileList) {
  const byteArrays = [];

  for (let i = 0; i < fileList.length; i++) {
    const file = fileList[i];
    const reader = new FileReader();

    reader.onload = (event) => {
      const arrayBuffer = event.target.result;

      // Convert the ArrayBuffer to a byte array
      const byteArray = new Uint8Array(arrayBuffer);

      // Push the byte array into the result array
      byteArrays.push(byteArray);

      // If you've processed all files, you can do something here
      if (byteArrays.length === fileList.length) {
        console.log('All files converted to byte arrays:', byteArrays);
        // Now you can send this array to your API, for example.
      }
    };

    reader.readAsArrayBuffer(file);
  }
}


export default fileToBase64;
