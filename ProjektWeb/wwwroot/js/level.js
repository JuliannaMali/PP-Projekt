const ikony = document.querySelectorAll(".pic")

let id = 0;
let lvlid = 0;


const levele = document.querySelectorAll(".lvl")


ikony.forEach(zamiana)
levele.forEach(zamiana2)

function zamiana(ikona) {
    ikona.addEventListener("click", pokaz)
}

function zamiana2(lvl) {
    lvl.addEventListener("click", pokaz2)
}

function pokaz() {

    this.style.visibility = "hidden";

    id = this.id;
    console.log(id);
    lvlid = id.slice(3);
    console.log(lvlid);
    

    document.getElementById("lvl"+lvlid).style.visibility = "visible";
}

function pokaz2() {

    this.style.visibility = "hidden";

    id = this.id;
    console.log(id);
    lvlid = id.slice(3);
    console.log(lvlid);


    document.getElementById("pic" + lvlid).style.visibility = "visible";
}