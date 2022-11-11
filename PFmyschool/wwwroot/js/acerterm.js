//SCRIPT OBTENER EL ALTO Y ANCHO DE LA PAGINA WEB


const resize_ob = new ResizeObserver(function(entries) {
	let rect = entries[0].contentRect;


	let width = rect.width;
	let height = rect.height;

	console.log('Current Width : ' + width);
  console.log('Current Height : ' + height);
  
  
  if(width < 1601){
document.getElementById('logo').style.width = "190px";
}else{
    document.getElementById('logo').style.width = "250px";
}

if(width < 1401){
document.getElementById('logo').style.width = "130px";
}

});

resize_ob.observe(document.querySelector("#demo-textarea"));

