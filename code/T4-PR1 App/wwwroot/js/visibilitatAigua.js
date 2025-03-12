document.getElementById("tableSelector").addEventListener("change", function () {
    let selected = this.value;

    // Ocultar totes les taules
    document.getElementById("table-tots").style.display = "none";
    document.getElementById("table-mesConsum").style.display = "none";
    document.getElementById("table-mitjaComarca").style.display = "none";
    document.getElementById("table-sospitosos").style.display = "none";
    document.getElementById("table-creixent").style.display = "none";

    // Mostrar la taula seleccionada
    document.getElementById("table-" + selected).style.display = "block";
});