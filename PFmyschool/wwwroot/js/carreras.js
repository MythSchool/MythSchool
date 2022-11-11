function remove(elem){
    elem.parentNode.removeChild(elem);
  }
  


function btnAgregar(){


var car = document.getElementById('nomcar').value
var descar = document.getElementById('descar').value


if(car === '' && descar === ''){
   
    alert('Llene todos lo campos')
   

}
else{

    if(descar === ''){
        alert('Llene todos lo campos')
    }
    else{
        const cuadro = document.createElement("div");
        const carrera = document.createElement("p");
        cuadro.setAttribute("onclick","remove(this)");
        cuadro.id += "i";
        carrera.className += "bodycar";
        carrera.textContent += "-" + " " + car;
        cuadro.appendChild(carrera);
        
 
    
    document.getElementById('carrerasag').appendChild(cuadro);
    }

}
































//     const cuadro = document.createElement("div");
//     const link = document.createElement("a");
//     const resul = document.createElement("div");
//     const image = document.createElement("img");
//     const cardbody = document.createElement("div");
//     const lista = document.createElement("li");
//     const lista2 = document.createElement("li");
//     const lista3 = document.createElement("li");
//     const lista4 = document.createElement("li");
//     const lista5 = document.createElement("li");
//     const titulo = document.createElement("h1");
//     const titulo2 = document.createElement("h1");
//     const titulo3 = document.createElement("h1");
//     const titulo4 = document.createElement("h1");
//     const titulo5 = document.createElement("h1");
//     const text = document.createElement("p");
//     const text2 = document.createElement("p");
//     const text3 = document.createElement("p");
//     const text4 = document.createElement("p");
//     const text5 = document.createElement("p");
  
//   cuadro.appendChild(link);
//   cuadro.className  += "col";
//   link.appendChild(resul);
//   link.className  += "link";
//   link.href += linkto;
//   resul.appendChild(image);
//   resul.className  += "resul";
//   image.className += "card-img-top";
//   resul.appendChild(cardbody);
//   cardbody.className  += "cardboy";
  
//   cardbody.appendChild(lista);
//   cardbody.appendChild(lista2);
//   cardbody.appendChild(lista3);
//   cardbody.appendChild(lista4);
//   cardbody.appendChild(lista5);
//   lista.className += "cardlist";lista2.className += "cardlist";lista3.className += "cardlist";lista4.className += "cardlist";lista5.className += "cardlist";
  
//   titulo.className += "cardtitulo";
//   titulo2.className += "cardtitulo";
//   titulo3.className += "cardtitulo";
//   titulo4.className += "cardtitulo";
//   titulo5.className += "cardtitulo";
  
//   text.className += "texto";text2.className += "texto";text3.className += "texto";text4.className += "texto";text5.className += "texto";
  
//   titulo.textContent += "Nombre: ";text.textContent += " "+ Nombre;
//   titulo2.textContent += "Ubicacion: ";text2.textContent += " "+ Ubicacion;
//   titulo3.textContent += "Nivel: ";text3.textContent += " "+ Nivel;
//   titulo4.textContent += "Modalidad: ";text4.textContent += " "+ Modalidad;
//   titulo5.textContent += "Puntuacion media: ";text5.textContent += " "+ Puntuacion;
  
//   lista.appendChild(titulo);lista.appendChild(text);
//   lista2.appendChild(titulo2);lista2.appendChild(text2);
//   lista3.appendChild(titulo3);lista3.appendChild(text3);
//   lista4.appendChild(titulo4);lista4.appendChild(text4);
//   lista5.appendChild(titulo5);lista5.appendChild(text5);
  
  
  
  
  
  
  
//   image.src += src;
  
//   document.getElementById("carrerasag").appendChild(cuadro);
//   console.log("Elemento agregado exitosamente")
}