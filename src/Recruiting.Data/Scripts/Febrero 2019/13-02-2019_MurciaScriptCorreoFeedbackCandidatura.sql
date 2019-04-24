DECLARE @OutputTbl TABLE (ID INT);
DECLARE @PlantillaID INT;

INSERT INTO CorreoPlantilla OUTPUT INSERTED.PlantillaId INTO @OutputTbl(ID) VALUES ('<html>
<head>
    <title>Notificacion</title>
</head>
    <body lang="ES" style="" link="blue" vLink="purple">
        <div>
            <div style="padding-left:1cm;padding-right:1cm">
                <p>
                    <span><img width="794" height="160" src="{0}" /></span>~LogoCabecera|
                </p>
            
                
                <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Arial","sans-serif";FONT-SIZE: 11pt;">
                    Estimado/a {0},
                </div>~NombreEntrevistador|
                <br/>

                <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
                        Nos ponemos en contacto contigo para recordarte que tienes pendiente <b>finalizar el feedback de la {0}</b> del candidato {1}.
                <br/>~TipoEntrevista~Candidato|
                
                <br/>
                    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
                        Puedes acceder a la candidatura en el siguiente enlace:
                        <br><br>
                        <a href="{0}">{0}</a>

                </div>~UrlRecruiting| 
                <br/>
                
                <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
                        Gracias por tu tiempo.
                </div>
                <br/>
                
                <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
                        Atentamente,
                </div>
                <br/>
                
                
                <table style="border:none;">
                    <tr>
                        <td><span><img src="{0}"  /></span>~imagenFirma||</td>
                        <td>
                            <div style="TEXT-ALIGN:left;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 9pt;COLOR:rgb(54,95,145)">
                                <b>{0}</b>~LineaTituloPie|
                            </div>
                            <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(54,95,145)">
                                {0}~LineaDireccion|
                            </div>
                            <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(54,95,145)">
                                {0}~LineaProvincia|
                            </div>
                            <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(54,95,145)">
                                {0}~LineaTelefono|
                            </div>
                            <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 7pt;COLOR:rgb(0,10,236)">
                                <a href="mailto:{0}">{0}</a>~LineaEmail|
                                <br/>
                                <a href="http://{0}">{0}</a>~LineaWeb|
                            </div>
                        </td>
                    </tr>
                </table>
                <br/>
                
            </div>
        </div>

    </body>
</html>',4,NULL,GETDATE(),NULL,1,'FinalizarFeedbackEntrevista',96,NULL);

SET @PlantillaID = (SELECT ID FROM @OutputTbl);

INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'NombreEntrevistador',4,NULL,GETDATE(),NULL,1,NULL);
INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'CandidaturaId',4,NULL,GETDATE(),NULL,1,NULL);
INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'LineaTituloPie',4,NULL,GETDATE(),NULL,1,'Recruiting Murcia');
INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'LineaDireccion',4,NULL,GETDATE(),NULL,1,'Avenida Juan Carlos I, s/n, ');
INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'LineaProvincia',4,NULL,GETDATE(),NULL,1,'Edf. Torre de Cristal, pl.bj');
INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'LineaTelefono',4,NULL,GETDATE(),NULL,1,'Tel: +34 968 498 100 Ext: 110003');
INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'LineaEmail',4,NULL,GETDATE(),NULL,1,'murcia@everis.com');
INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'LineaWeb',4,NULL,GETDATE(),NULL,1,'www.everis.com');
INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'imagenFirma',4,NULL,GETDATE(),NULL,1,'logo_everis.png');
INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'LogoCabecera',4,NULL,GETDATE(),NULL,1,'CabeceraPlantillaCorreo.png');
INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'Remitente',4,NULL,GETDATE(),NULL,1,'murcia@everis.com');
INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'Asunto',4,NULL,GETDATE(),NULL,1,'Recruiting. Debe finalizar el feedback de candidatura.');