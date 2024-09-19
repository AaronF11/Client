# Cliente TCP - Aplicación MAUI

Este proyecto implementa una aplicación cliente de .NET MAUI que se conecta a un servidor TCP para autenticación y comunicación de eco. Permite a los usuarios autenticarse y enviar mensajes, recibiendo una respuesta de eco del servidor.

## Requisitos

- .NET 6.0 o superior
- .NET MAUI

## Funcionalidades

- **Conexión a servidor TCP** en `127.0.0.1` en el puerto `12345`.
- **Autenticación** del usuario con una clave.
- **Envía mensajes al servidor** y recibe respuestas de eco.
- **Cierra la conexión** enviando el comando `exit`.

## Instalación

1. **Clonar el repositorio**:

    ```bash
    git clone https://github.com/AaronF11/Client.git
    cd Client
    ```

2. **Abrir el proyecto en Visual Studio**:
    - Asegúrate de tener la extensión de .NET MAUI instalada.

3. **Ejecutar la aplicación**:
    - Selecciona el emulador o dispositivo de destino y ejecuta el proyecto.

## Uso

1. Ejecuta la aplicación en un emulador o dispositivo.
2. Introduce la clave de autenticación en el campo correspondiente y haz clic en el botón de conexión.
3. Si la autenticación es exitosa, podrás habilitar el campo para enviar mensajes y el botón para enviar.
4. Escribe un mensaje en el campo de eco y haz clic en el botón de envío para enviar el mensaje al servidor.
5. Para cerrar la conexión, haz clic en el botón de desconexión.

## Ejemplo de Uso

### Interfaz de usuario

- **Campo de autenticación**: Introduce la clave (ej. `admin123`).
- **Botón de conexión**: Establece la conexión al servidor.
- **Campo de eco**: Escribe el mensaje que deseas enviar.
- **Botón de envío**: Envía el mensaje al servidor y muestra la respuesta.
- **Botón de desconexión**: Cierra la conexión con el servidor.

### Consola del cliente

```bash
Conectando al servidor...
Respuesta: Autenticacion exitosa
Comando enviado: Hola servidor
Respuesta: Hola servidor
Conexión cerrada.
```

## Notas

- Asegúrate de que el servidor esté en ejecución antes de intentar conectar.
- El cliente solo acepta una clave de autenticación específica para acceder a la funcionalidad de eco.