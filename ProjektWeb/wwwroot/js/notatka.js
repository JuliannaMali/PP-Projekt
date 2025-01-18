document.querySelector("#scout").addEventListener("click", function () {
    document.querySelector("#scoutcheck").click();

    pojawienie();

    document.getElementById('scoutimg').style = 'box-shadow: 0px 00px 24px 16px rgb(0, 204, 102)';
    document.getElementById('knightimg').style = 'box-shadow: 0px 00px 24px -100px rgb(153, 255, 204)';

    document.querySelector('#game').attributes[4].value = 'Graj Zwiadowcą!';

    document.querySelector('#namehero').attributes[2].value = 'Podaj imię swojego zwiadowcy'
})

document.querySelector("#knight").addEventListener("click", function () {
    document.querySelector("#knightcheck").click();

    pojawienie();

    document.getElementById('knightimg').style = 'box-shadow: 0px 00px 24px 16px rgba(102, 194, 255, 1)';
    document.getElementById('scoutimg').style = 'box-shadow: 0px 00px 24px -100px rgba(102, 194, 255, 1)';

    document.querySelector('#game').innerHTML = 'Graj Rycerzem!';

    document.querySelector('#namehero').attributes[2].value = 'Podaj imię swojego rycerza'
})

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
    document.getElementById(this.id).style.transition = 'opacity 1s ease-in, visibility 1.1s ease-in';
    document.getElementById(this.id).style.visibility = 'hidden';

    counter--;

    if (counter == 0) {
        setTimeout(function () {
            document.getElementById('hero').style.opacity = '1';
            document.getElementById('hero').style.transition = 'opacity 2s ease-in, visibility 0.05s ease-in';
            document.getElementById('hero').style.visibility = 'visible';
        }, 2000)
    }
}


function pojawienie() {
    document.querySelector("#game").style.opacity = '1';
    document.querySelector("#game").style.transition = 'opacity 2s ease-in, visibility 0.01s ease-in';
    document.querySelector("#game").style.visibility = 'visible';

    document.querySelector("#demo").style.opacity = '1';
    document.querySelector("#demo").style.transition = 'opacity 2s ease-in, visibility 0.01s ease-in';
    document.querySelector("#demo").style.visibility = 'visible';

    document.querySelector('#namehero').style.opacity = '1';
    document.querySelector('#namehero').style.transition = 'opacity 2s ease-in, visibility 0.05s ease-in';
    document.querySelector('#namehero').style.visibility = 'visible';
}