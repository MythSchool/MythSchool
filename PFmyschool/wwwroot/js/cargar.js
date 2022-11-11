window.onload = function(){
// PANTALLA DE CARGA

    $('#onload').fadeOut();
    $('body').removeClass('hidden')



// AGREGA LA CANTIDAD DE PAGINITAS DE ESCUELA SEGUN EN NUMERO DEL FOR


    // for(i = 0;i < 12;i++){
    //     Agregar();
    //         }


}


function Agregar(){

var uni1 = "https://i.ytimg.com/vi/yeFpAgk9V_A/maxresdefault.jpg",uni2 = "https://www.uqroo.mx/imagen2021/demo_imagen/campus/playa.jpg",uni3 = "https://www.uqroo.mx/imagen2021/demo_imagen/campus/UqrooCancun_338.jpg",uni4 = "https://universidadriviera.edu.mx/img/uriviera.png",uni5 = "https://pbs.twimg.com/media/EDeWFetXkAUKQea.jpg",
prepa1 = "https://pr1.nicelocal.com.mx/9jEYoFbyr_JCO83pMP56tA/640x360,q85/4px-BW84_n2bwNWsh4g848PT4EpKp3bWnYUsgbUtKJ8ZgVELGs5D8VezJNnQe4_DxCWZig0hXHD57fj1hND2d-2Bpxp6qRkQamArvV7YoA2f2-IQ0q-AbKayfb3Q4anJzoAN33wVXRMbOPxNhcU3kpKm4EUFlhI0OUf3_94oQcfBqJwRyp-T46Z0rKtZWrhLM8xAewBuBg9Cwt599uNtf02SYCgYGKC71m6lmg8jAnFfuAwB1sQ2SCX55BgJK8JFVqkfzkO03L1Sbbp0xSvVYlTao0UoVMn9UM9BdDWdsao",
prepa2 = "https://pr0.nicelocal.com.mx/0Fj6WCUzp9qN0gzKOkr00w/640x427,q85/4px-BW84_n0QJGVPszge3NRBsKw-2VcOifrJIjPYFYkOtaCZxxXQ2XiEYSN7IidfK0X8oABwtp3M8PFBYzqCOvMw9x8G9WhRepIpxcLTXPhVeg5KWtJ3dQ";

var min = 1;
var max = 6;

var x = Math.floor(Math.random()*(max-min+1)+min);


switch(x){
    case 1: var src = uni1;
    break;
    case 2: var src = uni2;
    break;
    case 3: var src = uni3;
    break;
    case 4: var src = uni4;
    break;
    case 5: var src = prepa1;
    break;
    case 6: var src = prepa2;
    break;
    case 7: var src = uni5;
    break;
}

var Nombre = "Universidad Politecnica de QR",Ubicacion = "Benito Juarez",Nivel = "Superior",Sostenimiento = "Publica",Puntuacion = "3.5 / 5";
var linkto="Informacion.html";




// CREACION LAS PAGINITAS

  const cuadro = document.createElement("div");
  const link = document.createElement("a");
  const resul = document.createElement("div");
  const image = document.createElement("img");
  const cardbody = document.createElement("div");
  const lista = document.createElement("li");
  const lista2 = document.createElement("li");
  const lista3 = document.createElement("li");
  const lista4 = document.createElement("li");
  const lista5 = document.createElement("li");
  const titulo = document.createElement("h1");
  const titulo2 = document.createElement("h1");
  const titulo3 = document.createElement("h1");
  const titulo4 = document.createElement("h1");
  const titulo5 = document.createElement("h1");
  const text = document.createElement("p");
  const text2 = document.createElement("p");
  const text3 = document.createElement("p");
  const text4 = document.createElement("p");
  const text5 = document.createElement("p");

cuadro.appendChild(link);
cuadro.className  += "col";
link.appendChild(resul);
link.className  += "link";
link.href += linkto;
resul.appendChild(image);
resul.className  += "resul";
image.className += "card-img-top";
resul.appendChild(cardbody);
cardbody.className  += "cardboy";

cardbody.appendChild(lista);
cardbody.appendChild(lista2);
cardbody.appendChild(lista3);
cardbody.appendChild(lista4);
cardbody.appendChild(lista5);
lista.className += "cardlist";lista2.className += "cardlist";lista3.className += "cardlist";lista4.className += "cardlist";lista5.className += "cardlist";

titulo.className += "cardtitulo";
titulo2.className += "cardtitulo";
titulo3.className += "cardtitulo";
titulo4.className += "cardtitulo";
titulo5.className += "cardtitulo";

text.className += "texto";text2.className += "texto";text3.className += "texto";text4.className += "texto";text5.className += "texto";

titulo.textContent += "Nombre: ";text.textContent += " "+ Nombre;
titulo2.textContent += "Ubicacion: ";text2.textContent += " "+ Ubicacion;
titulo3.textContent += "Nivel: ";text3.textContent += " "+ Nivel;
titulo4.textContent += "Sostenimiento: ";text4.textContent += " "+ Sostenimiento;
titulo5.textContent += "Puntuacion media: ";text5.textContent += " "+ Puntuacion;

lista.appendChild(titulo);lista.appendChild(text);
lista2.appendChild(titulo2);lista2.appendChild(text2);
lista3.appendChild(titulo3);lista3.appendChild(text3);
lista4.appendChild(titulo4);lista4.appendChild(text4);
lista5.appendChild(titulo5);lista5.appendChild(text5);







image.src += src;

document.getElementById("contant").appendChild(cuadro);
console.log("Elemento agregado exitosamente")
}
