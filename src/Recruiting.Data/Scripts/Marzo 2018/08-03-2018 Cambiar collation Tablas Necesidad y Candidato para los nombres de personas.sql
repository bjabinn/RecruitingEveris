ALTER TABLE Candidato ALTER COLUMN Nombre  
            varchar(250)COLLATE Modern_Spanish_CI_AI NOT NULL;

ALTER TABLE Candidato ALTER COLUMN Apellidos  
            varchar(250)COLLATE Modern_Spanish_CI_AI NOT NULL;

ALTER TABLE Necesidad ALTER COLUMN PersonaAsignada  
            varchar(250)COLLATE Modern_Spanish_CI_AI;