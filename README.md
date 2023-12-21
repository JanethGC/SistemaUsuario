• ¿Cómo decidió las opciones técnicas y arquitectónicas utilizadas como parte de su solución? 
  Tomé decisiones técnicas y arquitectónicas basadas en una evaluación de los requisitos del proyecto, consideraciones clave de rendimiento y mantenimiento. 
  - La elección de ASP.NET Core a pesar que era parte de los requisitos me parecio muy buena ya que la arquitectura basada en middleware de ASP.NET Core proporciona flexibilidad en la gestión de solicitudes HTTP.
  - React que asi mismo fue parte del requerimiento me parecio una buena opcion  para el frontend debido a la modularidad de los componentes en React ya que facilita la organización del código y la reutilización, lo que es esencial para el desarrollo ágil.
  - La elección de React Router Dom se fundamentó en la necesidad de gestionar la navegación en la página web y esta librería simplifica la definición y gestión de rutas en la aplicación.
  - La decisión de utilizar Redux Toolkit y React-Redux para la gestión del estado se basó en la necesidad de una solución para el manejo del estado global y TOOLTIK para simplificar su implementacion.
  - Se eligió Axios para realizar solicitudes HTTP debido a su simplicidad, compatibilidad con promesas y fácil integración con React.
  - La elección de Bootstrap como framework de estilo se basó en la necesidad de un diseño rápido y responsivo.
  - Entity Framework Core fue seleccionado para interactuar con la base de datos debido a su capacidad para abstraer la capa de datos y simplificar las operaciones de base de datos asi como la conexion.


• ¿Hay alguna mejora que pueda hacer en su envío? 
 En realidad bastante entre ellas la organizacion de los archivos, estilos y funcionalidad.

• ¿Qué haría de manera diferente si se le asignara más tiempo? 
  Realizaria un esquema de trabajo que me permita enforcarme en el FRONTEND mas que todo que esta prueba se trata de demostrar mis habilidades en el FRONTEND y en esta ocasion inicie en el BACKEND por lo que no sera perceptible la funcionalidad.

Instrucciones de configuración/ejecución:
Proceder con las siguientes intalaciones:
  npm install react@latest  react-dom@latest
  npm i react-router-dom  //para menjar rutas 
  npm install @reduxjs/toolkit react-redux
  npm install axios

  Se agrega el framework EntityFrameworkCore.SqlServer
  Se agrega el framework EntityFrameworkCore.tools

  URL INICIO: http://localhost/SGU/Login
  Cambiar cadena de conexion en el archivo appSetting.json
