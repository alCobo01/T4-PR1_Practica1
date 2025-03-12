function changeTable() {  
   // Obtenir el valor seleccionat  
   let selector = document.getElementById("tableTotsSelector");  
   let value = selector.value;  
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

document.addEventListener("DOMContentLoaded", function () {  
   // Configuració inicial  
   const tableSelector = document.getElementById("tableSelector");  
   const tableTots = document.getElementById("table-tots");  

   // Establir l'esdeveniment change per al selector principal  
   tableSelector.addEventListener("change", function () {  
       let selected = this.value;  

       // Ocultar totes les taules i selectors  
       document.getElementById("table-tots").style.display = "none";  
       document.getElementById("pbeeTable").style.display = "none";  
       document.getElementById("cdeebcTable").style.display = "none";  
       document.getElementById("feeTable").style.display = "none";  
       document.getElementById("feeiTable").style.display = "none";  
       document.getElementById("combustiblesTable").style.display = "none";  
       document.getElementById("table-prodNeta").style.display = "none";  
       document.getElementById("table-consumGas").style.display = "none";  
       document.getElementById("table-prodMitja").style.display = "none";  
       document.getElementById("table-demanda").style.display = "none";  

       // Mostrar la taula seleccionada  
       if (selected === "tots") {  
           // Per a 'tots', mostrar el selector secundari i la taula predeterminada (pbee)  
           document.getElementById("table-tots").style.display = "block";  
           document.getElementById("pbeeTable").style.display = "block";  
       } else {  
           // Per a altres opcions, mostrar la taula corresponent  
           document.getElementById("table-" + selected).style.display = "block";  
       }  
   });  

   // Configurar estat inicial - mostrar "tots" seleccionat per defecte  
   tableTots.style.display = "block";  
   document.getElementById("pbeeTable").style.display = "block";  
});  

// Mantenir l'esdeveniment per al selector secundari  
document.addEventListener("DOMContentLoaded", function () {  
   if (document.getElementById("tableTotsSelector")) {  
       document.getElementById("tableTotsSelector").addEventListener("change", changeTable);  
   }  
});