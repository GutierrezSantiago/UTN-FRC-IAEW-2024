const jwt = require('jsonwebtoken');

// Cargar la clave pública desde un archivo
const publicKey = `
-----BEGIN PUBLIC KEY-----
<key_placeholder>
-----END PUBLIC KEY-----`;

function validateToken(token) {
    try {
        const decoded = jwt.verify(token, publicKey, { algorithms: ['RS256'] });
        console.log('Token válido:', decoded);
        return decoded;
    } catch (error) {
        console.error('Token inválido:', error.message);
        return null;
    }
}

// Ejemplo de uso
var token = 'JWT_TOKEN';

validateToken(token);
