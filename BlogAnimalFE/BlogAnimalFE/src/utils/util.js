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


export default fileToBase64;
