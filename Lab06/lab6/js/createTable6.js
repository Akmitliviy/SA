function generateTable6() {
    let div = document.querySelector(".table-6");

    let table = document.createElement("table");
    table.style.border = "1";

    // Заголовки
    let thead = document.createElement("thead");
    let headerRow1 = document.createElement("tr");
    let headerRow2 = document.createElement("tr");

    ["№", "Критерії оцінювання якості ПЗ", "Показники експертів:", "Усереднені значення:"].forEach((text, index) => {
        let th = document.createElement("th");
        if (index === 2) th.colSpan = "4";
        else if (index === 3) th.colSpan = "2"; 
        else th.rowSpan = "3";
        th.textContent = text;
        headerRow1.appendChild(th);
    });
    thead.appendChild(headerRow1);

    ["Галузі застосування", "зручності використання", "з програмування", "потенційні користувачі", "показника", "оцінок"].forEach(text => {
        let th = document.createElement("th");
        th.textContent = text;
        headerRow2.appendChild(th);
    });
    thead.appendChild(headerRow2);

    table.appendChild(thead);

    let tbody = document.createElement("tbody");
    generateTableRows(10, 8, tbody);

    table.appendChild(tbody);
    table.classList.add("mr-4");
    table.setAttribute("data-key", "table6Key");
    div.appendChild(table);

    fillTableWithStaticData(table);

    let newRow1 = tbody.insertRow();
    for(let i = 0; i < 8; i++) {
        newRow1.insertCell();
    }
    tbody.appendChild(newRow1);
    table.rows[12].cells[1].textContent = "Усереднені оцінки експертів";

    let newRow2 = tbody.insertRow();
    for(let i = 0; i < 8; i++) {
        newRow2.insertCell();
    }
    tbody.appendChild(newRow2);
    table.rows[13].cells[1].textContent = "Оцінки експертів з врахуванням їхньої вагомості";

    let newRow = table.insertRow(2);
    for(let i = 0; i < 8; i++) {
        newRow.insertCell();
    }
    table.rows[2].cells[1].textContent = "Коефіцієнти вагомості";
}

window.addEventListener("load", function() {
    generateTable6();
    let table = document.querySelectorAll("table")[1];
    fillCoefficient(table);
    fillTableWithData(table);
    calculateAverageRatings(table);
    calculateAverageRatingsWithCoeff(table);
    calculateAverageCoefficients(table);
    calculateAverageRating2(table);
    fillLastFourCells(table);

    removeInputEventListenersFromTable(table);
});

function fillCoefficient(table) {
    let tableCoefficients = document.querySelectorAll('table')[0];
    var1 = parseFloat(tableCoefficients.rows[1].cells[2].textContent);
    var2 = parseFloat(tableCoefficients.rows[2].cells[2].textContent);
    var3 = parseFloat(tableCoefficients.rows[3].cells[2].textContent);
    var4 = parseFloat(tableCoefficients.rows[4].cells[2].textContent);
    table.rows[2].cells[2].textContent = var1;
    table.rows[2].cells[3].textContent = var2;
    table.rows[2].cells[4].textContent = var3;
    table.rows[2].cells[5].textContent = var4;
    table.rows[2].cells[6].textContent = ((var1 + var2 + var3 + var4) / 4).toFixed(2);
}

function fillTableWithData(table) {
    const table1Data = JSON.parse(localStorage.getItem('table1Key'));
    const table2Data = JSON.parse(localStorage.getItem('table2Key'));

    const rows = table.querySelectorAll('tbody tr');
    for(let i = 0; i < rows.length - 3; i++) {
        const cells = rows[i + 1].cells;

        // Заповнюємо комірки даними із localStorage
        cells[2].textContent = (parseFloat(table1Data[i].cell2) * parseFloat(table2Data[i].cell2)).toFixed(2);
        cells[3].textContent = (parseFloat(table1Data[i].cell3) * parseFloat(table2Data[i].cell3)).toFixed(2);
        cells[4].textContent = (parseFloat(table1Data[i].cell4) * parseFloat(table2Data[i].cell4)).toFixed(2);
        cells[5].textContent = (parseFloat(table1Data[i].cell5) * parseFloat(table2Data[i].cell5)).toFixed(2);
    }
}

function calculateAverageRatings(table) {  
    // 1. Зчитуємо масив з localStorage
    let localStorageArray = JSON.parse(localStorage.getItem('table1Key'));
    if (!localStorageArray) return;

    // 2. Підрахунок суми кожного стовпця у масиві
    let totalColumns = 4; // від cell2 до cell6
    let localStorageSums = Array(totalColumns).fill(0);
    
    localStorageArray.forEach(obj => {
        for (let i = 0; i < totalColumns; i++) {
            localStorageSums[i] += parseFloat(obj['cell' + (i + 2)]);
        }
    });

    // 3. Підрахунок суми значень кожного стовпця в таблиці
    let tableColumnSums = [];
    for (let j = 2; j <= 5; j++) {
        let columnSum = 0;
        for (let i = 3; i <= 12; i++) {
            columnSum += parseFloat(table.rows[i].cells[j].textContent);
        }
        tableColumnSums.push(columnSum);
    }

    // 4. Ділімо суму значень з таблиці на відповідну суму з масиву
    let averageRatings = tableColumnSums.map((sum, index) => sum / localStorageSums[index]);

    // 5. Заповнення рядка "Усереднені оцінки експертів"
    for (let j = 0; j < 4; j++) {
        table.rows[13].cells[j+2].textContent = averageRatings[j].toFixed(2);
    }
}

function calculateAverageRatingsWithCoeff(table) {
    for (let j = 0; j < 4; j++) {
        table.rows[14].cells[j+2].textContent = (parseFloat(table.rows[13].cells[j+2].textContent) *
                                                parseFloat(table.rows[2].cells[j+2].textContent)).toFixed(2);
    }
}

function calculateAverageCoefficients(table) {
    let sum = Array(10).fill(0);
    for (let j = 2; j <= 5; j++) {
        for (let i = 3; i <= 12; i++) {
            sum[i - 3] += parseFloat(table.rows[i].cells[j].textContent) * parseFloat(table.rows[2].cells[j].textContent);
        }
    }
    let coeff = 0;
    for (let j = 2; j <= 5; j++) {
        coeff += parseFloat(table.rows[2].cells[j].textContent);
    }
    for (let i = 3; i <= 12; i++) {
        table.rows[i].cells[6].textContent = (sum[i - 3] / coeff).toFixed(2);
    }
}

function calculateAverageRating2(table) {
    let localStorageArray = JSON.parse(localStorage.getItem('table1Key'));
    if (!localStorageArray) return;
        for (let i = 3; i <= 12; i++) {
            table.rows[i].cells[7].textContent = (parseFloat(table.rows[i].cells[6].textContent) / 
                                                    parseFloat(localStorageArray[i-3]['cell6'])).toFixed(2);
        }
}

function fillLastFourCells(table) {
    let avg1 = 0;
    let avg2 = 0;
    let avg3 = 0;
    let avg4 = 0;
    let avgRating = 0;
    let localStorageArray = JSON.parse(localStorage.getItem('table1Key'));
    if (!localStorageArray) return;
    for(let i = 0; i < localStorageArray.length; i++) {
        avgRating += parseFloat(localStorageArray[i]['cell6']);
    }

    avgRating /= localStorageArray.length;
    for(let i = 3; i <= 12; i++) {
        avg1 += parseFloat(table.rows[i].cells[6].textContent);
        avg2 += parseFloat(table.rows[i].cells[7].textContent);
    }
    avg1 /= 10;
    avg2 /= 10; 
    table.rows[13].cells[6].textContent = (avg1 / avgRating).toFixed(2);
    table.rows[13].cells[7].textContent = avg2.toFixed(2);

    avg3 = (parseFloat(table.rows[13].cells[2].textContent) +
        parseFloat(table.rows[13].cells[3].textContent) +
        parseFloat(table.rows[13].cells[4].textContent) +
        parseFloat(table.rows[13].cells[5].textContent)) / 4;

    table.rows[14].cells[6].textContent = avg3.toFixed(2);

    let tableCoefficients = document.querySelectorAll('table')[0];
    var1 = parseFloat(tableCoefficients.rows[1].cells[2].textContent);
    var2 = parseFloat(tableCoefficients.rows[2].cells[2].textContent);
    var3 = parseFloat(tableCoefficients.rows[3].cells[2].textContent);
    var4 = parseFloat(tableCoefficients.rows[4].cells[2].textContent);
    let coeff = (var1 + var2 + var3 + var4) / 4;

    avg4 = (parseFloat(table.rows[14].cells[2].textContent) +
        parseFloat(table.rows[14].cells[3].textContent) +
        parseFloat(table.rows[14].cells[4].textContent) +
        parseFloat(table.rows[14].cells[5].textContent)) / 4;

    table.rows[14].cells[7].textContent = (avg4 / coeff).toFixed(2);
}


