const przycisk = document.getElementById("ruchy");
function klik() {
    document.getElementById("ruchy").click();
}

przycisk.addEventListener("click", function () {
    setInterval(klik(), 200);
});

function przyciskklikniety() {
    klik();
}