# Conversacion 11 de Julio

$-$ Tengo que hacer un CRUD sin persistencia y me dieron este ejemplo, para que es cada cosa

$+$ ¡Hola! Este ejemplo que te dieron está estructurado siguiendo los principios de la Arquitectura Limpia (Clean Architecture) o un modelo de N-Capas muy bien organizado. Su objetivo es separar las responsabilidades para que el código sea fácil de mantener, escalar y probar. Como tu tarea es hacer un CRUD sin persistencia (es decir, los datos se guardarán en la memoria RAM mientras la aplicación esté corriendo, y se borrarán al apagarla), esta estructura te servirá perfectamente. Aquí tienes el desglose de para qué sirve cada proyecto (carpeta) dentro de la solución:

**1. Domain.Model (Modelo de Dominio):** Es el "corazón" de tu aplicación. Aquí no debe haber dependencias de bases de datos, ni de la web.

- ¿Para qué sirve? Contiene las clases que representan los objetos de tu negocio (las "Entidades").
- Archivos: Cliente.cs y Pais.cs tendrán las propiedades básicas (Id, Nombre, etc.). ClienteCriteria.cs seguramente es una clase para definir filtros de búsqueda (por ejemplo, buscar clientes por nombre o país).

**2. DTOs (Data Transfer Objects):** Los DTOs son "objetos de transferencia de datos".

- ¿Para qué sirven? Se usan para decidir exactamente qué datos vas a recibir del usuario (cuando hace un POST/PUT) y qué datos le vas a devolver. Es una mala práctica exponer tus entidades de Domain.Model directamente a la web. Los DTOs evitan que muestres información sensible o innecesaria.
- Archivos: ClienteDTO.cs, PaisDTO.cs.

**3. Data (Acceso a Datos / Repositorios):** Esta capa es la encargada de guardar y recuperar la información.

- ¿Para qué sirve? Aquí se implementa el Patrón Repositorio. Las interfaces (IClienteRepository.cs) definen qué se puede hacer (Ej: ObtenerTodos(), Guardar(), Eliminar()), y las clases sin la "I" (ClienteRepository.cs) definen cómo se hace.
- Tu caso SIN persistencia: Como no vas a usar una base de datos (SQL, Entity Framework), aquí es donde vas a crear listas estáticas en memoria. Por ejemplo, dentro de ClienteRepository.cs tendrías algo como private static List<Cliente> _clientes = new List<Cliente>(); y tus métodos de agregar o borrar simplemente modificarán esa lista.

**4. Application.Services (Capa de Servicios o Lógica de Negocio):** Es el intermediario entre la API (la web) y los datos.

- ¿Para qué sirve? Aquí van las reglas de negocio. Por ejemplo, si al crear un Cliente necesitas verificar que el email no exista ya, esa validación va aquí. Los servicios llaman a los repositorios (Data) para obtener o guardar las entidades, y luego transforman (mapean) esas entidades en DTOs para devolverlos a la API.
- Archivos: Igual que en Data, se divide en Interfaces (IClienteService.cs) y sus implementaciones (ClienteService.cs).

**5. Web API (Capa de Presentación):** Es la puerta de entrada a tu aplicación desde el exterior.

- ¿Para qué sirve? Expone las URLs (endpoints) a las que un cliente (como un navegador o Postman) puede hacer peticiones HTTP (GET, POST, PUT, DELETE).
- Archivos: * Program.cs: Es la configuración inicial. Aquí "inyectas" tus dependencias (le dices a la app qué servicio usar cuando alguien pida un IClienteService) y levantas el servidor.
ClienteEndpoints.cs y PaisEndpoints.cs: Están usando "Minimal APIs" (una forma moderna y rápida de hacer APIs en C#). Aquí defines las rutas (ej. app.MapGet("/clientes", ...)), las cuales recibirán la petición web y se la pasarán inmediatamente a Application.Services para que haga el trabajo real.

Resumen del flujo para tu CRUD:

1. El usuario envía un JSON a la Web API (Endpoints) para crear un cliente.
2. La WebAPI toma ese JSON (como DTO), se lo pasa a Application.Services.
3. El Servicio hace las validaciones necesarias, convierte el DTO en un objeto del Domain.Model (Cliente) y se lo pasa a Data (Repository).
4. El Repositorio guarda ese Cliente en tu lista estática en memoria (porque es sin persistencia).

$-$ Si quiero agregar algo nuevo, por ejemplo un producto, que carpeta debería agregar/editar primero?

$+$ ¡Excelente pregunta! En este tipo de arquitectura (que se construye desde el "centro" hacia "afuera"), la regla de oro es empezar siempre por el dominio de tu negocio. Por lo tanto, la primera carpeta que debes editar es Domain.Model. Aquí tienes el orden exacto (paso a paso) que deberías seguir para agregar tu nuevo CRUD de "Producto" sin romper la arquitectura:

**1. Domain.Model (El Centro):** Es lo primero que debes crear porque el resto de las capas van a depender de esto.

- Agrega: Un archivo llamado Producto.cs.
- Qué lleva: Las propiedades de tu producto (ej. Id, Nombre, Precio, Stock). Todo muy limpio, sin pensar en bases de datos ni en la web.

**2. DTOs (Lo que vas a mostrar/recibir):** Una vez que sabes qué es un Producto, decides qué datos vas a compartir con el exterior.

- Agrega: Un archivo llamado ProductoDTO.cs.
- Qué lleva: Probablemente lo mismo que el modelo (Id, Nombre, Precio, Stock), pero te sirve por si en el futuro quieres ocultar algún dato interno.

**3. Data (El Almacenamiento en memoria):** Ahora que tienes el modelo, necesitas un lugar donde guardarlo.

- Agrega: La interfaz IProductoRepository.cs y la clase ProductoRepository.cs.
- Qué lleva: La interfaz tendrá los métodos (ej. List<Producto> ObtenerTodos(), void Agregar(Producto p)). La clase implementará esos métodos utilizando una lista estática, algo así como: private static List<Producto> _productos = new List<Producto>();.

**4. Application.Services (La Lógica):** Ya puedes guardar productos, ahora necesitas la capa que coordine esto y aplique reglas (ej. "el precio no puede ser negativo").

- Agrega: La interfaz IProductoService.cs y la clase ProductoService.cs.
- Qué lleva: Esta clase recibirá el IProductoRepository y se encargará de transformar los ProductoDTO que llegan desde la web hacia el modelo Producto para que el repositorio los guarde.

**5. WebAPI (La Puerta de Entrada):** Por último, expones tu nuevo producto al mundo web.

- Agrega: Un archivo llamado ProductoEndpoints.cs.
Qué lleva: Las rutas HTTP. Por ejemplo: app.MapGet("/productos", ...), app.MapPost("/productos", ...). Estas rutas llamarán a los métodos de tu ProductoService.
- ¡Paso CRÍTICO en WebAPI! No te olvides de ir al archivo Program.cs. Allí debes registrar tus nuevas clases para que la aplicación sepa que existen (Inyección de Dependencias).
