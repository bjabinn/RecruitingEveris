DECLARE @OutputTbl TABLE (ID INT);
DECLARE @PlantillaID INT;

INSERT INTO CorreoPlantilla OUTPUT INSERTED.PlantillaId INTO @OutputTbl(ID) VALUES ('<html>
<head>
    <title>Notificacion</title>
</head>
    <body lang="PT" style="" link="blue" vLink="purple">
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
                        Entramos em contato com você para lembrar que você ainda não <b>finalizou o feedback da {0}</b> do candidato {1}.
                <br/>~TipoEntrevista~Candidato|
                
                <br/>
                    <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
                        Você pode acessar o aplicativo no seguinte link:
                        <br><br>
                        <a href="{0}">{0}</a>

                </div>~UrlRecruiting| 
                <br/>
                
                <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
                        Obrigado pelo seu tempo.
                </div>
                <br/>
                
                <div style="TEXT-ALIGN: justify;FONT-FAMILY: "Calibri","sans-serif";FONT-SIZE: 11pt;">
                        Atenciosamente,
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
</html>',4,NULL,GETDATE(),NULL,1,'FinalizarFeedbackEntrevista',1171,NULL);

SET @PlantillaID = (SELECT ID FROM @OutputTbl);

INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'NombreEntrevistador',4,NULL,GETDATE(),NULL,1,NULL);
INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'CandidaturaId',4,NULL,GETDATE(),NULL,1,NULL);
INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'LineaTituloPie',4,NULL,GETDATE(),NULL,1,'Recruiting Lisboa');
INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'LineaDireccion',4,NULL,GETDATE(),NULL,1,'Praça Duque de Saldanha 1 - 10.º E/F');
INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'LineaProvincia',4,NULL,GETDATE(),NULL,1,'1000-007 Lisboa');
INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'LineaTelefono',4,NULL,GETDATE(),NULL,1,'Tel: +351 21 330 1020');
INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'LineaEmail',4,NULL,GETDATE(),NULL,1,'HPC.Lisboa.People@everis.com');
INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'LineaWeb',4,NULL,GETDATE(),NULL,1,'www.everis.com');
INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'imagenFirma',4,NULL,GETDATE(),NULL,1,'logo_everis.png');
INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'LogoCabecera',4,NULL,GETDATE(),NULL,1,'CabeceraPlantillaCorreo.png');
INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'Remitente',4,NULL,GETDATE(),NULL,1,'HPC.Lisboa.People@everis.com');
INSERT INTO CorreoPlantillaVariable VALUES (@PlantillaID,'Asunto',4,NULL,GETDATE(),NULL,1,'Recrutamento Você deve finalizar o feedback de candidatura.');