let counter = 7;

const note = document.getElementById("ani")


const papiery = document.querySelectorAll('.stickynote');

papiery.forEach(dodanie);

function dodanie(papier) {
    papier.addEventListener("click", zerwanie)
}

function zerwanie(id) {
    document.getElementById(this.id).style.pointerEvents = 'none';
    document.getElementById(this.id).style.opacity = '0';
    document.getElementById(this.id).style.transition = 'opacity 2s ease-in, visibility 2.1s ease-in';
    document.getElementById(this.id).style.visibility = 'hidden';

    counter--;

    if (counter == 0) {
        document.getElementById("game").style.opacity = '1';
        document.getElementById("game").style.transition = 'opacity 2s ease-in, visibility 0.01s ease-in';
        document.getElementById("game").style.visibility = 'visible';
    }
}


