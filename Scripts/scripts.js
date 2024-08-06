$(document).ready(function () {
    $('#validarenume').css({ "display":"none","color":"red"})
    $('#validaredata').css({ "display": "none","color": "red"})
    $('#validarepret').css({ "display":"none", "color": "red"})
    $('#validarecantitate').css({ "display": "none",  "color": "red"})
   $("#MainContent_btnadauga").on('click',  valideazadate)
});



function valideazadate()
{
    var ok = 1;
    //alert("mesaj test")
    //alert($("#MainContent_adauganume").val())

    if ($("#MainContent_adauganume").val() == "") {
        $("#MainContent_adauganume").css("border", "solid 1px red")
        ok = 0
        $('#validarenume').css("display", "block")
    }
    else
    {
        $("#MainContent_adauganume").css("border", "solid 1px black")
        $('#validarenume').css("display", "none")
    }
    //$("#MainContent_btnadauga").val()

    if ($("#MainContent_adaugadata").val() == "") {
        $("#MainContent_adaugadata").css("border", "solid 1px red")
        $('#validaredata').css("display", "block")
        ok = 0
    }
    else {
        $("#MainContent_adaugadata").css("border", "solid 1px black")
        $('#validaredata').css("display", "none")
    }

    if ($("#MainContent_adaugapret").val() == "") {
        $("#MainContent_adaugapret").css("border", "solid 1px red")
        $('#validarepret').css("display", "block")
        ok = 0
    }
    else {
        $("#MainContent_adaugapret").css("border", "solid 1px black")
        $('#validarepret').css("display", "none")
    }

    if ($("#MainContent_adaugacantitate").val() == "") {
        $("#MainContent_adaugacantitate").css("border", "solid 1px red")
        $('#validarecantitate').css("display", "block")
    }
    else {
        $("#MainContent_adaugacantitate").css("border", "solid 1px black")
        $('#validarecantitate').css("display", "none")
        if(ok==1)return true
    }
    return false



}