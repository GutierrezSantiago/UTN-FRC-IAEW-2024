function parseJwt(token) {
    var base64Url = token.split('.');
    var base64 = base64Url[1].replace(/-/g, '+').replace(/_/g, '/'); // Reemplazamos caracteres URL-safe

    while (base64.length % 4) {
        base64 += '='; // Agregamos padding si es necesario
    }

    var jsonPayload = decodeURIComponent(atob(base64).split('').map(
        (c) => '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2)
    ).join(''));

    return JSON.parse(jsonPayload);
}

var jwt = 'JWT_TOKEN';

console.log(parseJwt(jwt));
