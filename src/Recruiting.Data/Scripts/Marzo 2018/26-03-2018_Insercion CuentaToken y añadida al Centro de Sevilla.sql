SET IDENTITY_INSERT CUENTATOKEN ON

insert into Cuentatoken (CuentaTokenId, Email, Token, FechaCreacion, FechaExpiracion, FechaCreacionToken, FechaExpiracionToken, Activo)
values (1, 'dgarcper@everis.com', '', GETDATE(), null, null, null, 1)


SET IDENTITY_INSERT CUENTATOKEN OFF

update Centro 
set CuentaTokenId = 1
where CentroId = 98