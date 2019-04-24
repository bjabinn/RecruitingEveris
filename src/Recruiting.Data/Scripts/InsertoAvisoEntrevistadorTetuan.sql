SET IDENTITY_INSERT CorreoPlantilla ON

INSERT INTO CorreoPlantilla(PlantillaId, TextoPlantilla, UsuarioCreacionId, FechaCreacion, Activo, NombrePlantilla, Centro) 
VALUES (28, '<html>
<head>
    <title>Notificacion</title>
</head>
     <body lang="ES" style="" link="blue" vLink="purple">
         <div>
             <div style="padding-left:1cm;padding-right:1cm">
                 <p>
                     <span><img width="794" height="160" src="{0}" /></span>~LogoCabecera|
                 </p>


                 <div style="TEXT-ALIGN: justify;FONT-FAMILY: " Arial","sans-serif";FONT-SIZE 11pt;">
                     Bonjour,
                 </div>
                 <br />



                 <div style="TEXT-ALIGN: justify;FONT-FAMILY: " Calibri","sans-serif";FONT-SIZE 11pt;">
                     Nous vous rappelons que vous avez un <b>{0}</b> avec le candidat <b>{1}</b>
                     le <b>{2}</b>.

                 </div>~TipoEntrevista~NombreCandidato~FechaEntrevista
                 <br />

                 <div style="TEXT-ALIGN: justify;FONT-FAMILY: " Calibri","sans-serif";FONT-SIZE 11pt;">
                     Le détail et les informations du candidat <b>Ref: {0}</b> se trouvent dans l’outil de
                     recrutement au niveau du lien suivant: {1}{2}
                 </div>~CandidaturaId~UrlRecruiting~CandidaturaId|
                 <br />

                 <div style="TEXT-ALIGN: justify;FONT-FAMILY: " Calibri","sans-serif";FONT-SIZE 11pt;">
                     Merci de mettre à jour l’outil après l’entretien ainsi que la prochaine étape du
                     processus de recrutement.
                 </div>
                 <br />

                 <div style="TEXT-ALIGN: justify;FONT-FAMILY: " Calibri","sans-serif";FONT-SIZE 11pt;">
                     Bien cordialement.
                 </div>
                 <br />


                 <table style="border:none;">
                     <tr>
                         <td><span><img src="{0}" /></span>~imagenFirma||</td>
                         <td>
                             <div style="TEXT-ALIGN:left;FONT-FAMILY: " Calibri","sans-serif";FONT-SIZE 9pt;COLOR:rgb(54,95,145)">
                                 <b>{0}</b>~LineaTituloPie|
                             </div>
                             <div style="TEXT-ALIGN: justify;FONT-FAMILY: " Calibri","sans-serif";FONT-SIZE 7pt;COLOR:rgb(54,95,145)">
                                 {0}~LineaDireccion|
                             </div>
                             <div style="TEXT-ALIGN: justify;FONT-FAMILY: " Calibri","sans-serif";FONT-SIZE 7pt;COLOR:rgb(54,95,145)">
                                 {0}~LineaProvincia|
                             </div>
                             <div style="TEXT-ALIGN: justify;FONT-FAMILY: " Calibri","sans-serif";FONT-SIZE 7pt;COLOR:rgb(54,95,145)">
                                 {0}~LineaTelefono|
                             </div>
                             <div style="TEXT-ALIGN: justify;FONT-FAMILY: " Calibri","sans-serif";FONT-SIZE 7pt;COLOR:rgb(0,10,236)">
                                 <a href="mailto:{0}">{0}</a>~LineaEmail|
                                 <br />
                                 <a href="http://{0}">{0}</a>~LineaWeb|
                             </div>
                         </td>
                     </tr>
                 </table>
                 <br />

             </div>
         </div>

     </body>
</html>
', 4, 2017-06-06, 1, 'AvisoEntrevistaEntrevistador', 1170)

SET IDENTITY_INSERT CorreoPlantilla OFF



INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (28, 'Asunto', 4, 2017-06-06, 1, 'Recruiting Everis. entrevue prévue avis')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (28, 'FechaEntrevista', 4, 2017-06-06, 1, NULL)

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (28, 'imagenFirma', 4, 2017-06-06, 1, 'logo_everis.png')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (28, 'LineaDireccion', 4, 2017-06-06, 1, 'TetouanShore Park-Shore 3
Route de Cabo Negro')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (28, 'LineaEmail', 4, 2017-06-06, 1, 'Recruiting.Centers.Morocco@everis.com')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (28, 'LineaProvincia', 4, 2017-06-06, 1, '93000 Martil, Morocco')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (28, 'LineaTelefono', 4, 2017-06-06, 1, 'Tlf: +212 531 06 2990')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (28, 'LineaTituloPie', 4, 2017-06-06, 1, 'Everis centers Morocco ')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (28, 'LineaWeb', 4, 2017-06-06, 1, 'www.everis.com')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (28, 'LogoCabecera', 4, 2017-06-06, 1, 'CabeceraPlantillaCorreo.png')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (28, 'NombreCandidato', 4, 2017-06-06, 1, NULL)

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (28, 'NombreEntrevistador', 4, 2017-06-06, 1, NULL)

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (28, 'Remitente', 4, 2017-06-06, 1, 'Recruiting.Centers.Morocco@everis.com')

INSERT INTO CorreoPlantillaVariable(PlantillaId, NombreVariable, UsuarioCreacionId, FechaCreacion, Activo, ValorDefecto) 
VALUES (28, 'TipoEntrevista', 4, 2017-06-06, 1, NULL)