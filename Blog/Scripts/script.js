function bienvenida(){
    alert("Bienvenido al Blog de Vélez!!!");
    var nombre = prompt("Ingresá tu nombre:");
    while(nombre == '' || nombre == undefined){
        nombre = prompt("Ingresá tu nombre:");
    }
    alert("Hola " + nombre + "!!!!!! :)");

    var respuesta = confirm("Sos de Vélez??");    
    if(respuesta){
        alert("Capo!");
    }else{
        alert("Andate de acá!!!");
        window.location.href = "http://www.google.com";
    }
    return nombre;
}

$(document).ready(function(){
    
    $('#ingresar').on('click', function(){
        var nombre = bienvenida();
        $('#nombreUsuario').text(nombre);
        $('#dropdownUsuario').show();
        $('#nuevoArticulo').show();
        $('#ingresar').hide();
    });

    $('#salir').on('click', function(){
        //$('body').css('background-color','red');
        alert('Chau!!!');
        window.location.href = "http://www.google.com";
    });

    $('#guardarArticulo').on('click', function(){
        //agarramos lo ingresa por el usuario en los inputs
        var titulo = $('#tituloArticulo').val();
        var imagen = $('#imagenArticulo').val();
        var texto = $('#textoArticulo').val();
        
        //creamos el elemento a agregar
        var $nuevoArticulo = $('<div class="col-md-6">' +
                '<img class="img-responsive" src="' + imagen + '" alt="Asad">' +
                '<h3>'+ titulo + '</h3>' +
                '<p>' + texto +'</p>'+
                '</div>');
        
        //agregamos este nuevo elemento al final del div de artículos
        $('#articulos').append($nuevoArticulo);

    //  <div class="col-md-6">
    //    <img class="img-responsive" src="images/asad.jpg" alt="Asad">
    //    <h3>El turquito Asad se fue a USA</h3>
    //    <p>Se lo llevó el Tata</p>        
    //</div>
    });

    //obtener clima de CABA
    $.ajax('http://api.openweathermap.org/data/2.5/weather?id=3433955&appid=b8c4ffcd65abed88f5ba857acde3cbd8',
    {
        dataType: 'jsonp',
        contentType: 'application/json',
        success: function(response){
            //alert('todo bien');
            var clima = response.weather[0];
            $('#climaActual').text(clima.main + ': ' + clima.description);
            $('#climaActual').append('<img src="http://openweathermap.org/img/w/' +clima.icon + '.png">');
        },
        error: function(request, errorType, errorMessage){
            alert('dio error');		
        }
    });


});
