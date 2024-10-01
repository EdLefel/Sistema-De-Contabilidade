window.downloadFileFromStream = async function (fileName, contentStream) {
    const arrayBuffer = await contentStream.arrayBuffer();
    const blob = new Blob([arrayBuffer], { type: 'application/pdf' });
    const url = URL.createObjectURL(blob);
    const anchorElement = document.createElement('a');
    anchorElement.href = url;
    anchorElement.download = fileName;
    anchorElement.click();
    anchorElement.remove();
    URL.revokeObjectURL(url);
};
