function changeTable() {
    // Obtenir el valor seleccionat
    var selector = document.getElementById("tableTotsSelector");
    var value = selector.value;

    // Ocultar totes les taules
    document.getElementById("pbeeTable").style.display = "none";
    document.getElementById("cdeebcTable").style.display = "none";
    document.getElementById("feeTable").style.display = "none";
    document.getElementById("feeiTable").style.display = "none";
    document.getElementById("combustiblesTable").style.display = "none";

    // Mostrar la taula corresponent
    if (value === "pbee") {
        document.getElementById("pbeeTable").style.display = "block";
    } else if (value === "cdeebc") {
        document.getElementById("cdeebcTable").style.display = "block";
    } else if (value === "fee") {
        document.getElementById("feeTable").style.display = "block";
    } else if (value === "feei") {
        document.getElementById("feeiTable").style.display = "block";
    } else if (value === "combustibles") {
        document.getElementById("combustiblesTable").style.display = "block";
    }
}

document.getElementById("tableSelector").addEventListener("change", function () {
    let selected = this.value;

    // Ocultar totes les taules
    document.getElementById("table-tots").style.display = "none";
    document.getElementById("table-prodNeta").style.display = "none";
    document.getElementById("table-consumGas").style.display = "none";
    document.getElementById("table-prodMitja").style.display = "none";
    document.getElementById("table-demanda").style.display = "none";

    // Mostrar la taula seleccionada
    document.getElementById("table-" + selected).style.display = "block";
});