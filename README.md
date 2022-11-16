<h1 class="code-line" data-line-start=0 data-line-end=1 ><a id="Juguemos_al_UNO_0"></a>Juguemos al UNO</h1>
<hr>
<h2 class="code-line" data-line-start=2 data-line-end=3 ><a id="Presentacin_2"></a>Presentación</h2>
<pre><code>Soy Agustin Sbernini, estudiante de la carrera de Técnico Superior en Programación
en la UTN FRA. Este proyecto representa el segundo parcial de Laboratorio II.
Durante la realización del mismo aprendí el manejo de base de datos, de excepciones, de eventos, de delegados. Fue un proceso constante de superación ya que aplicar temas complejos hizo que fuese mas robusta la aplicación, con más funcionalidades y más interactiva. Uno de mis grandes errores el cual limitó el desempeño global del parcial fue la perdida de tiempo en intentar realizar ciertas partes del trabajo a mi manera para darle mi impronta cuando podría solucionar de otras maneras más sencillas o ser muy minucioso con detalles que no aportan lo equivalente, es un error que sigo arrastrando desde el pasado y se me hace dificil superar. Para futuros proyectos intentaré en efocar mi tiempo y esfuerzo en completar la funcionalidad general, luego involucrarme en los detalles mas precisos.
</code></pre>
<hr>
<h2 class="code-line" data-line-start=7 data-line-end=8 ><a id="Resumen_7"></a>Resumen</h2>
<ul>
<li class="has-line-data" data-line-start="8" data-line-end="9">Dentro del primer form se podran logear los usuarios o registrar nuevos.</li>
<li class="has-line-data" data-line-start="9" data-line-end="10">Dentro del menu principal se encuentran 4 botones los cuales te permiten crear partidas distintas entre ellas dando a elegir si jugar o simular una partida y si se quiere que sea rapida o normal. También puede visualizarse la tabla de todas las partidas que se han creado y si estan en curso actualmente, si la partida finalizó te permite descargar el historial de las cartas tiradas, se puede cambiar la grilla para visualizar los jugadores que estan registrados en la base de datos y descargar la información personal de ellos.</li>
<li class="has-line-data" data-line-start="10" data-line-end="11">Dentro de la sala se puede visualizar la cantidad de cartas que tiene cada jugador, el tiempo que falta para que tire su carta (a menos que sea el turno del usuario), las cartas que tiene en su mano, la carta que esta tirada en mesa y el mazo de donde se puede agarrar carta cuando no tenga cartas para tirar. También esta el botón con el cual se tira la carta cuando sea posible o en caso de no jugar el usuario es con el cual se inicia y termina la partida de los bots. Por ultimo un botón con el cual se puede visualizar el historial de la partida en tiempo real y descargarlo.</li>
<li class="has-line-data" data-line-start="11" data-line-end="13">Adjunto la base de datos dentro de GitHub. Para poder utilizarla es probable que deban, además de importarla a SQL Server, cambiar el string de conexión que se encuentra en la clase</li>
</ul>
<hr>
<h2 class="code-line" data-line-start=14 data-line-end=15 ><a id="Diagrama_de_Clases_14"></a>Diagrama de Clases</h2>
<h2 class="code-line" data-line-start=16 data-line-end=18 ><a id="Diagrama_de_Clasespnghttpswwwdropboxcomspgldusefgm5lhxrDiagrama20de20clasespngdl0raw1_16"></a><img src="https://www.dropbox.com/s/pgldusefgm5lhxr/Diagrama%20de%20clases.png?dl=0&amp;raw=1" alt="Diagrama de Clases.png"></h2>
<ul>
<li class="has-line-data" data-line-start="18" data-line-end="20">
<p class="has-line-data" data-line-start="18" data-line-end="19"><em>Tema Excepciones:</em> Se utiliza principalmente en la base de datos que es la mas propensa a causar errores y en el label de la carta mesa ya que a veces se intenta cambiar la imagen sin un index del listbox.</p>
</li>
<li class="has-line-data" data-line-start="20" data-line-end="22">
<p class="has-line-data" data-line-start="20" data-line-end="21"><em>Tema SQL:</em> Se utiliza para guardar la base de datos de los usuarios registrados con sus estadisticas y de las partidas generadas con toda su informacion. Al ir modificando de manera dinamica esta inforamción la base de datos fue más útil que la serialización.</p>
</li>
<li class="has-line-data" data-line-start="22" data-line-end="24">
<p class="has-line-data" data-line-start="22" data-line-end="23"><em>Tema Generics e Interfaces:</em> Junto ambos conceptos para utilizarlos en el manejo de base de datos ya que tanto en el caso de Partidas como de Usuarios hago un Select, un Insert y un Update. Gracias a las interfaces puedo mantener una firma para que sea claro que en ambos casos realizo la misma acción y gracias a Generics puedo cambiar los parametros y los retornos correspondiendo a cada clase</p>
</li>
<li class="has-line-data" data-line-start="24" data-line-end="26">
<p class="has-line-data" data-line-start="24" data-line-end="25"><em>Tema Serializacion:</em> Fue útil para guardar la información de las cartas, ya que este no va a variar en ningún momento me permitió recolectar el mazo de cartas de manera sencilla con una función y más liviana gracias al formato Json.</p>
</li>
<li class="has-line-data" data-line-start="26" data-line-end="28">
<p class="has-line-data" data-line-start="26" data-line-end="27"><em>Tema Escritura de Archivos:</em> La aplicación permite al usuario descargar la información del usuario que desee o descargar el historial de la partida que seleccione. También esta usado implicitamente en serialización ya que en caso de no existir el archivo con las cartas genera uno nuevo.</p>
</li>
<li class="has-line-data" data-line-start="28" data-line-end="30">
<p class="has-line-data" data-line-start="28" data-line-end="29"><em>Tema Delegados y Eventos:</em> Los utilizo para transmitir información de un formulario a otro. Dentro del form de la partida le transmito al form historial cada carta que se va tirando y el efecto que esta genera en la partida, también desde el form de la partida recolecto el color al cual elige cambiar el usuario.</p>
</li>
<li class="has-line-data" data-line-start="30" data-line-end="32">
<p class="has-line-data" data-line-start="30" data-line-end="31"><em>Tema Task:</em> Se utilizó para crear las partidas y que fueran independientes entre ellas. Aunque su uso más escencial fue en la lógica de los bots ya que permitió poder agregar un contador y hacerlos esperar para que el juego sea más dinámico y entendible, permitiendo además que el usuario pueda seguir interactuando con el formulario sin que este se trabe.</p>
</li>
</ul>
<hr>
<h3 class="code-line" data-line-start=33 data-line-end=34 ><a id="Los_usuarios_y_contraseas_disponibles_para_logear_son_33"></a>Los usuarios y contraseñas disponibles para logear son:</h3>
<h5 class="code-line" data-line-start=34 data-line-end=35 ><a id="Usuario_Auxiliar____Password_asdasd_34"></a>Usuario: Auxiliar  -  Password: asdasd</h5>
<h5 class="code-line" data-line-start=35 data-line-end=36 ><a id="Usuario_Agustin____Password_agus123_35"></a>Usuario: Agustin  -  Password: agus123</h5>
<h6 class="code-line" data-line-start=36 data-line-end=37 ><a id="Tiene_la_opcion_diponible_de_crear_su_propio_usuario_36"></a>Tiene la opcion diponible de crear su propio usuario</h6>
<hr>