Feature: MetodosPago
	COMO padre de familia 
	QUIERO poder gestionar mis métodos de pago 
	PARA poder realizar pagos fututos de las tutorías de mis hijos.

@mytag
Scenario: Registrar tarjeta
	Given el usuario padre ha iniciado sesión correctamente
	And se encuentra en la sección Tarjetas de la vista Perfil
	When seleccione la opción “Agregar tarjeta”
	Then se mostrara un formulario para el registro de una nueva tarjeta

@mytag
Scenario: Datos mal ingresados
	Given el ususario padre se encuentra en el formulario de registro de nueva tarjeta
	When se ingrese información incorrecta y se envié el formulario 
	Then el sistema mostrara el mensaje “los datos no son correctos”


@mytag
Scenario: Eliminar tarjeta
	Given el usuario padre ha iniciado sesión correctamente
	And se encuentra en la sección Tarjetas de la vista Perfil
	When seleccione la opción “eliminar” de una tarjeta registrada 
	Then se mostrara una ventana de confirmación para esa accion.
