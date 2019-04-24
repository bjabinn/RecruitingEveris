update CorreoPlantillaVariable
set ValorDefecto = 'Spain.alc.hhrr@everis.com'
where PlantillaId in (Select PlantillaId from CorreoPlantilla With (nolock) where Centro = 2)
and NombreVariable = 'Remitente'