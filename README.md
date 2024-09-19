# Cliente TCP - Aplicaci�n MAUI

Este proyecto implementa una aplicaci�n cliente de .NET MAUI que se conecta a un servidor TCP para autenticaci�n y comunicaci�n de eco. Permite a los usuarios autenticarse y enviar mensajes, recibiendo una respuesta de eco del servidor.

## Requisitos

- .NET 6.0 o superior
- .NET MAUI

## Funcionalidades

- **Conexi�n a servidor TCP** en `127.0.0.1` en el puerto `12345`.
- **Autenticaci�n** del usuario con una clave.
- **Env�a mensajes al servidor** y recibe respuestas de eco.
- **Cierra la conexi�n** enviando el comando `exit`.

## Instalaci�n

1. **Clonar el repositorio**:

    ```bash
    git clone https://github.com/AaronF11/Client.git
    cd Client
    ```

2. **Abrir el proyecto en Visual Studio**:
    - Aseg�rate de tener la extensi�n de .NET MAUI instalada.

3. **Ejecutar la aplicaci�n**:
    - Selecciona el emulador o dispositivo de destino y ejecuta el proyecto.

## Uso

1. Ejecuta la aplicaci�n en un emulador o dispositivo.
2. Introduce la clave de autenticaci�n en el campo correspondiente y haz clic en el bot�n de conexi�n.
3. Si la autenticaci�n es exitosa, podr�s habilitar el campo para enviar mensajes y el bot�n para enviar.
4. Escribe un mensaje en el campo de eco y haz clic en el bot�n de env�o para enviar el mensaje al servidor.
5. Para cerrar la conexi�n, haz clic en el bot�n de desconexi�n.

## Ejemplo de Uso

### Interfaz de usuario

- **Campo de autenticaci�n**: Introduce la clave (ej. `admin123`).
- **Bot�n de conexi�n**: Establece la conexi�n al servidor.
- **Campo de eco**: Escribe el mensaje que deseas enviar.
- **Bot�n de env�o**: Env�a el mensaje al servidor y muestra la respuesta.
- **Bot�n de desconexi�n**: Cierra la conexi�n con el servidor.

### Consola del cliente

```bash
Conectando al servidor...
Respuesta: Autenticacion exitosa
Comando enviado: Hola servidor
Respuesta: Hola servidor
Conexi�n cerrada.
```

## Notas

- Aseg�rate de que el servidor est� en ejecuci�n antes de intentar conectar.
- El cliente solo acepta una clave de autenticaci�n espec�fica para acceder a la funcionalidad de eco.