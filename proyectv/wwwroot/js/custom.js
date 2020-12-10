$(function () {
    // Sidebar toggle behavior
    $('#sidebarCollapse').on('click', function () {
        $('#sidebar, #content').toggleClass('active');
    });
    
});

$(document).ready(function () {
    $("#inputQuantity").on('paste', function (e) {
        e.preventDefault();
    })

    $("#inputQuantity").on('copy', function (e) {
        e.preventDefault();
    })
    $("#inputQuantity").on('cut', function (e) {
        e.preventDefault();
    })
})

let selectedIMG = function (e) {
    let id = document.getElementById("selectfile");
    let botonSelectivo = document.getElementById("btnselectFile");
    let imgActual = document.getElementById("imgSelectFileDefault");
    if (id.files.length == 0) {
        id.value = '';
        botonSelectivo.classList.remove('btn-secondary');
        botonSelectivo.classList.add('btn-danger');
        botonSelectivo.text = "Archivo no admitido";
        imgActual.src = "https://i.ibb.co/XZjpcfZ/img-add-element.png";
        imgActual.addEventListener("click", clickAIMG, false);
        imgActual.style.cursor = "pointer";
    } else
    {
        if (id.files[0].size / 1000 <= 10000) {
            if (id.files[0].type == "") {
                id.value = '';
                botonSelectivo.classList.remove('btn-secondary');
                botonSelectivo.classList.add('btn-danger');
                botonSelectivo.text = "Archivo no admitido";
                imgActual.src = "https://i.ibb.co/XZjpcfZ/img-add-element.png";
                imgActual.addEventListener("click", clickAIMG, false);
                imgActual.style.cursor = "pointer";

            } else if (id.files[0].type == "image/png") {

                console.log("Prueba pasada :)");
                let reader = new FileReader();

                // Leemos el archivo subido y se lo pasamos a nuestro fileReader
                reader.readAsDataURL(id.files[0]);

                // Le decimos que cuando este listo ejecute el código interno
                reader.onload = function () {
                    let imgActual = document.getElementById("imgSelectFileDefault");
                    imgActual.style.display = "none";
                    let preview = document.getElementById('mostrarImagenPrevia'),
                        image = document.createElement('img');

                    botonSelectivo.classList.remove('btn-danger');
                    botonSelectivo.classList.add('btn-primary');
                    botonSelectivo.text = "Elegir otra imagen";

                    image.src = reader.result;
                    image.width = 300;
                    image.height = 300;
                    image.style.maxHeight = "300px";
                    image.style.minHeight = "300px";
                    image.style.maxWidth = "300px";
                    image.style.minWidth = "300px";
                    image.classList.add('card-img-left', 'img-thumbnail');
                    image.id = "imgSelectFileDefault";

                    preview.innerHTML = '';
                    preview.append(image);
                };
            } else if (id.files[0].type == "image/jpeg") {

                let reader = new FileReader();

                // Leemos el archivo subido y se lo pasamos a nuestro fileReader
                reader.readAsDataURL(id.files[0]);

                // Le decimos que cuando este listo ejecute el código interno
                reader.onload = function () {
                    let imgActual = document.getElementById("imgSelectFileDefault");
                    imgActual.style.display = "none";
                    let preview = document.getElementById('mostrarImagenPrevia'),
                        image = document.createElement('img');

                    botonSelectivo.classList.remove('btn-danger');
                    botonSelectivo.classList.add('btn-primary');
                    botonSelectivo.text = "Elegir otra imagen";

                    image.src = reader.result;
                    image.width = 300;
                    image.height = 300;
                    image.style.maxHeight = "300px";
                    image.style.minHeight = "300px";
                    image.style.maxWidth = "300px";
                    image.style.minWidth = "300px";
                    image.classList.add('card-img-left', 'img-thumbnail');
                    image.id = "imgSelectFileDefault";

                    preview.innerHTML = '';
                    preview.append(image);
                };
            } else {
                let imgActual = document.getElementById("imgSelectFileDefault");
                id.value = '';
                botonSelectivo.classList.remove('btn-secondary');
                botonSelectivo.classList.add('btn-danger');
                botonSelectivo.text = "Archivo no admitido";
                imgActual.src = "https://i.ibb.co/XZjpcfZ/img-add-element.png";
                imgActual.addEventListener("click", clickAIMG, false);
                imgActual.style.cursor = "pointer";

            }
        } else {
            let imgActual = document.getElementById("imgSelectFileDefault");
            id.value = '';
            botonSelectivo.classList.remove('btn-secondary');
            botonSelectivo.classList.add('btn-danger');
            botonSelectivo.text = "Archivo no admitido";
            imgActual.src = "https://i.ibb.co/XZjpcfZ/img-add-element.png";
            imgActual.addEventListener("click", clickAIMG, false);
            imgActual.style.cursor = "pointer";
        }
    }

    
}

function clickAIMG() {
    $(document.getElementById("selectfile")).click();
}

function clickAIMG2() {
    $(document.getElementById("selectfile2")).click();
}

$(function () {
    $("#formSelectFile").on("submit", function (e) {
        

        /*Con el id del input tipo file le indicas que lea la longitud o cantidad de 
          archivos que se seleccionaron*/
        let vidFileLength = $("#selectfile")[0].files.length;

        /*Aquí validas si no han seleccionado archivos mandas una alerta y se detiene el 
         script*/
        if (vidFileLength === 0) {
            e.preventDefault();
            alert("Pongale una imagen al producto :v");
            return false;
        } else {
        let f = $(this);
        let formData = new FormData(document.getElementById("formSelectFile"));
        }


    });

});

let estado_de_pulso_EP = 0;

let selectedIMG2 = function (e) {
    let id = document.getElementById("selectfile2");
    let botonSelectivo = document.getElementById("btnselectFile2");
    let imgActual = document.getElementById("imgSelectFileDefault2");
    if (id.files.length == 0) {
        id.value = '';
        botonSelectivo.classList.remove('btn-secondary');
        botonSelectivo.classList.add('btn-danger');
        botonSelectivo.text = "Archivo no admitido";
        imgActual.src = "https://i.ibb.co/XZjpcfZ/img-add-element.png";
        imgActual.addEventListener("click", clickAIMG, false);
        imgActual.style.cursor = "pointer";
    } else {
        if (id.files[0].size / 1000 <= 10000) {
            if (id.files[0].type == "") {
                id.value = '';
                botonSelectivo.classList.remove('btn-secondary');
                botonSelectivo.classList.add('btn-danger');
                botonSelectivo.text = "Archivo no admitido";
                imgActual.src = "https://i.ibb.co/XZjpcfZ/img-add-element.png";
                imgActual.addEventListener("click", clickAIMG, false);
                imgActual.style.cursor = "pointer";

            } else if (id.files[0].type == "image/png") {

                console.log("Prueba pasada :)");
                let reader = new FileReader();

                // Leemos el archivo subido y se lo pasamos a nuestro fileReader
                reader.readAsDataURL(id.files[0]);

                // Le decimos que cuando este listo ejecute el código interno
                reader.onload = function () {
                    let imgActual = document.getElementById("imgSelectFileDefault2");
                    imgActual.style.display = "none";
                    let preview = document.getElementById('mostrarImagenPrevia2'),
                        image = document.createElement('img');

                    botonSelectivo.classList.remove('btn-danger');
                    botonSelectivo.classList.add('btn-primary');
                    botonSelectivo.text = "Elegir otra imagen";

                    image.src = reader.result;
                    image.width = 330;
                    image.height = 330;
                    image.style.maxHeight = "300px";
                    image.style.minHeight = "300px";
                    image.classList.add('card-img-left', 'img-thumbnail');
                    image.id = "imgSelectFileDefault2";

                    preview.innerHTML = '';
                    preview.append(image);
                };
            } else if (id.files[0].type == "image/jpeg") {

                let reader = new FileReader();

                // Leemos el archivo subido y se lo pasamos a nuestro fileReader
                reader.readAsDataURL(id.files[0]);

                // Le decimos que cuando este listo ejecute el código interno
                reader.onload = function () {
                    let imgActual = document.getElementById("imgSelectFileDefault2");
                    imgActual.style.display = "none";
                    let preview = document.getElementById('mostrarImagenPrevia2'),
                        image = document.createElement('img');

                    botonSelectivo.classList.remove('btn-danger');
                    botonSelectivo.classList.add('btn-primary');
                    botonSelectivo.text = "Elegir otra imagen";

                    image.src = reader.result;
                    image.style.maxHeight = "300px";
                    image.height = 330;
                    image.classList.add('card-img-left', 'img-thumbnail');
                    image.id = "imgSelectFileDefault2";

                    preview.innerHTML = '';
                    preview.append(image);
                };
            } else {
                let imgActual = document.getElementById("imgSelectFileDefault2");
                id.value = '';
                botonSelectivo.classList.remove('btn-secondary');
                botonSelectivo.classList.add('btn-danger');
                botonSelectivo.text = "Archivo no admitido";
                imgActual.src = "https://i.ibb.co/XZjpcfZ/img-add-element.png";
                imgActual.addEventListener("click", clickAIMG, false);
                imgActual.style.cursor = "pointer";

            }
        } else {
            let imgActual = document.getElementById("imgSelectFileDefault2");
            id.value = '';
            botonSelectivo.classList.remove('btn-secondary');
            botonSelectivo.classList.add('btn-danger');
            botonSelectivo.text = "Archivo no admitido";
            imgActual.src = "https://i.ibb.co/XZjpcfZ/img-add-element.png";
            imgActual.addEventListener("click", clickAIMG, false);
            imgActual.style.cursor = "pointer";
        }
    }
}

$(function () {
    $("#formSelectFile2").on("submit", function (e) {


        /*Con el id del input tipo file le indicas que lea la longitud o cantidad de 
          archivos que se seleccionaron*/
        let vidFileLength = $("#selectfile2")[0].files.length;

        /*Aquí validas si no han seleccionado archivos mandas una alerta y se detiene el 
         script*/
        if (vidFileLength === 0 && estado_de_pulso_EP == 1) {
            e.preventDefault();
            alert("Pongale una imagen al producto :v");
            return false;
        } else {
            let f = $(this);
            let formData = new FormData(document.getElementById("formSelectFile2"));
        }


    });

});

let selectedIMG3 = function (e) {
    let id = document.getElementById("selectfile3");
    let botonSelectivo = document.getElementById("btnselectFile3");
    let imgActual = document.getElementById("imgSelectFileDefault3");
    if (id.files.length == 0) {
        id.value = '';
        botonSelectivo.classList.remove('btn-secondary');
        botonSelectivo.classList.add('btn-danger');
        botonSelectivo.text = "Archivo no admitido";
        imgActual.src = "/img/profilesimg/targetblank.png";
        imgActual.addEventListener("click", clickAIMG, false);
        imgActual.style.cursor = "pointer";
    } else {
        if (id.files[0].size / 1000 <= 10000) {
            if (id.files[0].type == "") {
                id.value = '';
                botonSelectivo.classList.remove('btn-secondary');
                botonSelectivo.classList.add('btn-danger');
                botonSelectivo.text = "Archivo no admitido";
                imgActual.src = "/img/profilesimg/targetblank.png";
                imgActual.addEventListener("click", clickAIMG, false);
                imgActual.style.cursor = "pointer";

            } else if (id.files[0].type == "image/png") {

                console.log("Prueba pasada :)");
                let reader = new FileReader();

                // Leemos el archivo subido y se lo pasamos a nuestro fileReader
                reader.readAsDataURL(id.files[0]);

                // Le decimos que cuando este listo ejecute el código interno
                reader.onload = function () {
                    let imgActual = document.getElementById("imgSelectFileDefault3");
                    imgActual.style.display = "none";
                    let preview = document.getElementById('mostrarImagenPrevia3'),
                        image = document.createElement('img');

                    botonSelectivo.classList.remove('btn-danger');
                    botonSelectivo.classList.add('btn-primary');
                    botonSelectivo.text = "Elegir otra imagen";

                    image.src = reader.result;
                    image.width = 270;
                    image.height = 270;
                    image.style.maxHeight = "270px";
                    image.style.minHeight = "270px";
                    image.style.maxWidth = "270px";
                    image.style.minWidth = "270px";
                    image.classList.add('card-img-left', 'img-thumbnail', 'rounded-circle');
                    image.id = "imgSelectFileDefault3";

                    preview.innerHTML = '';
                    preview.append(image);
                };
            } else if (id.files[0].type == "image/jpeg") {

                let reader = new FileReader();

                // Leemos el archivo subido y se lo pasamos a nuestro fileReader
                reader.readAsDataURL(id.files[0]);

                // Le decimos que cuando este listo ejecute el código interno
                reader.onload = function () {
                    let imgActual = document.getElementById("imgSelectFileDefault3");
                    imgActual.style.display = "none";
                    let preview = document.getElementById('mostrarImagenPrevia3'),
                        image = document.createElement('img');

                    botonSelectivo.classList.remove('btn-danger');
                    botonSelectivo.classList.add('btn-primary');
                    botonSelectivo.text = "Elegir otra imagen";

                    image.src = reader.result;
                    image.width = 270;
                    image.height = 270;
                    image.style.maxHeight = "270px";
                    image.style.minHeight = "270px";
                    image.style.maxWidth = "270px";
                    image.style.minWidth = "270px";
                    image.classList.add('card-img-left', 'img-thumbnail', 'rounded-circle');
                    image.id = "imgSelectFileDefault3";

                    preview.innerHTML = '';
                    preview.append(image);
                };
            } else {
                let imgActual = document.getElementById("imgSelectFileDefault3");
                id.value = '';
                botonSelectivo.classList.remove('btn-secondary');
                botonSelectivo.classList.add('btn-danger');
                botonSelectivo.text = "Archivo no admitido";
                imgActual.src = "/img/profilesimg/targetblank.png";
                imgActual.addEventListener("click", clickAIMG, false);
                imgActual.style.cursor = "pointer";

            }
        } else {
            let imgActual = document.getElementById("imgSelectFileDefault3");
            id.value = '';
            botonSelectivo.classList.remove('btn-secondary');
            botonSelectivo.classList.add('btn-danger');
            botonSelectivo.text = "Archivo no admitido";
            imgActual.src = "/img/profilesimg/targetblank.png";
            imgActual.addEventListener("click", clickAIMG, false);
            imgActual.style.cursor = "pointer";
        }
    }
}

$(function () {
    $("#formSelectFile3").on("submit", function (e) {


        /*Con el id del input tipo file le indicas que lea la longitud o cantidad de 
          archivos que se seleccionaron*/
        let vidFileLength = $("#selectfile3")[0].files.length;

        /*Aquí validas si no han seleccionado archivos mandas una alerta y se detiene el 
         script*/
        if (vidFileLength === 0 && estado_de_pulso_EP == 1) {
            e.preventDefault();
            alert("Pongale una imagen al perfil :v");
            return false;
        } else {
            let f = $(this);
            let formData = new FormData(document.getElementById("formSelectFile3"));
        }


    });

});

function clickAIMG3() {
    $(document.getElementById("selectfile3")).click();
}