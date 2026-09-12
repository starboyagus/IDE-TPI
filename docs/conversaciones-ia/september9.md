# Conversacion 9 de Septiembre

$-$ Es necesario que el Salt se guarde en la base de datos?

$+$ Sí, es necesario. sin el salt guardado nadie podría loguearse nunca más.

$+$ La razón es cómo funciona la validación. Cuando alguien escribe su contraseña, vos hacés HashPassword(contraseña, salt) y comparás contra el hash guardado. Si no tenés el salt, no podés recalcular el mismo hash: el salt es aleatorio por usuario, no se puede adivinar ni derivar. Es justamente el usuario.Salt que usa tu ValidatePassword.

$+$ Que dos usuarios con la misma contraseña tengan hashes distintos. Sin salt, si Juan y María usan usuario123, en la base se ve el mismo hash — y ahí ya sabés que comparten contraseña.
Romper las rainbow tables. Un atacante no puede usar una tabla precalculada de hashes comunes: tendría que hacer fuerza bruta usuario por usuario, con las 10.000 iteraciones de PBKDF2 en cada intento.
Es distinto de la SecretKey del JWT, que sí es secreta y no debería estar en el repo.

$+$ Columna separada (lo que tenés): Salt y Contrasenia por un lado y por otro. Explícito, y es lo que hace el ejemplo del profe.

$+$ Todo en un solo campo: guardar "salt.hash" concatenado en Contrasenia. Es lo que hacía el PasswordHasher que borramos, y es lo que hacen bcrypt y argon2 en la vida real (su string incluye algoritmo, costo, salt y hash, todo junto).

$+$ Como ya lo tenés andando con la columna y además coincide con la referencia del profe, yo lo dejaría así. La única variante que sí estaría mal es usar un salt fijo para todos hardcodeado en el código: ahí perdés las dos ventajas de arriba y volvés casi al problema original.

$-$ Generame una secret key para JWT

$+$ Aquí tenés una secret key criptográficamente segura de 512 bits (64 bytes), ideal para JWT con algoritmo HS256 o HS512:

> uMXoq7jFAh1y2uWzQi2SvgKkGfYgM31jU1oKW4mvyBUrR8ZHVZUAv1+bsGYxVWJRxdKRL5/9OD6CRLyQjtjgAw==
