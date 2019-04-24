  update Candidatura
  set ModuloId = CONVERT(int, Modulo),
  Modulo = NULL
  where Modulo != '' or Modulo != NULL