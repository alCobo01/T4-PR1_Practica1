document.addEventListener('DOMContentLoaded', function () {
    const tipusSelector = document.getElementById('tipusSelector');
    const campSolar = document.getElementById('campSolar');
    const campEolic = document.getElementById('campEolic');
    const campHidroelectric = document.getElementById('campHidroelectric');

    function actualitzarCamps() {
        campEolic.style.display = 'none';
        campHidroelectric.style.display = 'none';

        campSolar.querySelectorAll("input").forEach(input => input.disabled = true);
        campEolic.querySelectorAll("input").forEach(input => input.disabled = true);
        campHidroelectric.querySelectorAll("input").forEach(input => input.disabled = true);

        const valorSeleccionat = tipusSelector.value;

        if (valorSeleccionat) {
            if (valorSeleccionat === '0') {
                campHidroelectric.style.display = 'block';
                campHidroelectric.querySelectorAll("input").forEach(input => input.disabled = false);
            } else if (valorSeleccionat === '1') {
                campEolic.style.display = 'block';
                campEolic.querySelectorAll("input").forEach(input => input.disabled = false);
            } else if (valorSeleccionat === '2') {
                campSolar.style.display = 'block';
                campSolar.querySelectorAll("input").forEach(input => input.disabled = false);
            }
        }
    }

    tipusSelector.addEventListener('change', actualitzarCamps);

    actualitzarCamps();
});
