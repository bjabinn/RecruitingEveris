set identity_insert centro on

insert into Centro (CentroId, Nombre, Activo, CuentaTokenId)
values(1307, 'Alicante Solutions', 1, null)

set identity_insert centro off

set identity_insert MonedasDeCentro on

insert into MonedasDeCentro (MonedasDeCentroId, Centro, Descripción, Activo)
values (11, 1307, 'EUR', 1)

set identity_insert MonedasDeCentro off
