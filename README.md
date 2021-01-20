# cuponApi
Ficheros Proyecto Cupon  Api 
## Table of Contentenido

1. [Informacion General]
2. [Instruccion de Funcionamiento]


### Informacion General
El presente repositorio comprende los archivos fuente correspondiente
al Challenge Cupon  Nivel 2 y 3.


### Instruccion de Funcionamiento

En la url: https://cuponapi.azurewebsites.net/swagger/index.html	

Se dejaran ver las caracterísiticas principales del Api construida para la referencia.

En la herramienta Postman se podrá validar el funcionamiento del API con el endpoint:
	
	curl -X POST "https://cuponapi.azurewebsites.net/Items/coupon" 

Para verificar su funcionamiento se deberá ingresar un objeto JSON en el body del Request como:

{ "item_ids": ["MLA883388664","MLA886755624",  "MLA899974954", "MLA16244135", "MLA876906386","MLA872354019"], "amount": 100000}
	
y haciendo una peticion POST dejará ver algún tipo de respuesta en el body y como Status HTTP 200-OK o 404-NOT_FOUND dependiendo dicha entrada. 

	


