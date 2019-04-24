SET IDENTITY_INSERT CorreoPlantilla ON 

insert into CorreoPlantilla (PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro, Oficina)
values(73, '


<!DOCTYPE html>
<html>

<head>

	<title></title>

</head>

<body>

	<div>
      <p> Buenos días </p>  
      <p> A continuación se muestran los datos de la convocatoria de reunión.  </p> 
	</div>
  <hr> 
  	<div>
      
      <table style= "
    padding: 20px;
    border: 2px solid #9aad04;
    border-radius: 2px;
width:700px; height:100px;"
      >
      <tr>
  <td style="padding:10px; border-bottom-style:solid; border-bottom-color:#9aad04; width:200px; height:50px;"><b>Datos de Contacto</b></td>
  <td></td>
<td></td>
</tr>
 
      <tr>
        <td style=" padding:10px;width:200px; height:50px;" >Nombre: {0}~NombreCandidato|</td>
       <td style=" padding:10px;width:200px; height:50px;">Email: {0}~EmailCandidato|</td>
       <td style=" padding:10px;width:200px; height:50px;">Teléfono: {0}~TelefonoCandidato|</td>        
</tr>
            
</table>
  	</div>
<br>
  <div>
      
      <table style= "
    padding: 20px;
    border: 2px solid #9aad04;
    border-radius: 2px;
width:700px; height:100px">
 
<tr>
  <td style="padding:10px; border-bottom-style:solid; border-bottom-color:#9aad04;width:200px; height:50px;"><b>Entrevista Principal </b></td>
  <td></td>
<td></td>
</tr>
 
<tr>
  <td style="padding:10px;width:200px; height:50px;" >Entrevistador: {0}~NombreEntrevistador|</td>
  <td style=" padding:10px;width:200px; height:50px; " >Sala: {0}~Sala|</td>
  <td style=" padding:10px;width:200px; height:50px; " >Fecha: {0}~Fecha|</td>
 
</tr>
      
</table>
  	</div>
	<br>
	<div>
	{0}~MensajeSubEntrevistas|
</div>

<hr>



<br>


Un saludo.

</body>

</html>
', 4, 2018-10-02, 1, 'MeetingDatos' , 2, null);

SET IDENTITY_INSERT CorreoPlantilla OFF 

SET IDENTITY_INSERT CorreoPlantilla ON 
  
insert into CorreoPlantilla (PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro, Oficina)
values(74, '
Buenos días

Se les ha asignado una reunión.
Por favor, confirmen su asistencia.

Un saludo
', 4, 2018-10-02, 1, 'Meeting' , 2, null);
 
SET IDENTITY_INSERT CorreoPlantilla OFF
 
INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (74, 'Asunto', 4, 2018-10-02, 1, 'Meeting')
 
 
INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (74, 'imagenFirma', 4, 2018-10-02, 1, 'logo_everis.png')
 
 
INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (74, 'LogoCabecera', 4, 2018-10-02, 1, 'CabeceraPlantillaCorreo.png')
 
 
INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (74, 'Remitente', 4, 2018-10-02, 1, 'spain.alc.hhrr@everis.com')


/*Oficina OSCARESPLA*/

SET IDENTITY_INSERT CorreoPlantilla ON 

insert into CorreoPlantilla (PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro, Oficina)
values(75, '


<!DOCTYPE html>
<html>

<head>

	<title></title>

</head>

<body>

	<div>
      <p> Buenos días </p>  
      <p> A continuación se muestran los datos de la convocatoria de reunión.  </p> 
	</div>
  <hr> 
  	<div>
      
      <table style= "
    padding: 20px;
    border: 2px solid #9aad04;
    border-radius: 2px;
width:700px; height:100px;"
      >
      <tr>
  <td style="padding:10px; border-bottom-style:solid; border-bottom-color:#9aad04; width:200px; height:50px;"><b>Datos de Contacto</b></td>
  <td></td>
<td></td>
</tr>
 
      <tr>
        <td style=" padding:10px;width:200px; height:50px;" >Nombre: {0}~NombreCandidato|</td>
       <td style=" padding:10px;width:200px; height:50px;">Email: {0}~EmailCandidato|</td>
       <td style=" padding:10px;width:200px; height:50px;">Teléfono: {0}~TelefonoCandidato|</td>        
</tr>
            
</table>
  	</div>
<br>
  <div>
      
      <table style= "
    padding: 20px;
    border: 2px solid #9aad04;
    border-radius: 2px;
width:700px; height:100px">
 
<tr>
  <td style="padding:10px; border-bottom-style:solid; border-bottom-color:#9aad04;width:200px; height:50px;"><b>Entrevista Principal </b></td>
  <td></td>
<td></td>
</tr>
 
<tr>
  <td style="padding:10px;width:200px; height:50px;" >Entrevistador: {0}~NombreEntrevistador|</td>
  <td style=" padding:10px;width:200px; height:50px; " >Sala: {0}~Sala|</td>
  <td style=" padding:10px;width:200px; height:50px; " >Fecha: {0}~Fecha|</td>
 
</tr>
      
</table>
  	</div>
	<br>
	<div>
	{0}~MensajeSubEntrevistas|
</div>

<hr>



<br>


Un saludo.

</body>

</html>
', 4, 2018-10-02, 1, 'MeetingDatos' , 2, 1);

SET IDENTITY_INSERT CorreoPlantilla OFF 

SET IDENTITY_INSERT CorreoPlantilla ON 
  
insert into CorreoPlantilla (PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro, Oficina)
values(76, '
Buenos días

Se les ha asignado una reunión.
Por favor, confirmen su asistencia.

Un saludo
', 4, 2018-10-02, 1, 'Meeting' , 2, 1);
 
SET IDENTITY_INSERT CorreoPlantilla OFF
 
INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (76, 'Asunto', 4, 2018-10-02, 1, 'Meeting')
 
 
INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (76, 'imagenFirma', 4, 2018-10-02, 1, 'logo_everis.png')
 
 
INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (76, 'LogoCabecera', 4, 2018-10-02, 1, 'CabeceraPlantillaCorreo.png')
 
 
INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (76, 'Remitente', 4, 2018-10-02, 1, 'spain.alc.hhrr@everis.com')


/*Oficina San Juan*/

SET IDENTITY_INSERT CorreoPlantilla ON 

insert into CorreoPlantilla (PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro, Oficina)
values(77, '


<!DOCTYPE html>
<html>

<head>

	<title></title>

</head>

<body>

	<div>
      <p> Buenos días </p>  
      <p> A continuación se muestran los datos de la convocatoria de reunión.  </p> 
	</div>
  <hr> 
  	<div>
      
      <table style= "
    padding: 20px;
    border: 2px solid #9aad04;
    border-radius: 2px;
width:700px; height:100px;"
      >
      <tr>
  <td style="padding:10px; border-bottom-style:solid; border-bottom-color:#9aad04; width:200px; height:50px;"><b>Datos de Contacto</b></td>
  <td></td>
<td></td>
</tr>
 
      <tr>
        <td style=" padding:10px;width:200px; height:50px;" >Nombre: {0}~NombreCandidato|</td>
       <td style=" padding:10px;width:200px; height:50px;">Email: {0}~EmailCandidato|</td>
       <td style=" padding:10px;width:200px; height:50px;">Teléfono: {0}~TelefonoCandidato|</td>        
</tr>
            
</table>
  	</div>
<br>
  <div>
      
      <table style= "
    padding: 20px;
    border: 2px solid #9aad04;
    border-radius: 2px;
width:700px; height:100px">
 
<tr>
  <td style="padding:10px; border-bottom-style:solid; border-bottom-color:#9aad04;width:200px; height:50px;"><b>Entrevista Principal </b></td>
  <td></td>
<td></td>
</tr>
 
<tr>
  <td style="padding:10px;width:200px; height:50px;" >Entrevistador: {0}~NombreEntrevistador|</td>
  <td style=" padding:10px;width:200px; height:50px; " >Sala: {0}~Sala|</td>
  <td style=" padding:10px;width:200px; height:50px; " >Fecha: {0}~Fecha|</td>
 
</tr>
      
</table>
  	</div>
	<br>
	<div>
	{0}~MensajeSubEntrevistas|
</div>

<hr>



<br>


Un saludo.

</body>

</html>
', 4, 2018-10-02, 1, 'MeetingDatos' , 2, 2);

SET IDENTITY_INSERT CorreoPlantilla OFF 

SET IDENTITY_INSERT CorreoPlantilla ON 
  
insert into CorreoPlantilla (PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro, Oficina)
values(78, '
Buenos días

Se les ha asignado una reunión.
Por favor, confirmen su asistencia.

Un saludo
', 4, 2018-10-02, 1, 'Meeting' , 2, 2);
 
SET IDENTITY_INSERT CorreoPlantilla OFF
 
INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (78, 'Asunto', 4, 2018-10-02, 1, 'Meeting')
 
 
INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (78, 'imagenFirma', 4, 2018-10-02, 1, 'logo_everis.png')
 
 
INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (78, 'LogoCabecera', 4, 2018-10-02, 1, 'CabeceraPlantillaCorreo.png')
 
 
INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (78, 'Remitente', 4, 2018-10-02, 1, 'spain.alc.hhrr@everis.com')