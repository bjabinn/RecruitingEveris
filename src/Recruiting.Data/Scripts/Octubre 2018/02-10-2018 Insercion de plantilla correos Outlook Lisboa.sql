SET IDENTITY_INSERT CorreoPlantilla ON 

insert into CorreoPlantilla (PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro, Oficina)
values(83, '


<!DOCTYPE html>
<html>

<head>

	<title></title>

</head>

<body>

	<div>
      <p> Bom dia, </p>  
      <p> Os dados para a solicita��o de reuni�o s�o mostrados abaixo.  </p> 
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
  <td style="padding:10px; border-bottom-style:solid; border-bottom-color:#9aad04; width:200px; height:50px;"><b>Dados de Contacto</b></td>
  <td></td>
<td></td>
</tr>
 
      <tr>
        <td style=" padding:10px;width:200px; height:50px;" >Nome: {0}~NombreCandidato|</td>
       <td style=" padding:10px;width:200px; height:50px;">Email: {0}~EmailCandidato|</td>
       <td style=" padding:10px;width:200px; height:50px;">Telefone: {0}~TelefonoCandidato|</td>        
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
  <td style=" padding:10px;width:200px; height:50px; " >Data: {0}~Fecha|</td>
 
</tr>
      
</table>
  	</div>
	<br>
	<div>
	{0}~MensajeSubEntrevistas|
</div>

<hr>



<br>


Uma sauda��o.

</body>

</html>
', 4, 2018-10-02, 1, 'MeetingDatos' , 1171, null);

SET IDENTITY_INSERT CorreoPlantilla OFF 

SET IDENTITY_INSERT CorreoPlantilla ON 
  
insert into CorreoPlantilla (PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro, Oficina)
values(84, '
Bom dia

Eles foram nomeados uma reuni�o.
Por favor, confirme sua presen�a.

Uma sauda��o.

', 4, 2018-10-02, 1, 'Meeting' , 1171, null);
 
SET IDENTITY_INSERT CorreoPlantilla OFF
 
INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (84, 'Asunto', 4, 2018-10-02, 1, 'Meeting')
 
 
INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (84, 'imagenFirma', 4, 2018-10-02, 1, 'logo_everis.png')
 
 
INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (84, 'LogoCabecera', 4, 2018-10-02, 1, 'CabeceraPlantillaCorreo.png')
 
 
INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (84, 'Remitente', 4, 2018-10-02, 1, 'Spain.Personal.Candidate@everis.com')

