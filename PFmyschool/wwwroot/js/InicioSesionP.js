var Usuario = 'admin',contraseña = '123'

function btnAceptar(){
var us = document.getElementById('user').value;
var con = document.getElementById('contra').value;

    if(Usuario == us ){
        document.getElementById('user').style.border= '1px solid #017bab'
        if(contraseña == con){

            window.open('Main.html', '_self');
        
        
          }else{
        document.getElementById('wrong').innerHTML = 'Contraseña incorrecta'
        document.getElementById('contra').style.borderColor = 'red'
        document.getElementById('wrong').style.visibility = 'visible'
          }
    }
    else{
        document.getElementById('user').style.borderColor = 'red'
        if(contraseña == con){


        }else{
            document.getElementById('contra').style.borderColor = 'red'
            document.getElementById('wrong').style.visibility = 'visible'
        }

    }



}