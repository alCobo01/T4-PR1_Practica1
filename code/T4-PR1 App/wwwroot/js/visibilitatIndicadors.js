function changeTable() {
    // Obtener el valor seleccionado
    var selector = document.getElementById("tableSelector");
    var value = selector.value;

    // Ocultar todas las tablas
    document.getElementById("pbeeTable").style.display = "none";
    document.getElementById("cdeebcTable").style.display = "none";
    document.getElementById("feeTable").style.display = "none";
    document.getElementById("feeiTable").style.display = "none";
    document.getElementById("combustiblesTable").style.display = "none";

    // Mostrar la tabla correspondiente
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
