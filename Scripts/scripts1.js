/*$(document).ready(function () {
    $('#validarenume').css({ "display":"none","color":"red"})
    $('#validaredata').css({ "display": "none","color": "red"})
    $('#validarepret').css({ "display":"none", "color": "red"})
    $('#validarecantitate').css({ "display": "none",  "color": "red"})
   $("#MainContent_btnadauga").on('click',  valideazadate)
});*/

window.onload = function () {
    initializarejavascript()
}
function initializarejavascript() {
    document.getElementById("validarenume").style.display = "none"
    document.getElementById("validaredata").style.display = "none"
    document.getElementById("validarepret").style.display = "none"
    document.getElementById("validarecantitate").style.display = "none"
    document.getElementById("validarenume").style.color = 'red'
    document.getElementById("validaredata").style.color = 'red'
    document.getElementById("validarepret").style.color = 'red'
    document.getElementById("validarecantitate").style.color = 'red'

    document.getElementById("validarecategorie").style.display = "none"
    document.getElementById("validarecategorie").style.color = 'red'

}

var countDecimals = function (value) {
    if (Math.floor(value) === value) return 0;
    return value.toString().split(".")[1].length || 0;
}
function validarejavascript() {
    var ok = 1
    if (document.getElementById("MainContent_adauganume").value == "") {
        document.getElementById("MainContent_adauganume").style.border = "solid 1px red"
        document.getElementById("validarenume").style.display = "block"
        document.getElementById("validarenume").innerText = "Numele nu poate fi blank"
        ok = 0
    }
    else {
        document.getElementById("MainContent_adauganume").style.border = "solid 1px black"
        document.getElementById("validarenume").style.display = "none"
    }
    var timestamp = Date.parse((document.getElementById("MainContent_adaugadata").value));
    if (isNaN(timestamp) == true) {
        document.getElementById("MainContent_adaugadata").style.border = "solid 1px red"
        document.getElementById("validaredata").style.display = "block"
        document.getElementById("validaredata").innerText = "Nu e o data valida"
        ok = 0
    }
    else if (timestamp < Date.parse(new Date().toLocaleDateString('en-US', { year: 'numeric', month: '2-digit', day: '2-digit' }))) {
        document.getElementById("MainContent_adaugadata").style.border = "solid 1px red"
        document.getElementById("validaredata").style.display = "block"
        document.getElementById("validaredata").innerText = "Data expirata"
        ok = 0
    }
    else {
        document.getElementById("MainContent_adaugadata").style.border = "solid 1px black"
        document.getElementById("validaredata").style.display = "none"
    }
    var strpret = document.getElementById("MainContent_adaugapret").value
    if (strpret.toString().indexOf(',') > 0) {
        strpret = strpret.replace(',', '.')
        document.getElementById("MainContent_adaugapret").value = strpret
    }
    var pret = parseFloat(strpret);
    if (isNaN(pret) == true) {
        document.getElementById("MainContent_adaugapret").style.border = "solid 1px red"
        document.getElementById("validarepret").style.display = "block"
        document.getElementById("validarepret").innerText = "NaN"
        ok = 0
    }
    else if (pret < 0) {
        document.getElementById("MainContent_adaugapret").style.border = "solid 1px red"
        document.getElementById("validarepret").style.display = "block"
        document.getElementById("validarepret").innerText = "pretul nu poate fi negativ"
        ok = 0
    }
    else if (countDecimals(pret) > 2) {
        document.getElementById("MainContent_adaugapret").style.border = "solid 1px red"
        document.getElementById("validarepret").style.display = "block"
        document.getElementById("validarepret").innerText = "pretul are prea multe zecimale"
        ok = 0
    }
    else {
        document.getElementById("MainContent_adaugapret").style.border = "solid 1px black"
        document.getElementById("validarepret").style.display = "none"
    }


    var cantitate = parseInt((document.getElementById("MainContent_adaugacantitate").value));
    if (isNaN(cantitate) == true) {
        document.getElementById("MainContent_adaugacantitate").style.border = "solid 1px red"
        document.getElementById("validarecantitate").style.display = "block"
        document.getElementById("validarecantitate").innerText = "NaN"
        ok = 0
    }
    else {
        document.getElementById("MainContent_adaugacantitate").style.border = "solid 1px black"
        document.getElementById("validarecantitate").style.display = "none"
        if (ok != 0) return true
    }

    return false;
}


function valideazadate() {
    var ok = 1;
    //alert("mesaj test")
    //alert($("#MainContent_adauganume").val())

    if ($("#MainContent_adauganume").val().trimEnd().trimStart() == "") {
        $("#MainContent_adauganume").css("border", "solid 1px red")
        ok = 0
        $('#validarenume').css("display", "block")
    }
    else {
        $("#MainContent_adauganume").css("border", "solid 1px black")
        $('#validarenume').css("display", "none")
    }
    //$("#MainContent_btnadauga").val()

    if ($("#MainContent_adaugadata").val().trimEnd().trimStart() == "") {
        $("#MainContent_adaugadata").css("border", "solid 1px red")
        $('#validaredata').css("display", "block")
        ok = 0
    }
    else {
        $("#MainContent_adaugadata").css("border", "solid 1px black")
        $('#validaredata').css("display", "none")
    }

    if ($("#MainContent_adaugapret").val().trimEnd().trimStart() == "") {
        $("#MainContent_adaugapret").css("border", "solid 1px red")
        $('#validarepret').css("display", "block")
        ok = 0
    }
    else {
        $("#MainContent_adaugapret").css("border", "solid 1px black")
        $('#validarepret').css("display", "none")
    }

    if ($("#MainContent_adaugacantitate").val().trimEnd().trimStart() == "") {
        $("#MainContent_adaugacantitate").css("border", "solid 1px red")
        $('#validarecantitate').css("display", "block")
    }
    else {
        $("#MainContent_adaugacantitate").css("border", "solid 1px black")
        $('#validarecantitate').css("display", "none")
        if (ok == 1) return true
    }
    return false



}

$(function () {
    $("#MainContent_adaugadata").datepicker();
});