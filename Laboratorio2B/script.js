function agregar(){
    var lista = document.getElementById("lista");
    var nuevoElemento = document.createElement("li");
    // nombre Elemento# automaticamente asignado e incrementa
    nuevoElemento.textContent = "Elemento" + (lista.childElementCount+1);

    lista.appendChild(nuevoElemento);
}

function borrar(){
    var lista = document.getElementById("lista");
    var ultimoElemento = lista.lastChild;
    // se elimina el ultimo elemento
    lista.removeChild(ultimoElemento);
}

function cambiarFondo(){
    // si esta blanco, cambiar de color, si esta de ese color, cambiar a blanco
    var body = document.body;
    if(body.style.backgroundColor == "white"){
        body.style.backgroundColor = "lightblue";
    } else {
        body.style.backgroundColor = "white";
    }
}