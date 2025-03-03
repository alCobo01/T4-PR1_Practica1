document.addEventListener('DOMContentLoaded', function () {
    const tipusSelector = document.getElementById('tipusSelector');
    const camposSolar = document.getElementById('campSolar');
    const camposEolic = document.getElementById('campEolic');
    const camposHidroelectric = document.getElementById('campHidroelectric');

    function actualitzarCamps() {
        campSolar.style.display = 'none';
        campEolic.style.display = 'none';
        campHidroelectric.style.display = 'none';

        const valorSeleccionat = tipusSelector.value;

        if (valorSeleccionat) {
            if (valorSeleccionat === '0') {
                campHidroelectric.style.display = 'block';
            } else if (valorSeleccionat === '1') {
                campEolic.style.display = 'block';
            } else if (valorSeleccionat === '2') {
                campSolar.style.display = 'block';
            }
        }
    }

    tipusSelector.addEventListener('change', actualitzarCamps);
});