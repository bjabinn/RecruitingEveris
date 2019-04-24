/*Cambiar la fecha de int a datetime al campo AniosExperiencia*/	
	declare @aniosExp_candidato int
	declare @candidatura_id int 
	declare @anio int
	declare @anio2 datetime		

	declare cursor_actualizartablaexp cursor for
	  
	  select  [CandidaturaId],[AnioExperienciaCandidato]
	  from  [Candidatura]

	  open cursor_actualizartablaexp
	  fetch next from cursor_actualizartablaexp into
	  @candidatura_id, @aniosExp_candidato
	  
	  while @@FETCH_STATUS = 0 
		begin

		if @aniosExp_candidato is not null
		begin
			set @anio = 2019 - @aniosExp_candidato;
	
			set @anio = (SELECT CONCAT ( @anio, '0101'))

			set @anio2 = (select CONVERT (datetime,convert(char(8),@anio)))

			Update [Candidatura]
			set [AniosExperiencia] = @anio2
			where  CandidaturaId = @candidatura_id
			 
		end
										
		fetch next from cursor_actualizartablaexp into
		@candidatura_id, @aniosExp_candidato
	  
	  end

	close cursor_actualizartablaexp
  deallocate cursor_actualizartablaexp
