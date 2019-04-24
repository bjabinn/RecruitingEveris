﻿
namespace Recruiting.Application.Candidaturas.Enums
{
    public enum TipoDecisionEnum
    {
        SUPERA_FILTRADO = 1,
        NO_SUPERA_FILTRADO = 2,
        SIN_DECISION_AGENDAR1 = 3,
        SIN_DECISION_AGENDAR2 = 4,
        SIN_DECISION_AGENDARCO = 5,
        SUPERA_PRIMERA_ENTREVISTA = 6,
        NO_SUPERA_PRIMERA_ENTREVISTA = 7,
        SUPERA_SEGUNDA_ENTREVISTA = 8,
        NO_SUPERA_SEGUNDA_ENTREVISTA = 10,
        SIN_DECISION_CO = 11,
        ACEPTA_CARTA_OFERTA = 12,
        NO_ACEPTA_CARTA_OFERTA = 13, 
        SIN_DECISION_INICIO = 14,
        SIN_DECISION_REAGENDAR1 = 15,
        SIN_DECISION_REAGENDAR2 = 16,
        SIN_DECISION_CARTAOFERTA = 17,
        PAUSAR_FILTRADO_CV_BBDD = 20,
        PAUSAR_PRIMERA_ENTREVISTA = 21,
        PAUSAR_COMPLETAR_PRIMERA_ENTREVISTA = 22,
        PAUSAR_SEGUNDA_ENTREVISTA = 23,
        PAUSAR_COMPLETAR_SEGUNDA_ENTREVISTA = 24,
        REANUDAR_FILTRADO_CV_BBDD = 25,
        REANUDAR_COMPLETAR_PRIMERA_ENTREVISTA = 27,
        REANUDAR_COMPLETAR_SEGUNDA_ENTREVISTA = 28,
        SIN_DECISION_IRAGENDAR1 = 29,
        SIN_DECISION_IRAGENDAR2 = 30,
        SIN_DECISION_IRCARTAOFERTA = 31,
        PAUSAR_PRIMERA_ENTREVISTA_UNIFICADO = 32,
        REANUDAR_PRIMERA_ENTREVISTA_UNIFICADO = 33,
        PAUSAR_SEGUNDA_ENTREVISTA_UNIFICADO = 34,
        REANUDAR_SEGUNDA_ENTREVISTA_UNIFICADO = 35,
        PAUSAR_EN_FILTRADO_TELEFONICO = 40,
        REANUDAR_EN_FILTRADO_TELEFONICO = 41,
        SIN_DECIDIR_PRIMERA_ENTREVISTA = 42,
        SIN_DECIDIR_SEGUNDA_ENTREVISTA = 43

    }
}