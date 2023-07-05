// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function cleanSelectedRow() {
    let selectedRow = document.getElementsByClassName("selectedRow");
    for (let i = 0; i < selectedRow.length; i++) {
        selectedRow[i].classList.remove("selectedRow");
    }
}

function rowClick(id) {
    let el = document.getElementById(id);
    cleanSelectedRow();
    el.classList.add("selectedRow");
}
function RefreshStudentTable(tbId) {
    let tb = document.getElementById(tbId);
    let xhr = new XMLHttpRequest();
    xhr.open('GET', '/api/StudentGroups', true);
    xhr.responseType = 'json';
    xhr.onload = function () {
        var status = xhr.status;
        if (status == 200) {
            let data = xhr.response;

            let a = 10;
        } else {

        }
    }
    xhr.send();



    var rs = $.getJSON('/api/studentgroups', (data) => {

        tb.innerHTML = null;
        for (let i = 0; i < data.length; i++) {
            tr = document.createElement("tr");
            tb.appendChild(tr);
            tdName = document.createElement("td");
            tr.appendChild(tdName);
            let id = "id" + data[i].id;
            tr.id = id;
            tr.onclick = ()=> rowClick(id);
            tdName.innerHTML = data[i].name;
            tr.appendChild(document.createElement("td"));
        }


    });


 }