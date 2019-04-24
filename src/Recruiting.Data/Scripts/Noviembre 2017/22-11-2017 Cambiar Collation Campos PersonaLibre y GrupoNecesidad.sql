ALTER TABLE PersonaLibre ALTER COLUMN Nombre  
            varchar(30)COLLATE Modern_Spanish_CI_AI NOT NULL;

ALTER TABLE PersonaLibre ALTER COLUMN Apellidos  
            varchar(50)COLLATE Modern_Spanish_CI_AI NOT NULL;

ALTER TABLE GrupoNecesidad ALTER COLUMN Nombre  
            varchar(250)COLLATE Modern_Spanish_CI_AI;