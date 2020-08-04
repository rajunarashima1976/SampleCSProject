function isUrlValid(url) {
    var decodedurl = decodeURI(url);
    var encodedurl = encodeURI(decodedurl);
    var pattern = new RegExp('^(https?:\\/\\/)?' + // protocol
        '((([a-z\\d]([a-z\\d-]*[a-z\\d])*)\\.?)+[a-z]{2,}|' + // domain name
        '((\\d{1,3}\\.){3}\\d{1,3}))' + // ip (v4) address
        '(\\:\\d+)?(\\/[-a-z\\d%_.~+]*)*' + //port
        '(\\?[;&a-z\\d%_.~+=-]*)?' + // query string
        '(\\#[-a-z\\d_]*)?$', 'i');
    return pattern.test(encodedurl);
}
