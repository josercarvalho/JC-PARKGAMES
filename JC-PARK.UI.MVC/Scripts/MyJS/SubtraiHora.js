/**
* Retona a diferença entre duas horas.
* Exemplo: 14:35 a 17:21 = 02:46
* Adaptada de http://stackoverflow.com/questions/2053057/doing-time-subtraction-with-jquery
*/
function diferencaHoras(horaInicial, horaFinal) {
 
    // Tratamento se a hora inicial é menor que a final 
    if( ! isHoraInicialMenorHoraFinal(horaInicial, horaFinal) ){
        aux = horaFinal;
        horaFinal = horaInicial;
        horaInicial = aux;
    }
 
    hIni = horaInicial.split(':');
    hFim = horaFinal.split(':');
 
    horasTotal = parseInt(hFim[0], 10) - parseInt(hIni[0], 10);
    minutosTotal = parseInt(hFim[1], 10) - parseInt(hIni[1], 10);
     
    if(minutosTotal < 0){
        minutosTotal += 60;
        horasTotal -= 1;
    }
     
    //horaFinal = completaZeroEsquerda(horasTotal) + ":" + completaZeroEsquerda(minutosTotal);
    horaFinal = horasTotal + ":" + minutosTotal;
    return horaFinal;
}

/**
 * Verifica se a hora inicial é menor que a final.
 */
function isHoraInicialMenorHoraFinal(horaInicial, horaFinal){
    horaIni = horaInicial.split(':');
    horaFim = horaFinal.split(':');
 
    // Verifica as horas. Se forem diferentes, é só ver se a inicial 
    // é menor que a final.
    hIni = parseInt(horaIni[0], 10);
    hFim = parseInt(horaFim[0], 10);
    if(hIni != hFim)
        return hIni + ":" + hFim;
     
    // Se as horas são iguais, verifica os minutos então.
    mIni = parseInt(horaIni[1], 10);
    mFim = parseInt(horaFim[1], 10);
    if(mIni != mFim)
        return mIni + ":" + mFim;
}