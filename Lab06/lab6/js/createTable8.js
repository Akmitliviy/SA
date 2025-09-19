function generateTable8(tableID,textField, canvasID, color, needClear=true) {
    const div = document.querySelector('.' + tableID);
    const table = document.createElement("table");
    let thead = document.createElement("thead");
    table.style.border = "1";

    // Create header
    const headerRow = document.createElement("tr");
    const criteriaHeader = document.createElement("th");
    const th1 = document.createElement("th");
    th1.textContent = "№";
    criteriaHeader.textContent = "Критерії оцінювання якості ПЗ";
    headerRow.appendChild(th1);
    headerRow.appendChild(criteriaHeader);

    const headers = ["Усереднені оцінки", "Частка круга", "Кут α", "Кут β(град)", "Кут β(рад)", "Довж.вект.", "a", "b" , "S"];
    headers.forEach(header => {
        const th = document.createElement("th");
        th.textContent = header;
        headerRow.appendChild(th);
    });
    thead.appendChild(headerRow);
    table.appendChild(thead);


    let tbody = document.createElement("tbody");

    generateTableRows(10, 11, tbody);
    table.appendChild(tbody);
    table.classList.add("mr-4");
    table.classList.add("mt-4");
    table.id = tableID;
    div.appendChild(table);

    fillTableWithStaticData(table);
    fillCoef1(table);
    fillPartOfCircle(table);
    fillAlphaAngel(table);
    fillBetaAngel(table);
    fillVectorLenght1(table);
    fillABside(table);
    fillSquare(table);
    if(textField != 'diagram5-data') {
        calculateFullSquareAndShareOfQuality(table, textField);
    }

    const canvas = document.getElementById(canvasID);
    setcanvas_settings(canvas)
    const ctx = canvas.getContext("2d");

    createDiagram1(tableID, ctx, color, needClear);
}


window.addEventListener("load", function() {
    generateTable8('table-12', 'diagram6-data', 'diagram6');
   
    let table4 = document.querySelectorAll("table")[4];
    removeInputEventListenersFromTable(table4);
});

function fillCoef1(table) {
    let localStorageArray = JSON.parse(localStorage.getItem('table1Key'));
    if (!localStorageArray) return;
    for(let i = 0; i < 10; i++) {
        table.rows[i+1].cells[2].textContent = parseFloat(localStorageArray[i]['cell6']);
    }
}

function fillVectorLenght1(table) {
    let localStorageArray1 = JSON.parse(localStorage.getItem('table1Key'));
    let localStorageArray2 = JSON.parse(localStorage.getItem('table2Key'));
    let coefficientArray = JSON.parse(localStorage.getItem('table5Key'));
    let sumCoef = 0;
    for(let i = 0; i < 4; i++) {
        sumCoef += parseFloat(coefficientArray[i]['cell2']);
    }
    for(let i = 0; i < 10; i++) {
        let dobutok = 0;
        for(let j = 0; j < 4; j++) {
            dobutok += parseFloat(localStorageArray1[i]['cell' + (j+2)]) *
                       parseFloat(localStorageArray2[i]['cell' + (j+2)]) * 
                       parseFloat(coefficientArray[j]['cell2']);
        }
        table.rows[i+1].cells[7].textContent = (dobutok / sumCoef).toFixed(2);

    }

}
